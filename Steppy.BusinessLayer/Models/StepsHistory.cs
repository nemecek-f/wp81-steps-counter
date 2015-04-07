using System;
using System.Data.Linq.Mapping;

namespace Steppy.BusinessLayer.Models
{
    [Table]
    public class StepsHistory : BaseModel
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        private int Id { get; set; }

        [Column]
        public int Steps { get; private set; }

        [Column]
        public int RunningSteps { get; private set; }
        
        [Column]
        public DateTime Date { get; private set; }

        [Column]
        public int ActiveTimeMinutes { get; private set; }
        

        public StepsHistory(int steps, int runningSteps, DateTime date, int activeTime = 0)
        {
            Steps = steps;
            RunningSteps = runningSteps;
            Date = date;
            ActiveTimeMinutes = activeTime;
        }
    }
}
