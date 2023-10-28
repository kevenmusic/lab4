namespace ClassLibrary4
{
    /// <summary>
    /// Класс для обработки текста и предложений.
    /// </summary>
    public class TextProcessor
    {
        /// <summary>
        /// Массив предложений.
        /// </summary>
        public Sentence[] Sentences { get; set; }

        /// <summary>
        /// Количество предложений в массиве.
        /// </summary>
        public int SentenceCount { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса TextProcessor.
        /// </summary>
        public TextProcessor()
        {
            Sentences = new Sentence[0]; // Инициализация пустого массива.
            SentenceCount = 0;
        }

        /// <summary>
        /// Добавляет новое предложение в массив предложений.
        /// </summary>
        /// <param name="content">Содержимое предложения.</param>
        public void AddSentence(string content)
        {
            // Создаем новый массив с увеличенным размером и копируем старые элементы.
            Sentence[] newSentences = new Sentence[SentenceCount + 1];
            for (int i = 0; i < SentenceCount; i++)
            {
                newSentences[i] = Sentences[i];
            }
            newSentences[SentenceCount] = new Sentence(content);

            Sentences = newSentences; // Присваиваем новый массив полю Sentences.
            SentenceCount++;
        }

        /// <summary>
        /// Возвращает массив предложений, не содержащих указанное слово и имеющих дату.
        /// </summary>
        /// <param name="word">Слово, которое не должно встречаться в предложениях.</param>
        /// <returns>Массив предложений, соответствующих условиям.</returns>
        public Sentence[] GetSentencesWithoutWordAndWithDate(string word)
        {
            Sentence[] result = new Sentence[SentenceCount];
            int resultCount = 0;

            foreach (Sentence sentence in Sentences)
            {
                if (!sentence.ContainsWord(word) && sentence.ContainsDate())
                {
                    result[resultCount] = sentence;
                    resultCount++;
                }
            }

            // Создаем новый массив с точным размером результата.
            Sentence[] finalResult = new Sentence[resultCount];
            for (int i = 0; i < resultCount; i++)
            {
                finalResult[i] = result[i];
            }

            return finalResult;
        }
    }
}
