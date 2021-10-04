using System;

namespace xor_cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Copyright (c) 2021 Дмитрий Кузнецов. Licensed under MIT License.\n");
            XorCoder coder = new XorCoder();
            Console.WriteLine("Данная программа позволяет кодировать и декодировать слова с помощью XOR.");
            Console.WriteLine("Для кодирования и декодирования слова введите положительный ключ.");
            Console.WriteLine("Введите слово: ");
            string word = Console.ReadLine().ToLower();
            Console.WriteLine("Введите ключ: ");
            int key = Convert.ToInt32(Console.ReadLine());
            if (key > 0)
            {
                string newWord = coder.code(word, key);
                Console.WriteLine("Новое слово: ");
                Console.WriteLine(newWord);
            }
            else
            {
                Console.WriteLine("Ключ неверен.");
            }
        }
    }
}
