using System.Collections.Generic;

namespace ClassLibrary4
{
    /// <summary>
    /// Класс для обработки текста и предложений.
    /// </summary>
    public class TextProcessor
    {
        /// <summary>
        /// Список предложений.
        /// </summary>
        public List<Sentence> Sentences { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса TextProcessor.
        /// </summary>
        public TextProcessor()
        {
            Sentences = new List<Sentence>();
        }

        /// <summary>
        /// Добавляет новое предложение в список предложений.
        /// </summary>
        /// <param name="content">Содержимое предложения.</param>
        public void AddSentence(string content)
        {
            Sentences.Add(new Sentence(content));
        }

        /// <summary>
        /// Возвращает список предложений, не содержащих указанное слово и имеющих дату.
        /// </summary>
        /// <param name="word">Слово, которое не должно встречаться в предложениях.</param>
        /// <returns>Список предложений, соответствующих условиям.</returns>
        public List<Sentence> GetSentencesWithoutWordAndWithDate(string word)
        {
            return Sentences.FindAll(sentence => !sentence.ContainsWord(word) && sentence.ContainsDate());
        }
    }
}
