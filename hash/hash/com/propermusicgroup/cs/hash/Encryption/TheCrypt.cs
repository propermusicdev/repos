using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace com.propermusicgroup.cs.hash.Encryption
{
  public static class TheCrypt
  {

    public static string GetSHA1Base64_string(string s)
    {
      return GetSHA1Base64(Encoding.UTF8.GetBytes(s));
    }
    public static string GetSHA1Base64(byte[] bytes)
    {
      return Base64BytesEncode(GetSHA1(bytes));
    }

    public static byte[] GetSHA1(byte[] bytes)
    {

      return GetHashBytes(SHA1.Create(), bytes);


    }

    public static string Base64BytesEncode(byte[] bytes)
    {
      return Convert.ToBase64String(bytes);
    }


    public static string Base64Encode(string plainText)
    {
      var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
      return Convert.ToBase64String(plainTextBytes);
    }

    public static string Base64Decode(string base64EncodedData)
    {
      var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
      return Encoding.UTF8.GetString(base64EncodedBytes);
    }
    public static byte[] GetHashBytes(HashAlgorithm hashAlgorithm, byte[] input)
    {
      return hashAlgorithm.ComputeHash(input);
    }

    public static string GetHash(HashAlgorithm hashAlgorithm, string input)
    {

      // Convert the input string to a byte array and compute the hash.
      byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

      // Create a new Stringbuilder to collect the bytes
      // and create a string.
      var sBuilder = new StringBuilder();

      // Loop through each byte of the hashed data 
      // and format each one as a hexadecimal string.
      for (int i = 0; i < data.Length; i++)
      {
        sBuilder.Append(data[i].ToString("x2"));
      }

      // Return the hexadecimal string.
      return sBuilder.ToString();
    }
  }
}
