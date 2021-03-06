// <copyright file="MainPageViewModelTest.cs">Copyright ©  2016</copyright>
using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Threading.Tasks;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Navigation;
using Prism.Services;
using TextSpeaker.ViewModels;

// ReSharper disable once CheckNamespace
namespace TextSpeaker.ViewModels.Tests
{
    [TestClass]
    public class MainPageViewModelTest
    {
        [TestMethod]
        public void ExecuteNavigationCommand()
        {
            Mock<INavigationService> navigationService = new Mock<INavigationService>();
            Mock<IPageDialogService> pageDialogService = new Mock<IPageDialogService>();
            var viewModel = new MainPageViewModel(navigationService.Object, pageDialogService.Object);
            var command = viewModel.NavigationCommand;

            Assert.IsNotNull(command);
            Assert.IsTrue(command.CanExecute(null));

            command.Execute(null);
            navigationService.Verify(m => m.NavigateAsync("TextSpeechPage", null, null, true), Times.Once);
        }

        [TestMethod]
        public async Task NaivateToTextSpeechPageWhenPressedOk()
        {
            Mock<INavigationService> navigationService = new Mock<INavigationService>();
            Mock<IPageDialogService> pageDialogService = new Mock<IPageDialogService>();
            var viewModel = new MainPageViewModel(navigationService.Object, pageDialogService.Object);

            pageDialogService
                .Setup(m => m.DisplayAlertAsync("確認", "Text Speech画面へ遷移しますか？", "OK", "Cancel"))
                .Returns(Task.FromResult(true));

            Assert.IsTrue(await viewModel.CanNavigateAsync(null));
        }

        [TestMethod]
        public async Task NaivateToTextSpeechPageWhenPressedCancel()
        {
            Mock<INavigationService> navigationService = new Mock<INavigationService>();
            Mock<IPageDialogService> pageDialogService = new Mock<IPageDialogService>();
            var viewModel = new MainPageViewModel(navigationService.Object, pageDialogService.Object);

            pageDialogService
                .Setup(m => m.DisplayAlertAsync("確認", "Text Speech画面へ遷移しますか？", "OK", "Cancel"))
                .Returns(Task.FromResult(false));

            Assert.IsFalse(await viewModel.CanNavigateAsync(null));
        }
    }
}
