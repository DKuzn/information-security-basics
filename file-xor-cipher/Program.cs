using System;
using System.IO;

namespace file_xor_cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Copyright (c) 2021 Дмитрий Кузнецов. Licensed under MIT License.\n");
            FileXorCoder coder = new FileXorCoder();
            Console.WriteLine("Данная программа позволяет кодировать и декодировать текстовые файлы с помощью XOR.");
            Console.WriteLine("Для кодирования и декодирования файла введите положительный ключ.");
            Console.WriteLine("Введите путь к файлу: ");
            string path = Console.ReadLine();
            if (File.Exists(path))
            {             
                Console.WriteLine("Введите ключ: ");
                int key = Convert.ToInt32(Console.ReadLine());
                if (key > 0)
                {
                    coder.codeFile(path, key);
                    Console.WriteLine("Содержимое файла перезаписано.");
                }
                else
                {
                    Console.WriteLine("Ключ неверен.");
                }
            }
            else
            {
                Console.WriteLine("Путь к файлу неверен.");
            }
        }
    }
}
