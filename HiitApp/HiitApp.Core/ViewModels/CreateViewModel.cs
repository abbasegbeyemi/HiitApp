using HiitApp.Core.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Navigation;
using HiitApp.Core.Services;
using System;
using System.Threading.Tasks;

namespace HiitApp.Core.ViewModels
{
    public class CreateViewModel : MvxViewModel<Workout>
    {        
        Workout workout;
        readonly IMvxNavigationService navigation;
        readonly IWorkoutsService service;

        public CreateViewModel(IWorkoutsService service, IMvxNavigationService navigation)
        {
            this.service = service;
            this.navigation = navigation;
            CreateWorkoutCommand = new MvxAsyncCommand(CreateWorkout);
        }

        /*** Methods and Tasks ***/

        async Task CreateWorkout()
        {
            await service.AddNewWorkout(workout);
            await navigation.Navigate<TrainViewModel, Workout>(workout);
        }

        public override void Prepare(Workout workout)
        {
            this.workout = workout;
            workout.Date = DateTime.Now;
        }

        /*** Command Properties ***/

        public MvxAsyncCommand CreateWorkoutCommand { get; }

        /*** Workout Properties***/

        public int Sprint
        {
            get => workout.Sprint;
            set
            {
                if (workout.Sprint == value) return;
                workout.Sprint = value;
                RaisePropertyChanged();
            }
        }

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

        public DateTime Date
        {
            get => workout.Date;
            private set
            {
                workout.Date = value;
            }
        }
    }
}
