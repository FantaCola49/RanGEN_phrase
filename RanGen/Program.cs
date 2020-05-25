using System;
using System.Text;

namespace RanGen
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("\t\tВнимание! Сейчас будет выведена случайная комбинация букв!");
                Execute();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        public static void Execute()
        {
            var exitProgram = false;
            while (!exitProgram)
            {
                Console.Write("Использовать стандартные настройки? (только цифры и числа) y/n ");
                var defaultSettings = Console.ReadKey().Key == ConsoleKey.Y;
                Console.WriteLine();

                bool withDigits = true;
                bool withLetters = true;
                bool withSpecialChars = false;
                bool dropFile = false;
                int randomSize = 16;

                if (!defaultSettings)
                {
                    Console.Write("Включить цифры? y/n ");
                    withDigits = Console.ReadKey().Key == ConsoleKey.Y;
                    Console.WriteLine();

                    Console.Write("Включить буквы? y/n ");
                    withLetters = Console.ReadKey().Key == ConsoleKey.Y;
                    Console.WriteLine();

                    Console.Write("Включить специальные знаки? y/n ");
                    withSpecialChars = Console.ReadKey().Key == ConsoleKey.Y;
                    Console.WriteLine();

                    Console.Write("Вы хотите создать файл с содержимым? y/n");
                    dropFile = Console.ReadKey().Key == ConsoleKey.Y;
                    Console.WriteLine();

                    Console.Write("Введите объём текста: ");
                    if (!int.TryParse(Console.ReadLine(), out int randSize))
                    {
                        Console.WriteLine("Неверное число!");
                        Execute();
                    }
                    randomSize = randSize;
                }

                bool generate = true;
                while (generate)
                {
                    var randWord = CreateRandom(randomSize, withDigits, withLetters, withSpecialChars);
                    Console.WriteLine(randWord);

                    Console.WriteLine();
                    Console.Write("Ещё? y/n ");
                    generate = Console.ReadKey().Key == ConsoleKey.Y;
                    Console.WriteLine();
                }

                Console.Write("Выйти? y/n ");
                exitProgram = Console.ReadKey().Key == ConsoleKey.Y;
                Console.WriteLine();
            }
        }

        private static string CreateRandom(int length, bool withDigits, bool withLetters, bool withSpecialChars)
        {
            const string digits = "1234567890";
            const string letters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            const string specialChars = "!@#$%^&*(){}";

            var chars = (withDigits ? digits : string.Empty) +
                        (withLetters ? letters : string.Empty) +
                        (withSpecialChars ? specialChars : string.Empty);


            var res = new StringBuilder();
            var rnd = new Random();

            while (0 < length--)
            {
                res.Append(chars[rnd.Next(chars.Length)]);
            }

            return res.ToString();
        }


    }
}
