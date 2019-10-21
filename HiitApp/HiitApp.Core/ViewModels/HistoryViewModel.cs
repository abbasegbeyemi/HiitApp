using HiitApp.Core.Services;
using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;
using HiitApp.Core.Models;

namespace HiitApp.Core.ViewModels
{
    class HistoryViewModel : MvxViewModel
    {
        readonly IWorkoutsService service;

        public HistoryViewModel(IWorkoutsService service)
        {
            this.service = service;
            
        }
        public ObservableCollection<TrainViewModel> WorkoutHistory { get; }
    }
}
