using System;

namespace caesar_cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Copyright (c) 2021 Дмитрий Кузнецов. Licensed under MIT License.\n");
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            CaesarCoder coder = new CaesarCoder(alphabet);
            Console.WriteLine("Данная программа позволяет кодировать, декодировать и взламывать слова с помощью шифра Цезаря.");
            Console.WriteLine("Для кодирования слова введите положительный ключ, для декодирования -- отрицательный, а для взлома -- равный 0.");
            Console.WriteLine("Введите слово: ");
            string word = Console.ReadLine().ToLower();
            Console.WriteLine("Введите ключ: ");
            int key = Convert.ToInt32(Console.ReadLine());
            if (key != 0)
            {
                string newWord = coder.code(word, key);
                Console.WriteLine("Новое слово: ");
                Console.WriteLine(newWord);
            }
            else
            {
                Console.WriteLine("Возможные слова: ");
                coder.crack(word);
            }
        }
    }
}
