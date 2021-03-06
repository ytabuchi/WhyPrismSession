using Microsoft.Pex.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TextSpeaker.Model;

// ReSharper disable once CheckNamespace
namespace TextSpeaker.ViewModels.Tests
{
    [TestClass]
    public class TextSpeechPageViewModelTest
    {
        [TestMethod]
        public void SpeechTest()
        {
            var service = new Mock<ITextToSpeechService>();
            var viewModel = new TextSpeechPageViewModel(service.Object);
            viewModel.Text = "Message";

            var command = viewModel.SpeechCommand;
            Assert.IsNotNull(command);
            Assert.IsTrue(command.CanExecute(null));
            command.Execute(null);

            service.Verify(m => m.Speech("Message"));
        }
    }
}
