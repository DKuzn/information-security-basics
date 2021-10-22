using System;
using System.IO;

namespace file_xor_cipher
{
    class FileXorCoder 
    {
        private string code(string str, int key) 
        {
            string codedString = "";
            for (int i = 0; i < str.Length; i++)
            {
                codedString += Convert.ToChar(str[i] ^ key);
            }
            return codedString;
        }

        private string openFile(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open);
            StreamReader strReader = new StreamReader(file);
            string text = strReader.ReadToEnd();
            strReader.Close();
            file.Close();
            return text;
        }

        private void saveFile(string text, string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            StreamWriter strWriter = new StreamWriter(file);
            strWriter.Write(text);
            strWriter.Close();
        }

        public void codeFile(string path, int key)
        {
            string fileText = openFile(path);
            string codedText = code(fileText, key);
            saveFile(codedText, path);
        }
    }
}
