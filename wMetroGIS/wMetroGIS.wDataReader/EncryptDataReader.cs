using System;
using System.Security.Cryptography;
using System.Text;

namespace wMetroGIS.wDataReader
{
	public class EncryptDataReader
	{
		public static string Encrypt(string original)
		{
			return EncryptDataReader.Encrypt(original, "j2mv9jyyq6jm44k");
		}

		public static string Decrypt(string original)
		{
			return EncryptDataReader.Decrypt(original, "j2mv9jyyq6jm44k", System.Text.Encoding.Default);
		}

		public static string Decrypt(string original, string key)
		{
			return EncryptDataReader.Decrypt(original, key, System.Text.Encoding.Default);
		}

		public static string Decrypt(string original, System.Text.Encoding encoding)
		{
			return EncryptDataReader.Decrypt(original, "j2mv9jyyq6jm44k", encoding);
		}

		public static string Encrypt(string original, string key)
		{
			byte[] buff = System.Text.Encoding.Default.GetBytes(original);
			byte[] kb = System.Text.Encoding.Default.GetBytes(key);
			return System.Convert.ToBase64String(EncryptDataReader.Encrypt(buff, kb));
		}

		public static string Decrypt(string encrypted, string key, System.Text.Encoding encoding)
		{
			byte[] buff = System.Convert.FromBase64String(encrypted);
			byte[] kb = System.Text.Encoding.Default.GetBytes(key);
			return encoding.GetString(EncryptDataReader.Decrypt(buff, kb));
		}

		public static byte[] MakeMD5(byte[] original)
		{
			System.Security.Cryptography.MD5CryptoServiceProvider hashmd5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
			return hashmd5.ComputeHash(original);
		}

		public static byte[] Encrypt(byte[] original, byte[] key)
		{
			return new System.Security.Cryptography.TripleDESCryptoServiceProvider
			{
				Key = EncryptDataReader.MakeMD5(key),
				Mode = System.Security.Cryptography.CipherMode.ECB
			}.CreateEncryptor().TransformFinalBlock(original, 0, original.Length);
		}

		public static byte[] Decrypt(byte[] encrypted, byte[] key)
		{
			return new System.Security.Cryptography.TripleDESCryptoServiceProvider
			{
				Key = EncryptDataReader.MakeMD5(key),
				Mode = System.Security.Cryptography.CipherMode.ECB
			}.CreateDecryptor().TransformFinalBlock(encrypted, 0, encrypted.Length);
		}

		public static byte[] Encrypt(byte[] original)
		{
			byte[] key = System.Text.Encoding.Default.GetBytes("j2mv9jyyq6jm44k");
			return EncryptDataReader.Encrypt(original, key);
		}

		public static byte[] Decrypt(byte[] encrypted)
		{
			byte[] key = System.Text.Encoding.Default.GetBytes("j2mv9jyyq6jm44k");
			return EncryptDataReader.Decrypt(encrypted, key);
		}
	}
}
