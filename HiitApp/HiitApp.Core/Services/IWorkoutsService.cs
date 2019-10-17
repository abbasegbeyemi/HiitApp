﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HiitApp.Core.Models;

namespace HiitApp.Core.Services
{
    public interface IWorkoutsService
    {
        Task<Workout> AddNewWorkout(int sprint, int rest);
        Task<List<Workout>> GetAllWorkouts();
        Task DeleteWorkout(Workout workout);
        Task IncrementReps(Workout workout);
    }
}
