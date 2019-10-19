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
            Workout workout = new Workout();
            viewModel.Prepare(workout);

            // Act
            viewModel.Sprint = "30";

            // Assert
            Assert.AreEqual("30", viewModel.Sprint);
        }
        [Test]
        public void RestTimeComesFromWorkout()
        {
            // Arrange
            Workout workout = new Workout();
            viewModel.Prepare(workout);

            // Act
            viewModel.Rest = "30";

            // Assert
            Assert.AreEqual("30", viewModel.Rest);
        }
    }
}
