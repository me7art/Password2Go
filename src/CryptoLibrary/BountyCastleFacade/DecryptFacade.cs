using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Common;
using System.IO;

using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.IO;


namespace CryptoLibrary.BountyCastleFacade
{
    public class DecryptFacade
    {
        //byte[] _messageBytes;
        byte[] _privateKey;
        string _passPhrase;

        PgpPrivateKey _pgpPrivateKey;

        public DecryptFacade(byte[] privateKey, string passPhrase)
        {
            //_messageBytes = message;
            _privateKey = privateKey;
            _passPhrase = passPhrase;
        }

        public byte[] Decrypt(byte[] messageBytes)
        {
            using (MemoryStream ms = new MemoryStream(messageBytes))
            {
                return Decrypt(ms, _pgpPrivateKey);
            }
        }

        public void Init()
        {
            using (MemoryStream ms = new MemoryStream(_privateKey))
            {
                _pgpPrivateKey = ReadPrivateKey(ms, _passPhrase);
            }
        }

        public string PrivateKeyID => _pgpPrivateKey.KeyId.ToString();

        static private PgpPrivateKey ReadPrivateKey(Stream input, string pass)
        {
            PgpSecretKeyRingBundle pgpSec = new PgpSecretKeyRingBundle(
                PgpUtilities.GetDecoderStream(input));

            foreach (PgpSecretKeyRing keyRing in pgpSec.GetKeyRings())
            {
                foreach (PgpSecretKey key in keyRing.GetSecretKeys())
                {
                    if (key.IsSigningKey)
                    {
                        //pgpSecKey.ExtractPrivateKey(pass);
                        return key.ExtractPrivateKey(pass.ToArray());
                    }
                }
            }

            throw new ArgumentException("Can't find signing key in key ring.");
        }

        static private byte[] Decrypt(Stream inputStream, PgpPrivateKey sKey)
        {
            inputStream = PgpUtilities.GetDecoderStream(inputStream);

            PgpObjectFactory pgpF = new PgpObjectFactory(inputStream);
            PgpEncryptedDataList enc;

            PgpObject o = pgpF.NextPgpObject();
            //
            // the first object might be a PGP marker packet.
            //
            if (o is PgpEncryptedDataList)
            {
                enc = (PgpEncryptedDataList)o;
            }
            else
            {
                enc = (PgpEncryptedDataList)pgpF.NextPgpObject();
            }

            PgpPublicKeyEncryptedData pbe = null;

            foreach (PgpPublicKeyEncryptedData pked in enc.GetEncryptedDataObjects())
            {
                pbe = pked;
                break;
            }

            using (Stream clear = pbe.GetDataStream(sKey))
            {
                var bArr = Helpers.StreamHelper.ReadFully(clear);
                return bArr;
            }
        }
    }
}
