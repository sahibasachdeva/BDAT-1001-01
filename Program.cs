using Converter.Models;

using System;
using System.Linq;

namespace Jan28
{
    class Program
    {
        static void Main(string[] args)
        {
          
            int[] cipher = new[] { 1, 1, 2, 3, 5, 8, 13 }; //Fibonacci Sequence
            string cipherasString = String.Join(",", cipher.Select(x => x.ToString())); //FOr display
            Console.WriteLine("Enter the name for string to binary conversion ");
            var name = Console.ReadLine();
            int encryptionDepth = 20;
            Encrypter encrypter = new Encrypter(name, cipher, encryptionDepth);       
         
            //String to binary with user input
            var nameToBinary = encrypter.Binary;
            Console.WriteLine($"{name} in binary is {nameToBinary}");

            //Binary to ASCII
            //Console.WriteLine("Enter the binary value for conversion");
            //var binary = Console.ReadLine();
            //var binaryToName = Encrypter.ConvertToASCII(binary);
            
            var binaryToName = Encrypter.ConvertToASCII(nameToBinary);
            Console.WriteLine($"{nameToBinary} in ASCII format is {binaryToName} ");

            //String to Hexadecimal
            var nameToHexa = encrypter.Hexadecimal;
            Console.WriteLine($"{name} in hexadecimal format is {nameToHexa}");

            //Hexa to ASCII
            //Console.WriteLine("Enter the hexadecimal value for conversion");
            //var hexa = Console.ReadLine();
            var hexaToName = Encrypter.ConvertHexToASCII(nameToHexa);
            Console.WriteLine($"{nameToHexa} in ASCII is {hexaToName}");

            //Base64 Encoded
            Console.WriteLine($"Base64 encoded {name} {encrypter.Base64}");

            //Base64 Decoded
            string base64toPlainText = Encrypter.Base64ToString(encrypter.Base64);
            Console.WriteLine($"Base64 decoded {encrypter.Base64} {base64toPlainText}");

            //Deep Encryption
            string nameDeepEncryptWithCipher = Encrypter.DeepEncryptWithCipher(name, cipher, encryptionDepth);
            Console.WriteLine($"Deep Encrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepEncryptWithCipher}");
            
            //Deep Decryption
            string nameDeepDecryptWithCipher = Encrypter.DeepDecryptWithCipher(name, cipher, encryptionDepth);
            Console.WriteLine($"Deep Decrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepDecryptWithCipher}");

           

         

        }
    }
}
