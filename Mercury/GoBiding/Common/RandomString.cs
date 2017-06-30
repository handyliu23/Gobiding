using System;
using System.Security.Cryptography;

namespace Maticsoft.Common
{
    /// <summary>
    /// Ëæ»úÃÜÂë
    /// </summary>
    public sealed class RandomString
    {
        public static int GetNewSeed()
        {
            byte[] rndBytes = new byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(rndBytes);
            return BitConverter.ToInt32(rndBytes, 0);
        }

        /********
         *  getRndCode of all char .
         *  ********/

        private static string BuildRndCodeAll(int strLen)
        {
            System.Random RandomObj = new System.Random(GetNewSeed());
            string buildRndCodeReturn = null;
            for (int i = 0; i < strLen; i++)
            {
                buildRndCodeReturn += (char)RandomObj.Next(33, 125);
            }
            return buildRndCodeReturn;
        }

        /********
         *  getRndCode for Special Use .
         *  ********/

        private static string sCharLow = "abcdefghijklmnopqrstuvwxyz";
        private static string sCharUpp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string sNumber = "0123456789";

        private static string BuildRndCodeOnly(string StrOf, int strLen)
        {
            System.Random RandomObj = new System.Random(GetNewSeed());
            string buildRndCodeReturn = null;
            for (int i = 0; i < strLen; i++)
            {
                buildRndCodeReturn += StrOf.Substring(RandomObj.Next(0, StrOf.Length - 1), 1);
            }
            return buildRndCodeReturn;
        }

        public static string GetRndInt(int LenOf)
        {
            return BuildRndCodeOnly(sNumber, LenOf);
        }

        public static string GetRndIntAndLetter(int strLen)
        {
            string StrOf = sCharLow + sCharUpp + sNumber;
            System.Random RandomObj = new System.Random(GetNewSeed());
            string buildRndCodeReturn = null;
            for (int i = 0; i < strLen; i++)
            {
                buildRndCodeReturn += StrOf.Substring(RandomObj.Next(0, StrOf.Length - 1), 1);
            }
            return buildRndCodeReturn;
        }
        public static string GetRndCharLow(int LenOf)
        {
            return BuildRndCodeOnly(sCharLow, LenOf);
        }
        public static string GetRndCharUpp(int LenOf)
        {
            return BuildRndCodeOnly(sCharUpp, LenOf);
        }
    }
}
