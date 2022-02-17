using System.Security.Cryptography;
using System.Text;


string BuildString(byte[] bytes)
{
    var sBuilder = new StringBuilder();
    foreach (byte b in bytes)
    {
        sBuilder.Append(b.ToString("x2"));
    }
    return sBuilder.ToString();
}

string ComputeHash(string text, HashAlgorithm algorithm)
{
    byte[] hash = algorithm.ComputeHash(Encoding.Unicode.GetBytes(text));
    return BuildString(hash);
}

void PrintResult(string hashName, string hashValue)
{
    Console.WriteLine($"Слово, закодированное с помощью хэш-функции {hashName} - {hashValue}");
}

void Main()
{
    Console.WriteLine("Copyright (c) 2022 Дмитрий Кузнецов. Licensed under MIT License.\n");
    Console.WriteLine("Данная программа позволяет кодировать слова с помощью разных хэш-функций.");
    Console.WriteLine("Введите слово: ");
    string word = Console.ReadLine();
    PrintResult("MD5", ComputeHash(word, MD5.Create()));
    PrintResult("SHA1", ComputeHash(word, SHA1.Create()));
    PrintResult("SHA256", ComputeHash(word, SHA256.Create()));
    PrintResult("SHA384", ComputeHash(word, SHA384.Create()));
    PrintResult("SHA512", ComputeHash(word, SHA512.Create()));
}

Main();