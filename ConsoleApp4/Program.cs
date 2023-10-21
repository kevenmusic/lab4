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
                Console.WriteLine("Выберите задание:");
                Console.WriteLine("1. Найти слово, встречающееся в каждом предложении.");
                Console.WriteLine("2. Найти предложения без слова и с датой.");
                Console.WriteLine("3. Вывести введенные предложения."); // Добавлен пункт.
                Console.WriteLine("0. Выйти из программы.");

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
                        break;

                    case 2:
                        Console.WriteLine("Введите слово, которого не должно быть в предложениях:");
                        string wordToExclude = Console.ReadLine();

                        List<Sentence> sentencesWithDate = textProcessor.GetSentencesWithoutWordAndWithDate(wordToExclude);

                        if (sentencesWithDate.Count == 0)
                        {
                            Console.WriteLine("Нет предложений с датой и без указанного слова.");
                        }
                        else
                        {
                            Console.WriteLine("Предложения без заданного слова и с датой:");
                            foreach (var sentence in sentencesWithDate)
                            {
                                Console.WriteLine(sentence.ToString());
                            }
                        }
                        break;

                    case 3:
                        Console.WriteLine("Введенные предложения:");
                        foreach (var sentence in enteredSentences)
                        {
                            Console.WriteLine(sentence);
                        }
                        break;

                    case 0:
                        return;

                    default:
                        Console.WriteLine("Неправильный выбор.");
                        break;
                }
            }
        }
    }
}
