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
        public int Sprint
        {
            get => workout.Sprint;
            set
            {
                if (workout.Sprint== value) return;
                workout.Sprint = value;
                RaisePropertyChanged();
            }
        }
        int _rest;
        public int Rest
        {
            get => workout.Rest;
            set
            {
                if (workout.Rest == value) return;
                workout.Rest = value;
                RaisePropertyChanged();
            }
        }
    }
}
