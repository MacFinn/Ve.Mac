using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReverseStorage.Test
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void IsValid_WhenInputContainsNumbers_ShouldReturnFalse()
        {
            Validator classToTest = new Validator();

            var input = "47blunts";

            var expectedResult = false;

            var actualResult = classToTest.IsValid(input);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
