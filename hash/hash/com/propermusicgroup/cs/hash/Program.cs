using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using com.propermusicgroup.cs.hash.Encryption;


namespace com.propermusicgroup.cs.hash
{
  class Program
  {
    private static string createdTimestamp;
    private static string password;
    private static string outputPath;
    private static string nonce;
    static void Main(string[] args)
    {
      if (args.Length >= 3)
      {
        if (args.Length == 4)
        {
          nonce = args[3];
        } else
        {
          char c = (char)new Random().Next((int)'0', (int)'9');
          nonce = Guid.NewGuid().ToString().Replace('-', c);
          nonce = nonce.Substring(0, 16);
        }

        //Random random = new Random();
        //for (int i = 0; i < 4; i += 1)
        //{
        //  nonce += random.Next(1000, 9999).ToString();
        //}
        //Console.WriteLine(nonce);
        createdTimestamp = args[0];
        password = args[1];
        outputPath = args[2];

        List<string> output = new List<string>();
        string pwd = TheCrypt.GetSHA1Base64_string(nonce + createdTimestamp + TheCrypt.GetSHA1Base64_string(password));
        //Console.WriteLine(pwd + " length:" + pwd.Length);

        output.Add("timestamp\t" + createdTimestamp);
        output.Add("outputPath\t" + outputPath);
        output.Add("base64Nonce\t" + TheCrypt.Base64Encode(nonce));
          
        output.Add("nonce\t" + nonce);
        output.Add("digest\t" + pwd);
        //foreach(string s in  output)
        //{
        //  Console.WriteLine(s);
        //}
        WriteToFile(output);
        
      }
      //Console.ReadLine();

      

    }
    public static void WriteToFile(List<string> lines)
    {
      File.WriteAllLines(outputPath, lines);

  }

  }


}
