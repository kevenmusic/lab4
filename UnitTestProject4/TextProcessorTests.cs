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

        [TestMethod]
        public void AddMultipleSentences_Test()
        {
            // Arrange
            TextProcessor textProcessor = new TextProcessor();

            // Act
            textProcessor.AddSentence("Это первое предложение.");
            textProcessor.AddSentence("Это второе предложение.");

            // Assert
            Assert.AreEqual(2, textProcessor.Sentences.Count);
        }

        [TestMethod]
        public void SentencesListStartsEmpty_Test()
        {
            // Arrange
            TextProcessor textProcessor = new TextProcessor();

            // Act & Assert
            CollectionAssert.AreEqual(new List<Sentence>(), textProcessor.Sentences);
        }

        [TestMethod]
        public void GetSentencesWithoutWordAndWithDate_NoMatches_Test()
        {
            // Arrange
            TextProcessor textProcessor = new TextProcessor();
            textProcessor.AddSentence("Это пример предложения без даты.");

            // Act
            List<Sentence> sentences = textProcessor.GetSentencesWithoutWordAndWithDate("слово");

            // Assert
            Assert.AreEqual(0, sentences.Count);
        }
    }
}
