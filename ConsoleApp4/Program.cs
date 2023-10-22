using System;
using System.Linq;
using System.Collections.Generic;
using ClassLibrary4;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextProcessor textProcessor = new TextProcessor();
            List<string> enteredSentences = new List<string>(); // Добавлен список для хранения введенных предложений.

            // Запрашиваем количество предложений
            Console.WriteLine("Введите количество предложений:");
            int numSentences = int.Parse(Console.ReadLine());

            // Запрашиваем и сохраняем предложения
            for (int i = 0; i < numSentences; i++)
            {
                Console.WriteLine($"Введите предложение {i + 1}:");
                string sentence = Console.ReadLine();
                textProcessor.AddSentence(sentence);
                enteredSentences.Add(sentence); // Сохраняем введенные предложения в список.
            }

            int choice = 0;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("|==============================================|");
                Console.WriteLine("|          Добро пожаловать в программу        |");
                Console.WriteLine("|           Обработка текстовых данных         |");
                Console.WriteLine("|==============================================|");
                Console.WriteLine("|               Выберите задание:              |");
                Console.WriteLine("|    1. Найти слово, встречающееся в каждом    |");
                Console.WriteLine("|                 предложении.                 |");
                Console.WriteLine("|   2. Найти предложения без слова и с датой.  |");
                Console.WriteLine("|       3. Вывести введенные предложения.      |");
                Console.WriteLine("|            0. Выйти из программы.            |");
                Console.WriteLine("|==============================================|");


                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный формат ввода. Пожалуйста, введите число.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        PrintEnteredSentences(enteredSentences);
                        Console.WriteLine("Введите слово для поиска:");
                        string wordToFind = Console.ReadLine();
                        bool wordFoundInAll = textProcessor.Sentences.TrueForAll(sentence => sentence.ContainsWord(wordToFind));
                        if (wordFoundInAll)
                        {
                            Console.WriteLine($"Слово '{wordToFind}' встречается во всех предложениях.");
                        }
                        else
                        {
                            Console.WriteLine($"Слово '{wordToFind}' не встречается во всех предложениях.");
                        }

                        Console.WriteLine("Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 2:
                        PrintEnteredSentences(enteredSentences);
                        Console.WriteLine("Введите слово, которого не должно быть в предложениях:");
                        string wordToExclude = Console.ReadLine();

                        List<Sentence> sentencesWithDate = textProcessor.GetSentencesWithoutWordAndWithDate(wordToExclude);

                        if (sentencesWithDate.Count == 0)
                        {
                            Console.WriteLine("Нет предложений с датой и без указанного слова.");
                        }
                        else
                        {
                            PrintEnteredSentencesWithDate(sentencesWithDate);
                        }

                        Console.WriteLine("Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 3:
                        PrintEnteredSentences(enteredSentences);

                        Console.WriteLine("Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 0:
                        return;

                    default:
                        Console.WriteLine("Неправильный выбор.");
                        break;
                }

            }
        }
        private static void PrintEnteredSentences(List<string> sentences)
        {
            Console.WriteLine();
            Console.WriteLine("|===============================================|");
            Console.WriteLine("|             Введенные предложения             |");
            Console.WriteLine("|===============================================|");

            for (int i = 0; i < sentences.Count; i++)
            {
                Console.WriteLine($"|Предложение {i + 1}: {sentences[i]}");
            }

            Console.WriteLine("|===============================================|");
            Console.WriteLine();
        }

        private static void PrintEnteredSentencesWithDate(List<Sentence> sentences)
        {
            Console.WriteLine();
            Console.WriteLine("|===============================================|");
            Console.WriteLine("|   Предложения без заданного слова и с датой   |");
            Console.WriteLine("|===============================================|");

            for (int i = 0; i < sentences.Count; i++)
            {
                Console.WriteLine($"|Предложение {i + 1}: {sentences[i]}");
            }

            Console.WriteLine("|===============================================|");
            Console.WriteLine();
        }
    }
}
