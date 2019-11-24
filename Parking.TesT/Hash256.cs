using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Parking.TesT
{
	public class Hash256
	{
		private static Random random = new Random();
		public Hash256()
		{ 
        }
		private string HashSHA256(string psw)
		{
			SHA256 sHA256hash = SHA256.Create();
			byte[] bytes = sHA256hash.ComputeHash(Encoding.UTF8.GetBytes(psw));
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < bytes.Length; i++)
			{
				builder.Append(bytes[i].ToString("x2"));
			}
			string hashPSW = builder.ToString();
			return hashPSW;
		}
		public string RandomCode()
		{
			const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, random.Next(8, 10))
			  .Select(s => s[random.Next(s.Length)]).ToArray());
		}
	}
}
