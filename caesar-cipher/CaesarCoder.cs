using System;

namespace caesar_cipher
{
    class CaesarCoder 
    {
        private string _alphabet;
        private int _maxKeyLen;

        public CaesarCoder(string alphabet) 
        {
            this._alphabet = alphabet;
            this._maxKeyLen = alphabet.Length;
        }

        public string code(string str, int key) 
        {
            if (Math.Abs(key) > _maxKeyLen)
            {
                return str;
            } 
            else
            {
                string codedString = "";
                for (int i = 0; i < str.Length; i++)
                {
                    int symbolIndex = _alphabet.IndexOf(str[i]);
                    symbolIndex += key;
                    if (symbolIndex >= _alphabet.Length)
                    {
                        symbolIndex -= _alphabet.Length;
                    }
                    else if (symbolIndex < 0)
                    {
                        symbolIndex += _alphabet.Length;
                    }
                    codedString += _alphabet[symbolIndex];
                }
                return codedString;
            }
        }

        public void crack(string str)
        {
            for (int i = 1; i < _maxKeyLen; i++)
            {
                Console.WriteLine(this.code(str, -i));
            }
        }
    }
}