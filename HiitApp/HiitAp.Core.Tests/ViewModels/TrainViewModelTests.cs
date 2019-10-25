using NUnit.Framework;
using HiitApp.Core.Models;
using HiitApp.Core.ViewModels;
using HiitApp.Core.Services;
using Moq;
using System.Threading.Tasks;

namespace HiitApp.Core.Tests.ViewModels
{
    [TestFixture]
    public class TrainViewModelTests
    {
        TrainViewModel viewModel;
        Mock<IWorkoutsService> service;

        [SetUp]
        public void SetUp()
        {
            service = new Mock<IWorkoutsService>();
            viewModel = new TrainViewModel(service.Object);
            viewModel.ShouldAlwaysRaiseInpcOnUserInterfaceThread(false);
        }

        [Test]
        public async Task IncrementRepsInTheWorkoutBackingLayer()
        {
            // Act 
            await viewModel.IncrementRepsCommand.ExecuteAsync();

            // Assert
            service.Verify(w => w.IncrementReps(It.IsAny<Workout>()), Times.Once);
        }

        [Test]
        public async Task CheckThatRepsChangeRaisesPropertyChanged()
        {
            // Arrange
            bool propertyChangedRaised = false;
            viewModel.PropertyChanged +=
                (s, e) => propertyChangedRaised = (e.PropertyName == "Reps");

            // Act
            await viewModel.IncrementRepsCommand.ExecuteAsync();

            // Assert
            Assert.IsTrue(propertyChangedRaised);
        }
    }
}
