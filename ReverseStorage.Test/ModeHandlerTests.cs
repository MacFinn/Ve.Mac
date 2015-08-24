using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ReverseStorage.Abstraction;

namespace ReverseStorage.Test
{
    [TestClass]
    public class ModeHandlerTests
    {
        [TestMethod]
        public void OrchestrateMode_WhenGivenInsertMode_ShouldCallValidatorIsValidOnceAndWordInverterGetInvertedWordOnce()
        {
            var input = UserMode.INSERT;

            var moqWordService = new Mock<IWordService>();
            var moqValidator = new Mock<IValidator>();
            var moqWordInverter = new Mock<IWordInverter>();

            var target = new ModeHandler(moqWordService.Object, moqValidator.Object, moqWordInverter.Object);

            moqValidator.Setup(m => m.IsValid(It.IsAny<string>())).Returns(true);
            moqWordInverter.Setup(m => m.GetInvertedWord(It.IsAny<string>())).Returns(It.IsAny<string>());
            moqWordService.Setup(m => m.AddWord(It.IsAny<string>(), It.IsAny<string>()));

            target.OrchestrateMode(input, string.Empty);

            moqValidator.Verify(m => m.IsValid(It.IsAny<string>()), Times.Once);
            moqWordInverter.Verify(m => m.GetInvertedWord(It.IsAny<string>()), Times.Once);
            moqWordService.Verify(m => m.AddWord(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void OrchestrateMode_WhenGivenRetrieveMode_ShouldCallHandlerRetrieveAllWordsToConsoleOnce()
        {
            var input = UserMode.RETRIEVE;

            var moqWordService = new Mock<IWordService>();
            var moqValidator = new Validator();
            var moqWordInverter = new WordInverter();

            var target = new ModeHandler(moqWordService.Object, moqValidator, moqWordInverter);

            moqWordService.Setup(m => m.RetrieveAllWordsToConsole(It.IsAny<string>()));

            target.OrchestrateMode(input, string.Empty);

            moqWordService.Verify(m => m.RetrieveAllWordsToConsole(It.IsAny<string>()), Times.Once);
        }
    }
}
