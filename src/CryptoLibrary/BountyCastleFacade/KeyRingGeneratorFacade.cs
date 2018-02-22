using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Bcpg;

namespace CryptoLibrary.BountyCastleFacade
{
    public class KeyRingType
    {
        byte[] _publicKey;
        byte[] _privateKey;
        string _keyID;
        public byte[] PublicKey => _publicKey;
        public byte[] PrivateKey => _privateKey;
        public string KeyID => _keyID;

        public KeyRingType(byte[] publicKey, byte[] privateKey, string keyid)
        {
            _publicKey = publicKey;
            _privateKey = privateKey;
            _keyID = keyid;
        }
    }

    public class KeyRingGeneratorFacade
    {
        IAsymmetricCipherKeyPairGenerator _kpg;
         string _identity;
        string _passPhrase;
 

        public KeyRingGeneratorFacade(string identity, string passPhrase)
        {
            _identity = identity;
            _passPhrase = passPhrase;
        }

        public Task<KeyRingType> GenerateKeysAsync(bool runTask = true)
        {
            var task = new Task<KeyRingType>(
                () =>
                {
                    return GenerateKeys();
                });

            if (runTask) task.Start();

            return task;
        }

        public KeyRingType GenerateKeys()
        {
            AsymmetricCipherKeyPair kp = _kpg.GenerateKeyPair();

            MemoryStream out1, out2;

            out1 = new MemoryStream(); // File.Create("secret.asc");
            out2 = new MemoryStream(); // File.Create("pub.asc");

            try
            {
                string keyID = string.Empty;
                ExportKeyPair(out1, out2, kp.Public, kp.Private, _identity, _passPhrase.ToCharArray(), true, ref keyID);

                var privateKey = out1.ToArray(); //Helpers.StreamHelper.ReadFully(out1);
                var publicKey = out2.ToArray(); //Helpers.StreamHelper.ReadFully(out2);

                return new KeyRingType(publicKey, privateKey, keyID);
            }
            finally
            {
                out1.Close();
                out2.Close();
            }
        }

        public void Init()
        {
            _kpg = GeneratorUtilities.GetKeyPairGenerator("RSA");

            _kpg.Init(new RsaKeyGenerationParameters(
                BigInteger.ValueOf(0x10001), new SecureRandom(), 4096/*1024*/, 25));
        }

        private static void ExportKeyPair(
            Stream secretOut,
            Stream publicOut,
            AsymmetricKeyParameter publicKey,
            AsymmetricKeyParameter privateKey,
            string identity,
            char[] passPhrase,
            bool armor,
            ref string keyID)
        {
            if (armor)
            {
                secretOut = new ArmoredOutputStream(secretOut);
            }

            PgpSecretKey secretKey = new PgpSecretKey(
                PgpSignature.DefaultCertification,
                PublicKeyAlgorithmTag.RsaGeneral,
                publicKey,
                privateKey,
                DateTime.UtcNow,
                identity,
                SymmetricKeyAlgorithmTag.Cast5,
                passPhrase,
                null,
                null,
                new SecureRandom()
                );

            secretKey.Encode(secretOut);

            keyID = secretKey.KeyId.ToString();

            if (armor)
            {
                secretOut.Close();
                publicOut = new ArmoredOutputStream(publicOut);
            }

            PgpPublicKey key = secretKey.PublicKey;

            key.Encode(publicOut);

            if (armor)
            {
                publicOut.Close();
            }
        }
    }
}
