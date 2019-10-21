using NUnit.Framework;
using HiitApp.Core.Models;
using HiitApp.Core.ViewModels;
using System;

namespace HiitApp.Core.Tests.ViewModels
{
    [TestFixture]
    public class CreateViewModelTests
    {
        CreateViewModel viewModel;

        [SetUp]
        public void SetUp()
        {
            viewModel = new CreateViewModel();
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
    }
}
