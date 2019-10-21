using System.Threading.Tasks;
using System.Collections.Generic;
using HiitApp.Core.Repositories;
using HiitApp.Core.Models;

namespace HiitApp.Core.Services
{
    public class WorkoutsService : IWorkoutsService
    {
        // Initialise the repository
        readonly IWorkoutsRepository repository;
        public WorkoutsService(IWorkoutsRepository  repository)
        {
            // The service always has to be constructed with the repository
            this.repository = repository;
        }
        // this creates a new workout, sets its sprint time and rest time, saves it to the repo, and returns it
        public async Task<Workout> AddNewWorkout(Workout workout)
        {
            await repository.Save(workout).ConfigureAwait(false);
            return workout;
        }
        // Get all the workouts in the repository
        public Task<List<Workout>> GetAllWorkouts()
        {
            return repository.GetAll();
        }
        // We delete the workout using the repository
        public Task DeleteWorkout(Workout workout)
        {
            return repository.Delete(workout);
        }
        // This whole task just serves to increment the number of reps done in the repository, now going further
        // instead of using a button to increment the reps count, we let time do the incrementing. 
        public Task IncrementReps(Workout workout)
        {
            workout.Reps += 1;
            return repository.Save(workout);
        }
    }
}
