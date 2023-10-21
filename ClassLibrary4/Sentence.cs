using System.Text;
using System.Text.RegularExpressions;

namespace ClassLibrary4
{
    /// <summary>
    /// Представляет предложение и предоставляет методы для анализа его содержимого.
    /// </summary>
    public class Sentence
    {
        /// <summary>
        /// Содержимое предложения.
        /// </summary>
        public StringBuilder Content { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса Sentence с указанным содержимым.
        /// </summary>
        /// <param name="content">Содержимое предложения.</param>
        public Sentence(string content)
        {
            Content = new StringBuilder(content);
        }

        /// <summary>
        /// Проверяет, содержит ли предложение указанное слово.
        /// </summary>
        /// <param name="word">Слово для поиска.</param>
        /// <returns>True, если слово найдено; в противном случае - False.</returns>
        public bool ContainsWord(string word)
        {
            string pattern = $@"\b{Regex.Escape(word)}\b";
            return Regex.IsMatch(Content.ToString(), pattern, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Проверяет, содержит ли предложение дату в формате dd.mm.yyyy, dd/mm/yyyy или dd.mm.yy.
        /// </summary>
        /// <returns>True, если дата найдена; в противном случае - False.</returns>
        public bool ContainsDate()
        {
            string pattern = @"(\d{2}[./]\d{2}[./]\d{4})";
            return Regex.IsMatch(Content.ToString(), pattern);
        }

        /// <summary>
        /// Возвращает строковое представление предложения.
        /// </summary>
        /// <returns>Строковое представление предложения.</returns>
        public override string ToString()
        {
            return Content.ToString();
        }
    }
}
