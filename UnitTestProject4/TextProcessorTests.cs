using ClassLibrary4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject4
{
    [TestClass]
    public class TextProcessorTests
    {
        [TestMethod]
        public void AddSentence_Test()
        {
            // Arrange
            TextProcessor textProcessor = new TextProcessor();

            // Act
            textProcessor.AddSentence("Это пример предложения.");

            // Assert
            Assert.AreEqual(1, textProcessor.Sentences.Count);
        }

        [TestMethod]
        public void GetSentencesWithoutWordAndWithDate_Test()
        {
            // Arrange
            TextProcessor textProcessor = new TextProcessor();
            textProcessor.AddSentence("Это пример предложения с датой 10/21/2023.");
            textProcessor.AddSentence("В этом предложении нет даты.");
            textProcessor.AddSentence("Другое предложение с датой 11.15.2023.");

            // Act
            List<Sentence> sentences = textProcessor.GetSentencesWithoutWordAndWithDate("пример");

            // Assert
            Assert.AreEqual(1, sentences.Count);
        }
    }
}
