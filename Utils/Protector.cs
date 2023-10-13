using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Lunar.Avalonia1.Utils;

public class Protector
{
    public static string EncryptAES(string plainText, string password)
    {
        return EncryptSymmetric(plainText, password, Aes.Create());
    }

    public static string DecryptAES(string cryptoText, string password)
    {
        return DecryptSymmetric(cryptoText, password, Aes.Create());
    }

    private static string EncryptSymmetric(string plainText, string password, SymmetricAlgorithm algo)
    {
        byte[] encryptedBytes;
        byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);
        algo.Key = Convert.FromBase64String(password);
        algo.GenerateIV();

        using (MemoryStream ms = new())
        {
            using (CryptoStream cs = new(ms, algo.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(plainBytes, 0, plainBytes.Length);
            }
            encryptedBytes = ms.ToArray();
        }

        byte[] output = new byte[algo.IV.Length + encryptedBytes.Length];
        Buffer.BlockCopy(algo.IV, 0, output, 0, algo.IV.Length);
        Buffer.BlockCopy(encryptedBytes, 0, output, algo.IV.Length, encryptedBytes.Length);

        return Convert.ToBase64String(output);
    }

    private static string DecryptSymmetric(string cryptoText, string password, SymmetricAlgorithm algo)
    {
        byte[] plainBytes;
        byte[] cryptoBytes = Convert.FromBase64String(cryptoText);

        byte[] initVector = new byte[algo.IV.Length];
        byte[] data = new byte[cryptoBytes.Length - algo.IV.Length];

        Buffer.BlockCopy(cryptoBytes, 0, initVector, 0, algo.IV.Length);
        Buffer.BlockCopy(cryptoBytes, algo.IV.Length, data, 0, data.Length);

        algo.Key = Convert.FromBase64String(password);
        algo.IV = initVector;

        using (MemoryStream ms = new())
        {
            using (CryptoStream cs = new (ms, algo.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(data, 0, data.Length);
            }
            plainBytes = ms.ToArray();
        }

        return Encoding.Unicode.GetString(plainBytes);
    }
}