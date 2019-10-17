using NUnit.Framework;
using HiitApp.Core.Models;
using HiitApp.Core.ViewModels;

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
            Workout workout = new Workout
            {
                Sprint = 30,
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
            Workout workout = new Workout
            {
                Rest = 30,
            };
            // Act
            viewModel.Prepare(workout);

            // Assert
            Assert.AreEqual(workout.Rest, viewModel.Rest);
        }
    }
}
