using System.Collections.Generic;
using HiitApp.Core.Models;
using System.Threading.Tasks;

namespace HiitApp.Core.Repositories
{
    public interface IWorkoutsRepository
    {
        Task Save(Workout workout);
        Task<List<Workout>> GetAll();
        Task Delete(Workout workout);
    }
}
