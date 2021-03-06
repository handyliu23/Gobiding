using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Maticsoft.Common
{
    /// <summary>
    /// Summary description for DES.
    /// </summary>
    public class CryptoUtil
    {
        private static byte[] key_64 = { 181, 44, 181, 40, 46, 168, 244, 49 };
        private static byte[] iv_64 = { 107, 93, 249, 77, 56, 159, 62, 251 };

        private static byte[] key_192 = { 241, 209, 75, 4, 138, 97, 142, 47, 78, 169, 86, 189, 65, 250, 87, 72, 173, 14, 72, 20, 155, 215, 36, 139 };
        private static byte[] iv_192 = { 128, 19, 107, 127, 217, 148, 105, 0 };

        private static byte[] key_192diy = { 241, 209, 75, 4, 138, 97, 143, 56, 78, 169, 86, 189, 65, 250, 87, 72, 173, 14, 72, 20, 155, 215, 36, 139 };
        private static byte[] iv_192diy = { 128, 19, 107, 127, 213, 141, 105, 0 };


        private static byte[] key_192_somaster = { 45, 234, 56, 8, 9, 3, 34, 77, 232, 169, 188, 192, 7, 254, 36, 2, 7, 154, 67, 84, 133, 166, 76, 89 };
        private static byte[] iv_192_somaster = { 2, 12, 14, 233, 17, 48, 51, 63 };

        public static string Encrypt(string str)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            //把字符串放到byte数组中  
            byte[] inputByteArray = Encoding.Unicode.GetBytes(str);

            //建立加密对象的密钥和偏移量  
            des.Key = key_64;
            des.IV = iv_64;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            //Write  the  byte  array  into  the  crypto  stream  
            //(It  will  end  up  in  the  memory  stream)  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            //Get  the  data  back  from  the  memory  stream,  and  into  a  string  
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                //Format  as  hex  
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        public static string Decrypt(string str)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            //Put  the  input  string  into  the  byte  array  
            byte[] inputByteArray = new byte[str.Length / 2];
            for (int x = 0; x < str.Length / 2; x++)
            {
                int i = (Convert.ToInt32(str.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            //建立加密对象的密钥和偏移量，此值重要，不能修改  
            des.Key = key_64;
            des.IV = iv_64;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            //Flush  the  data  through  the  crypto  stream  into  the  memory  stream  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            return Encoding.Unicode.GetString(ms.ToArray());
        }

        public static string EncryptTripleDES(string str)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            //把字符串放到byte数组中  
            byte[] inputByteArray = Encoding.Unicode.GetBytes(str);

            //建立加密对象的密钥和偏移量  
            des.Key = key_192;
            des.IV = iv_192;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            //Write  the  byte  array  into  the  crypto  stream  
            //(It  will  end  up  in  the  memory  stream)  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            //Get  the  data  back  from  the  memory  stream,  and  into  a  string  
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                //Format  as  hex  
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        public static string DecryptTripleDES(string str)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();

            //Put  the  input  string  into  the  byte  array  
            byte[] inputByteArray = new byte[str.Length / 2];
            for (int x = 0; x < str.Length / 2; x++)
            {
                int i = (Convert.ToInt32(str.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            //建立加密对象的密钥和偏移量，此值重要，不能修改  
            des.Key = key_192;
            des.IV = iv_192;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            //Flush  the  data  through  the  crypto  stream  into  the  memory  stream  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            return Encoding.Unicode.GetString(ms.ToArray());
        }


        public static string EncryptTripleDES_SOMaster(string str)
        {
            if (str.Length == 0)
                return str;
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            //把字符串放到byte数组中  
            byte[] inputByteArray = Encoding.Unicode.GetBytes(str);

            //建立加密对象的密钥和偏移量  
            des.Key = key_192_somaster;
            des.IV = iv_192_somaster;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            //Write  the  byte  array  into  the  crypto  stream  
            //(It  will  end  up  in  the  memory  stream)  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            //Get  the  data  back  from  the  memory  stream,  and  into  a  string  
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                //Format  as  hex  
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        public static string DecryptTripleDES_SOMaster(string str)
        {
            if (str.Length == 0)
                return str;
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();

            //Put  the  input  string  into  the  byte  array  
            byte[] inputByteArray = new byte[str.Length / 2];
            for (int x = 0; x < str.Length / 2; x++)
            {
                int i = (Convert.ToInt32(str.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            //建立加密对象的密钥和偏移量，此值重要，不能修改  
            des.Key = key_192_somaster;
            des.IV = iv_192_somaster;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            //Flush  the  data  through  the  crypto  stream  into  the  memory  stream  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            return Encoding.Unicode.GetString(ms.ToArray());
        }

        public static string ShowFuzzyCardNumber(string cardNumber)
        {
            const string starchar = "***********************************";
            if (cardNumber.Length <= 5 || new Regex("[^0-9]").Match(cardNumber).Success)
            {
                cardNumber = string.Empty;
            }
            else
            {
                cardNumber = cardNumber.Substring(0, 1) + starchar.Substring(0, cardNumber.Length - 5) +
                             cardNumber.Substring(cardNumber.Length - 4, 4);
            }
            return cardNumber;
        }

        //将卡号变为*1234的样子显示
        public static string ShowCardNumberLastFourNumbers(string cardNumber)
        {
            if (cardNumber.Length < 4)
            {
                cardNumber = string.Empty;
            }
            else
            {
                cardNumber = "*" + cardNumber.Substring(cardNumber.Length - 4, 4);
            }
            return cardNumber;
        }

        public static string ShowFuzzyCvv2Number(string cvv2Number)
        {
            string fuzzyCvv2 = "";
            if (cvv2Number.Length > 0)
            {
                for (int i = 0; i < cvv2Number.Length; i++)
                {
                    fuzzyCvv2 += "*";
                }
            }
            else
            {
                fuzzyCvv2 = "";
            }
            return fuzzyCvv2;
        }

        public static string EncryptTripleDESForDIY(string str)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            //把字符串放到byte数组中  
            byte[] inputByteArray = Encoding.Unicode.GetBytes(str);

            //建立加密对象的密钥和偏移量  
            des.Key = key_192diy;
            des.IV = iv_192diy;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            //Write  the  byte  array  into  the  crypto  stream  
            //(It  will  end  up  in  the  memory  stream)  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            //Get  the  data  back  from  the  memory  stream,  and  into  a  string  
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                //Format  as  hex  
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        public static string DecryptTripleDESForDIY(string str)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();

            //Put  the  input  string  into  the  byte  array  
            byte[] inputByteArray = new byte[str.Length / 2];
            for (int x = 0; x < str.Length / 2; x++)
            {
                int i = (Convert.ToInt32(str.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            //建立加密对象的密钥和偏移量，此值重要，不能修改  
            des.Key = key_192diy;
            des.IV = iv_192diy;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            //Flush  the  data  through  the  crypto  stream  into  the  memory  stream  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            return Encoding.Unicode.GetString(ms.ToArray());
        }

        public static string HideCardNumber(string cardNumber)
        {
            if (cardNumber.Length <= 5 || new Regex("[^0-9]").Match(cardNumber).Success) return string.Empty;
            return "*" + cardNumber.Substring(cardNumber.Length - 4, 4);
        }

        public static string HideCardNumber5(string cardNumber)
        {
            if (cardNumber.Length <= 5 || new Regex("[^0-9]").Match(cardNumber).Success) return string.Empty;
            return cardNumber.Substring(0, 1) + new string('*', cardNumber.Length - 5) + cardNumber.Substring(cardNumber.Length - 4, 4);
        }
    }
}
