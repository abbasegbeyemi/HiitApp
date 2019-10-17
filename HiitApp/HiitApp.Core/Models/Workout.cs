using SQLite;
using System;

namespace HiitApp.Core.Models
{
    public class Workout
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }

        // The date for the workout creation is imortant
        public DateTime Date { get; set; }

        // The number of sprint reps
        public int Reps { get; set; }

        // The sprint time in seconds
        public int Sprint { get; set; }

        // The rest time in seconds
        public int Rest { get; set; }
    }
}
