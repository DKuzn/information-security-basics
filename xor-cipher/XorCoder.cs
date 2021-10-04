using System;

namespace xor_cipher
{
    class XorCoder 
    {
        public string code(string str, int key) 
        {
            string codedString = "";
            for (int i = 0; i < str.Length; i++)
            {
                codedString += Convert.ToChar(str[i] ^ key);
            }
            return codedString;
        }
    }
}