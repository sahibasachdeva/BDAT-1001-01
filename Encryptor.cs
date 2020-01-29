using System;
using System.Collections.Generic;
using System.Text;

namespace Converter.Models
{
    /// <summary>
    /// Provides Simple Encryption of text
    /// </summary>
    class Encrypter
    {
        public string OriginalText { get; internal set; }
        public int[] EncryptionCipher { get; } = new[] { 1, 1, 2, 3, 5, 8 }; //Fibonacci Sequence
        public int EncryptionDepth { get; } = 1;
        public string CipherEncrypted { get; internal set; }
        public string Base64 { get; internal set; }
        public string Binary { get; internal set; }
        public string Hexadecimal { get; internal set; }  

        //public char  { get; internal set; } 
        public string HexaToString { get; internal set; }


      static  int[] positionvalues = { 128, 64, 32, 16, 8, 4, 2, 1 };

        public Encrypter(string originalText, int[] encryptionCipher = null, int encryptionDepth = 1)
        {
            OriginalText = originalText;

            if (encryptionCipher != null)
            {
                if (EncryptionCipher != encryptionCipher)
                {
                    EncryptionCipher = encryptionCipher;
                }
            }

            if (EncryptionDepth != encryptionDepth)
            {
                EncryptionDepth = encryptionDepth;
            }

            ConvertText(OriginalText, EncryptionCipher, EncryptionDepth);
        }

        public void ConvertText(string originalText, int[] encryptionCipher = null, int encryptionDepth = 1)
        {
            //Deep Cipher encrypt
            CipherEncrypted = DeepEncryptWithCipher(OriginalText, EncryptionCipher, EncryptionDepth);

            //Convert Original Text to other base formats
            Base64 = StringToBase64(OriginalText);
            Binary = StringToBinary(OriginalText);
            Hexadecimal = StringToHex(OriginalText);           
            //BinaryToString = ConvertToASCII(OriginalText);

            
        }
        
        public static string DeepEncryptWithCipher(string originalText, int[] encryptionCipher, int encryptionDepth)
        {
            string result = originalText;

            //For demonstration
            //string[] encryptedValues = new string[encryptionDepth + 1];
            //encryptedValues[0] = result;

            //Encrypt result encryptionDepth times
            for (int depth = 0; depth < encryptionDepth; depth++)
            {
                //Apply Encryption Cipher on current value of result
                result = EncryptWithCipher(result, encryptionCipher);

                //Add new encrypted result to the encrypted array fro demonstration
                //encryptedValues[depth + 1] = result;
            }

            return result;
        }

        /// <summary>
        /// Applies a Cipher to a string
        /// </summary>
        /// <param name="text">Text to encrypt</param>
        /// <param name="encryptionCipher">new[] { 1,2,3,4,5,6 }</param>
        /// <returns></returns>
        public static string EncryptWithCipher(string text, int[] encryptionCipher)
        {
            if (encryptionCipher == null || encryptionCipher.Length == 0)
            {
                return text;
            }

            //Store the original string converted to bytes
            //Convert the text data to Unicode byte in order to handle non ASCII value character
            byte[] bytearray = Encoding.Unicode.GetBytes(text);

            //Build byte array from the original byte array that will receive the encrypted values
            byte[] bytearrayresult = bytearray;

            int encryptionCipherIndex = 0;

            //Apply Encryption Cipher
            for (int i = 0; i < bytearray.Length; i++)
            {
                //Set the Cipher index
                encryptionCipherIndex = i;

                //We reset the current encryption position to 0 to restart at the beginning of the encryptionCipher
                if (encryptionCipherIndex >= encryptionCipher.Length)
                {
                    //Reset the cryper postion to zero and restart sequence
                    encryptionCipherIndex = 0;
                }

                //These lines are for demonstration to show values
                //byte bytecharacter = bytearray[i];
                //int CipherChar = encryptionCipher[encryptionCipherIndex];

                //Change the value of the current character by the values received from the encryptionCipher array
                //int newchar = bytearray[i] + encryptionCipher[encryptionCipherIndex];

                //Change the value of the current character by the values received from the encryptionCipher array
                if (bytearray[i] != 0)
                {
                    bytearrayresult[i] = (byte)(bytearray[i] + encryptionCipher[encryptionCipherIndex]);
                }
            }

            string newresult = Encoding.Unicode.GetString(bytearrayresult);

            return newresult;
        }

        /// <summary>
        /// Decrypts a deep cipher encrypted string
        /// </summary>
        /// <param name="originalText">Cipher encrypted string</param>
        /// <param name="encryptionCipher">Sequence of whole numbers in an array</param>
        /// <param name="encryptionDepth">Depth of the encryption</param>
        /// <returns>Decrypted string</returns>
        public static string DeepDecryptWithCipher(string originalText, int[] encryptionCipher, int encryptionDepth)
        {
            string result = originalText;

            //For demonstration
            string[] encryptedValues = new string[encryptionDepth + 1];
            encryptedValues[0] = result;

            //Encrypt result encryptionDepth times
            for (int depth = 0; depth < encryptionDepth; depth++)
            {
                //Apply Encryption Cipher on current value of result
                result = DecryptWithCipher(result, encryptionCipher);

                //Add new encrypted result to the encrypted array fro demonstration
                encryptedValues[depth + 1] = result;
            }

            return result;
        }

        /// <summary>
        /// Decrypts a cipher encrypted string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="encryptionCipher"></param>
        /// <returns></returns>
        public static string DecryptWithCipher(string text, int[] encryptionCipher)
        {
            //Convert the text data to Unicode byte in order to handle non ASCII value character
            byte[] bytearray = Encoding.Unicode.GetBytes(text);
            //Build byte array from the original byte array that will receive the encrypted values
            byte[] bytearrayresult = bytearray;

            int encryptionCipherIndex = 0;

            for (int i = 0; i < bytearray.Length; i++)
            {
                //Set the Cipher index
                encryptionCipherIndex = i;

                //We reset the current encryption position to 0 to restart at the beginning of the encryptionCipher
                if (encryptionCipherIndex >= encryptionCipher.Length)
                {
                    //Reset the cryper postion to zero and restart sequence
                    encryptionCipherIndex = 0;
                }

                if (bytearray[i] != 0)
                {
                    bytearrayresult[i] = (byte)(bytearray[i] - encryptionCipher[encryptionCipherIndex]);
                }
            }

            string newresult = Encoding.Unicode.GetString(bytearrayresult);

            return newresult;
        }

        /// <summary>
        /// Converts a Unicode Base64 string to decoded String
        /// </summary>
        /// <param name="base64String">Unicode Base64 encoded string</param>
        /// <returns>Decoded String from Base64</returns>
        public static string Base64ToString(string data)
        {
            if (String.IsNullOrEmpty(data))
            {
                return String.Empty;
            }

            byte[] bytearray = Convert.FromBase64String(data);

            return Encoding.Unicode.GetString(bytearray);
        }

        /// <summary>
        /// Encodes a String to a Base64 String
        /// </summary>
        /// <param name="data">String data</param>
        /// <returns>Base64 Encoded String</returns>
        public static string StringToBase64(string data)
        {
            byte[] bytearray = Encoding.Unicode.GetBytes(data);

            return Convert.ToBase64String(bytearray);
        }

        /// <summary>
        /// A less mathmatical approach to ASCII to Hexadecimal conversion
        /// </summary>
        /// <param name="data">String to convert</param>
        /// <returns></returns>
        public static string StringToHex(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                //Convert the char to base 16 and pad the output with 0
                sb.Append(Convert.ToString(c, 16).PadLeft(2, '0') + " ");
            }

            return sb.ToString().ToUpper();
        }

        /// <summary>
        /// A less mathmatical approach to ASCII to Binary conversion
        /// https://www.fluxbytes.com/csharp/convert-string-to-binary-and-binary-to-string-in-c/
        /// </summary>
        /// <param name="data">String to convert</param>
        /// <returns></returns>
        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                //Convert the char to base 2 and pad the output with 0
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0') + " ");
            }
            return sb.ToString();
        }

        public static string ConvertToASCII(string binaryvalue)
        {
            binaryvalue = binaryvalue.Replace(" ","");
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < binaryvalue.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(binaryvalue.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        

        }

        public static string ConvertHexToASCII(string hexa)
        {
            string res = String.Empty;
            hexa = hexa.Replace(" ", "");
            for (int a = 0; a < hexa.Length; a = a + 2)
            {

                string Char2Convert = hexa.Substring(a, 2);
                int n = Convert.ToInt32(Char2Convert, 16);
                char c = (char)n;
                res += c.ToString();

            }

            return res;
        }
       
        



    }
}
