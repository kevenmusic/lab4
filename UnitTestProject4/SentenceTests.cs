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
        public void ContainsDate_Test()
        {
            // Arrange
            Sentence sentence1 = new Sentence("Сегодня 10/21/2023.");
            Sentence sentence2 = new Sentence("В этом предложении нет даты.");

            // Act
            bool containsDate1 = sentence1.ContainsDate();
            bool containsDate2 = sentence2.ContainsDate();

            // Assert
            Assert.IsTrue(containsDate1);
            Assert.IsFalse(containsDate2);
        }
    }
}
