using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary4;

namespace UnitTestProject4
{
    [TestClass]
    public class SentenceTests
    {
        [TestMethod]
        public void ContainsWord_Test()
        {
            // Arrange
            Sentence sentence = new Sentence("Это пример предложения.");

            // Act
            bool containsWord = sentence.ContainsWord("пример");

            // Assert
            Assert.IsTrue(containsWord);
        }

        [TestMethod]
        public void ContainsWord_NotContaining_Test()
        {
            // Arrange
            Sentence sentence = new Sentence("Это пример предложения.");

            // Act
            bool containsWord = sentence.ContainsWord("слово");

            // Assert
            Assert.IsFalse(containsWord);
        }

        [TestMethod]
        public void ContainsDate_Test()
        {
            // Arrange
            Sentence sentence1 = new Sentence("Сегодня 21/10/2023.");
            Sentence sentence2 = new Sentence("В этом предложении нет даты.");

            // Act
            bool containsDate1 = sentence1.ContainsDate();
            bool containsDate2 = sentence2.ContainsDate();

            // Assert
            Assert.IsTrue(containsDate1);
            Assert.IsFalse(containsDate2);
        }

        [TestMethod]
        public void ContainsDate_Containing_Test()
        {
            // Arrange
            Sentence sentence = new Sentence("Сегодня 22/10/2023.");

            // Act
            bool containsDate = sentence.ContainsDate();

            // Assert
            Assert.IsTrue(containsDate);
        }

        [TestMethod]
        public void ContainsDate_NotContaining_Test()
        {
            // Arrange
            Sentence sentence = new Sentence("Здесь нет даты.");

            // Act
            bool containsDate = sentence.ContainsDate();

            // Assert
            Assert.IsFalse(containsDate);
        }
    }
}
