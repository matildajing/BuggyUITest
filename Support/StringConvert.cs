using System;
namespace BuggyUITest.Support
{
    public class StringConvert
    {
        public StringConvert()
        {
        }

        public static bool StringToBool(string value)
        {
            if (value.ToLower().Equals("true"))
                return true;
            else if (value.ToLower().Equals("false"))
                return false;
            else
            {
                throw new FormatException("not a effect bool value");
            }
      
        }

        public static string GetRandomString(int length, bool useNum, bool useLow, bool useUpp, bool useSpe, string custom)
        {
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null, str = custom;
            if (useNum == true) {
                string sNum = "0123456789";
                str += sNum;
                s += str.Substring(r.Next(0, sNum.Length - 1), 1);
                length--;
            }
            if (useLow == true) {
                string sFeed = "abcdefghijklmnopqrstuvwxyz";
                str += sFeed;
                s += str.Substring(r.Next(0, sFeed.Length - 1), 1);
                length--;

            }
            if (useUpp == true) {
                string sFeed = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                str += sFeed;
                s += str.Substring(r.Next(0, sFeed.Length - 1), 1);
                length--;
            }
            if (useSpe == true) {
                string sFeed = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
                str += sFeed;
                s += str.Substring(r.Next(0, sFeed.Length - 1), 1);
                length--;
            }
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
        }
    }
}
