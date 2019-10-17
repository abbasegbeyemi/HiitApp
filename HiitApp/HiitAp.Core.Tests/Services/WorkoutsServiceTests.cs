using HiitApp.Core.Services;
using HiitApp.Core.Repositories;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using HiitApp.Core.Models;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace HiitApp.Core.Tests.Services
{
    [TestFixture]
    public class WorkoutsServiceTests
    {
        IWorkoutsService service;
        Mock<IWorkoutsRepository> repo;

        [SetUp]
        public void SetUp()
        {
            repo = new Mock<IWorkoutsRepository>();
            service = new WorkoutsService(repo.Object);
        }

        [Test]
        public async Task IncrementReps_IncrementsTheNumberOfReps()
        {
            // Arrange
            Workout workout = new Workout
            {
                Reps = 0
            };

            // Act
            await service.IncrementReps(workout);

            // Assert
            Assert.AreEqual(1, workout.Reps);
        }

        [Test]
        public async Task IncrementReps_SavesTheIncrementedRepsCounter()
        {
            // Arrange
            Workout workout = new Workout
            {
                Reps = 0
            };
            // Act
            await service.IncrementReps(workout);

            // Assert
            repo.Verify(r => r.Save(It.Is<Workout>(w => w.Reps == 1)), Times.Once);
        }

        [Test]
        public async Task GetAllWorkouts_ReturnsAllTheSavedWorkouts()
        {
            // Arrange
            List<Workout> workouts = new List<Workout>
            {
                new Workout { Reps = 4, Date = DateTime.Now },
                new Workout { Reps = 7, Date = DateTime.Now.AddDays(-1) }
            };
            repo.Setup(r => r.GetAll()).ReturnsAsync(workouts);

            // Act
            List<Workout> results = await service.GetAllWorkouts();

            // Assert 
            CollectionAssert.AreEqual(results, workouts);
        }

        [Test]
        public async Task DeleteWorkout_DeletesTheWorkout()
        {
            // Arrange
            Workout workout = new Workout
            {
                Reps = 5
            };

            // Act
            await service.DeleteWorkout(workout);

            // Assert
            repo.Verify(r => r.Delete(It.Is<Workout>(w => w.Reps == 5)), Times.Once);

        }
    }
}
