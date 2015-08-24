using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReverseStorage.Test
{
    [TestClass]
    public class WordInverterTests
    {
        [TestMethod]
        public void GetInvertedWord_WhenInputIsMacdara_ShouldReturnAradcam()
        {
            WordInverter classToTest = new WordInverter();

            var input = "Macdara";

            var expectedResult = "aradcaM";
           
            var actualResult = classToTest.GetInvertedWord(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetInvertedWord_WhenInputIsNull_ShouldReturnNull()
        {
            WordInverter classToTest = new WordInverter();

            string input = null;

            classToTest.GetInvertedWord(input);

        }
    }
}
