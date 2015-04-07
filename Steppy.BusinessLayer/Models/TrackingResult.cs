using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lumia.Sense;

namespace Steppy.BusinessLayer.Models
{
    public class TrackingResult
    {
        public int WalkingSteps { get; set; }

        public int RunningSteps { get; set; }

        public TimeSpan ActiveTime { get; set; }

        public double Distance { get; set; }

        public TrackingResult(StepCount stepCount)
        {
            WalkingSteps = (int) stepCount.WalkingStepCount;
            RunningSteps = (int) stepCount.RunningStepCount;
            ActiveTime = stepCount.RunTime.Add(stepCount.WalkTime);
        }

        public TrackingResult()
        {
            
        }
    }
}
