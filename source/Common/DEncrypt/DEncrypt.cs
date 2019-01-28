using System;
using System.Security.Cryptography;  
using System.Text;
using System.Configuration;
namespace Common.DEncrypt
{
	/// <summary>
	/// Encrypt 的摘要说明。
    ///  
	/// </summary>
	public class DEncrypt
	{
		/// <summary>
		/// 构造方法
		/// </summary>
		public DEncrypt()  
		{  
		}

        public static readonly string Key = ConfigurationManager.AppSettings["Key"];

		#region 使用 缺省密钥字符串 加密/解密string

		/// <summary>
		/// 使用缺省密钥字符串加密string
		/// </summary>
        /// <param name="realText">明文</param>
		/// <returns>密文</returns>
		public static string Encrypt(string realText)
		{
            return Encrypt(realText, Key);
		}
		/// <summary>
		/// 使用缺省密钥字符串解密string
		/// </summary>
        /// <param name="cipherText">密文</param>
		/// <returns>明文</returns>
        public static string Decrypt(string cipherText)
		{
            return Decrypt(cipherText, Key, System.Text.Encoding.Default);
		}

		#endregion

		#region 使用 给定密钥字符串 加密/解密string
		/// <summary>
		/// 使用给定密钥字符串加密string
		/// </summary>
        /// <param name="realText">明文</param>
		/// <param name="key">密钥</param>
		/// <param name="encoding">字符编码方案</param>
		/// <returns>密文</returns>
        public static string Encrypt(string realText, string key)  
		{
            byte[] buff = System.Text.Encoding.Default.GetBytes(realText);  
			byte[] kb = System.Text.Encoding.Default.GetBytes(key);
			return Convert.ToBase64String(Encrypt(buff,kb));      
		}
		/// <summary>
		/// 使用给定密钥字符串解密string
		/// </summary>
        /// <param name="cipherText">密文</param>
		/// <param name="key">密钥</param>
		/// <returns>明文</returns>
        public static string Decrypt(string cipherText, string key)
		{
            return Decrypt(cipherText, key, System.Text.Encoding.Default);
		}

		/// <summary>
		/// 使用给定密钥字符串解密string,返回指定编码方式明文
		/// </summary>
        /// <param name="cipherText">密文</param>
		/// <param name="key">密钥</param>
		/// <param name="encoding">字符编码方案</param>
		/// <returns>明文</returns>
        public static string Decrypt(string cipherText, string key, Encoding encoding)  
		{
            byte[] buff = Convert.FromBase64String(cipherText);  
			byte[] kb = System.Text.Encoding.Default.GetBytes(key);
			return encoding.GetString(Decrypt(buff,kb));      
		}  
		#endregion

		#region 使用 缺省密钥字符串 加密/解密/byte[]
		/// <summary>
		/// 使用缺省密钥字符串解密byte[]
		/// </summary>
		/// <param name="encrypted">密文</param>
		/// <param name="key">密钥</param>
		/// <returns>明文</returns>
        public static byte[] Decrypt(byte[] cipherText)  
		{
            byte[] key = System.Text.Encoding.Default.GetBytes(Key);
            return Decrypt(cipherText, key);     
		}
		/// <summary>
		/// 使用缺省密钥字符串加密
		/// </summary>
        /// <param name="realText">原始数据</param>
		/// <param name="key">密钥</param>
		/// <returns>密文</returns>
        public static byte[] Encrypt(byte[] realText)  
		{
            byte[] key = System.Text.Encoding.Default.GetBytes(Key);
            
            return Encrypt(realText, key);     
		}  
		#endregion

		#region  使用 给定密钥 加密/解密/byte[]

		/// <summary>
		/// 生成MD5摘要
		/// </summary>
        /// <param name="realText">数据源</param>
		/// <returns>摘要</returns>
        public static byte[] MakeMD5(byte[] realText)
		{
			MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            byte[] keyhash = hashmd5.ComputeHash(realText);
            hashmd5.Dispose();
            hashmd5 = null;
            return keyhash;
		}


		/// <summary>
		/// 使用给定密钥加密
		/// </summary>
        /// <param name="realText">明文</param>
		/// <param name="key">密钥</param>
		/// <returns>密文</returns>
        public static byte[] Encrypt(byte[] realText, byte[] key)  
		{  
			TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();       
			des.Key =  MakeMD5(key);
			des.Mode = CipherMode.ECB;
            return des.CreateEncryptor().TransformFinalBlock(realText, 0, realText.Length);     
		}  



		/// <summary>
		/// 使用给定密钥解密数据
		/// </summary>
        /// <param name="cipherText">密文</param>
		/// <param name="key">密钥</param>
		/// <returns>明文</returns>
        public static byte[] Decrypt(byte[] cipherText, byte[] key)  
		{  
			TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();  
			des.Key =  MakeMD5(key);    
			des.Mode = CipherMode.ECB;

            return des.CreateDecryptor().TransformFinalBlock(cipherText, 0, cipherText.Length);

		}  
  
		#endregion

		

		
	}
}
