using System.Threading.Tasks;
using Microsoft.Pex.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

// ReSharper disable once CheckNamespace
namespace TextSpeaker.ViewModels.Tests
{
    [TestClass]
    public class TextSpeechPageViewModelTest
    {
        [TestMethod]
        public void SpeechTest()
        {
            var viewModel = new TextSpeechPageViewModel();
            viewModel.Speech();
        }
    }
}
