using HiitApp.Core.Models;
using MvvmCross.Core.ViewModels;
using System;

namespace HiitApp.Core.ViewModels
{
    public class CreateViewModel : MvxViewModel<Workout>
    {
        Workout workout;
        public override void Prepare(Workout workout)
        {
            this.workout = workout;
        }
        int _sprint;
        public int Sprint
        {
            get => _sprint;
            set => SetProperty(ref _sprint, value);
        }
        int _rest;
        public int Rest
        {
            get => _rest;
            set => SetProperty(ref _rest, value);
        }
    }
}
