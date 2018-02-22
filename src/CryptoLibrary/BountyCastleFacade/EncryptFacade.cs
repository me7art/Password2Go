using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.IO;

namespace CryptoLibrary.BountyCastleFacade
{
    public class EncryptFacade
    {
        byte[] _encKeyBytes;
        //byte[] _messageBytes;

        PgpPublicKey _encKey;

        public EncryptFacade(byte[] encKeyBytes)
        {
            _encKeyBytes = encKeyBytes;
            //_messageBytes = messageBytes;
        }

        public void Init()
        {
            using (var ms = new MemoryStream(_encKeyBytes))
            {
                _encKey = ReadPublicKey(ms);
            }
        }

        public string PublicKeyID => _encKey.KeyId.ToString();

        public byte[] Encrypt(byte[] messageBytes)
        {
            using (var ms = new MemoryStream())
            {
                Encrypt(ms, messageBytes, _encKey, withIntegrityCheck: true);
                var encryptedBytes = ms.ToArray();
                return encryptedBytes;
            }
        }

        internal static void Encrypt(Stream st, byte[] bytes, PgpPublicKey encKey, bool withIntegrityCheck)
        {

            using (var outputStream = new ArmoredOutputStream(st))
            {
                PgpEncryptedDataGenerator encGen = new PgpEncryptedDataGenerator(
                    SymmetricKeyAlgorithmTag.Cast5, withIntegrityCheck, new SecureRandom());

                encGen.AddMethod(encKey);

                using (Stream cOut = encGen.Open(outputStream, bytes.Length))
                {
                    cOut.Write(bytes, 0, bytes.Length);
                }
            }
        }

        internal static PgpPublicKey ReadPublicKey(Stream input)
        {
            PgpPublicKeyRingBundle pgpPub = new PgpPublicKeyRingBundle(
                PgpUtilities.GetDecoderStream(input));

            //
            // In Password2Go app each key stored in separate file
            // 

            foreach (PgpPublicKeyRing keyRing in pgpPub.GetKeyRings())
            {
                foreach (PgpPublicKey key in keyRing.GetPublicKeys())
                {
                    if (key.IsEncryptionKey)
                    {
                        return key;
                    }
                }
            }

            throw new ArgumentException("Can't find encryption key in key ring.");
        }
    }
}
