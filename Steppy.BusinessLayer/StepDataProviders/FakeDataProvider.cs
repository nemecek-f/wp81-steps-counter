using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steppy.BusinessLayer.Interfaces;
using Steppy.BusinessLayer.Models;

namespace Steppy.BusinessLayer.StepDataProviders
{
    public class FakeDataProvider : IStepStatsProvider
    {
        public int StepsToday { get { return 2342; } }

        public IEnumerable<StepsHistory> StepsHistory { get { return history; } }

        private static List<StepsHistory> history = new List<StepsHistory>
        {
            new StepsHistory(2148, 24, DateTime.Now.AddDays(-3), 45),
            new StepsHistory(8387, 124, DateTime.Now.AddDays(-2), 21),
            new StepsHistory(3387, 124, DateTime.Now, 21),
            new StepsHistory(4348, 4, DateTime.Now.AddDays(-1), 43),
            new StepsHistory(3345, 1, DateTime.Now.AddDays(-4), 42),
            new StepsHistory(9148, 0, DateTime.Now.AddDays(-5)),
            new StepsHistory(1148, 55, DateTime.Now.AddDays(-6)),
            new StepsHistory(5466, 234, DateTime.Now.AddDays(-7)),
            new StepsHistory(8763, 124, DateTime.Now.AddDays(-8)),
        };
    }
}
