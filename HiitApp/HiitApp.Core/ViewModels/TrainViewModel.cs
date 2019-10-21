using HiitApp.Core.Models;
using MvvmCross.Core.ViewModels;
using System.Threading.Tasks;
using HiitApp.Core.Services;


namespace HiitApp.Core.ViewModels
{
    public class TrainViewModel : MvxViewModel<Workout>
    {
        Workout workout;
        readonly IWorkoutsService service;

        public TrainViewModel(IWorkoutsService service)
        {
            this.service = service;
            IncrementRepsCommand = new MvxAsyncCommand(IncrementReps);
        }

        /*** Methods and Tasks ***/

        async Task IncrementReps()
        {
            await service.IncrementReps(workout);
            RaisePropertyChanged(() => Reps);
        }

        public override void Prepare(Workout workout)
        {
            this.workout = workout;
        }

        /*** Command Properties ***/
        
        public IMvxAsyncCommand IncrementRepsCommand { get; }

        /*** Workout Properties ***/
        
        public int Sprint
        {
            get => workout.Sprint;
        }
        public int Rest
        {
            get => workout.Rest;
        }
        public int Reps
        {
            get => workout.Reps;
        }
    }
}
