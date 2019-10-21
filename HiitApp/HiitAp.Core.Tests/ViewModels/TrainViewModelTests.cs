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
            // Arrange
            Workout workout = new Workout()
            {
                Sprint = 30
            };
            viewModel.Prepare(workout);

            // Act
            int check = 0;
            for (int i = 1; i < 4; i++)
            {
                await viewModel.
                check = i;
            }

            // Assert
            Assert.AreEqual(check, workout.Reps);     
        }

        [Test]
        public void CheckThatRepsChangeRaisesPropertyChanged()
        {
            // Arrange
            bool propertyChangedRaised = false;
            Workout workout = new Workout()
            {
                Sprint = 30
            };
            viewModel.Prepare(workout);
            viewModel.PropertyChanged +=
                (s, e) => propertyChangedRaised = (e.PropertyName == "Reps");

            // Act
            for (int i = 0; i < 4; i++)
            {
                viewModel.Reps++;
            }

            // Assert
            Assert.IsTrue(propertyChangedRaised);

        }
    }
}
