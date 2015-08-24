using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace ReverseStorage.Test
{
    [TestClass]
    public class WordServiceTests
    {
        [TestMethod]
        public void AddWord_WhenGivenAString_ShouldCallFileWrapperWithSameStringOnce()
        {
          

            var moqFileWrapper = new Mock<IFileWrapper>();

            moqFileWrapper.Setup(m => m.AppendText(It.IsAny<string>(),
                                                   It.IsAny<string>()));

            WordService target = new WordService(moqFileWrapper.Object);

            target.AddWord(string.Empty, string.Empty);

            moqFileWrapper.Verify(m => m.AppendText(It.IsAny<string>(), 
                                                    It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void RetrieveAllWords_WhenGiveAFilePath_ShouldCallFileWrapperWithSameString()
        {
            var moqFileWrapper = new Mock<IFileWrapper>();

            moqFileWrapper.Setup(m => m.ReadFile(It.IsAny<string>())).Returns(new List<string>());

            var target = new WordService(moqFileWrapper.Object);

            target.RetrieveAllWordsToConsole(string.Empty);

            moqFileWrapper.Verify(m => m.ReadFile(It.IsAny<string>()), Times.Once);
        }
    }
}
