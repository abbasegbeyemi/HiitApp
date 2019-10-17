using System.IO;
using HiitApp.Core.Models;
using PCLStorage;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiitApp.Core.Repositories
{
    public class WorkoutsRepository : IWorkoutsRepository
    {
        // Connection to the database so we can use async await
        readonly SQLiteAsyncConnection connection;

        // When the workout repository is constructed, these initial parameters are declared
        public WorkoutsRepository()
        {
            // Get the path string to the location where the database is stored lcoally
            string local = FileSystem.Current.LocalStorage.Path;
            // The SQL database file is named workouts.db3
            string datafile = Path.Combine(local, "workouts.db3");
            // Create a SQL connection pointing to the local file
            connection = new SQLiteAsyncConnection(datafile);
            // Create table looks for a table that matches the given type, or create a new one if unavailable
            connection.GetConnection().CreateTable<Workout>();
        }

        // Task to save the workout to the database
        public Task Save(Workout workout)
        {
            return connection.InsertOrReplaceAsync(workout);
        }

        // Task to get all the workouts from teh database
        public Task<List<Workout>> GetAll()
        {
            // Retrieves all the rows from a workout table in the repo, and returns them as a list
            return connection.Table<Workout>().ToListAsync();
        }

        // Task to delete a workout from the database
        public Task Delete(Workout workout)
        {
            // Simply deletes that row from the table
            return connection.DeleteAsync(workout);
        }


    }
}
