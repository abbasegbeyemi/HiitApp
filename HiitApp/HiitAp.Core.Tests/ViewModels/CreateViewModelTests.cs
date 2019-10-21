using NUnit.Framework;
using HiitApp.Core.Models;
using HiitApp.Core.ViewModels;
using System.Threading.Tasks;
using HiitApp.Core.Services;
using System;
using MvvmCross.Core.Navigation;
using Moq;

namespace HiitApp.Core.Tests.ViewModels
{
    [TestFixture]
    public class CreateViewModelTests
    {
        CreateViewModel viewModel;
        Mock<IWorkoutsService> workoutService;
        Mock<IMvxNavigationService> navigationService;


        [SetUp]
        public void SetUp()
        {
            navigationService = new Mock<IMvxNavigationService>();
            workoutService = new Mock<IWorkoutsService>();
            viewModel = new CreateViewModel(workoutService.Object, navigationService.Object);
        }

        [Test]
        public void SprintTimeComesFromWorkout()
        {
            // Arrange
            Workout workout = new Workout()
            {
                Sprint = 30
            };

            // Act
            viewModel.Prepare(workout);
            

            // Assert
            Assert.AreEqual(workout.Sprint, viewModel.Sprint);
        }

        [Test]
        public void RestTimeComesFromWorkout()
        {
            // Arrange
            Workout workout = new Workout()
            {
                Rest = 30
            };

            // Act
            viewModel.Prepare(workout);


            // Assert
            Assert.AreEqual(workout.Rest, viewModel.Rest);
        }

        [Test]
        public void SettingRest_RaisesPropertyChanged()
        {
            // Arrange
            Workout workout = new Workout()
            {
                Sprint = 30
            };
            var propertyChangedRaised = false;
            viewModel.Prepare(workout);
            viewModel.ShouldAlwaysRaiseInpcOnUserInterfaceThread(false);
            viewModel.PropertyChanged +=
                (s, e) => propertyChangedRaised = (e.PropertyName == "Rest");

            // Act
            viewModel.Rest = 60;

            // Assert
            Assert.IsTrue(propertyChangedRaised);

        }


        [Test]
        public void SettingSprint_RaisesPropertyChanged()
        {
            // Arrange
            Workout workout = new Workout()
            {
                Sprint = 30
            };
            var propertyChangedRaised = false;
            viewModel.Prepare(workout);
            viewModel.ShouldAlwaysRaiseInpcOnUserInterfaceThread(false);
            viewModel.PropertyChanged +=
                (s, e) => propertyChangedRaised = (e.PropertyName == "Sprint");

            // Act
            viewModel.Sprint = 60;
            
            // Assert
            Assert.IsTrue(propertyChangedRaised);
        }

        [Test]
        public void CreatingViewModel_SetsTheCorrectDate()
        {
            // Arrange
            Workout workout = new Workout();

            // Act
            viewModel.Prepare(workout);

            // Assert
            Assert.AreEqual(DateTime.Today.Day, viewModel.Date.Day);
        }

        [Test]
        public async Task AddNewWorkout_SavesANewCounter()
        {
            // Arrange
            Workout workout = new Workout()
            {
                Id = 0,
                Sprint = 30,
                Rest = 30,                              
            };

            // Act
            await viewModel.CreateWorkoutCommand.ExecuteAsync();

            // Assert
            workoutService.Verify(s => s.AddNewWorkout(It.IsAny<Workout>()), Times.Once);
        }
    }
}
