using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lumia.Sense;

namespace Steppy.BusinessLayer
{
    class TestClass
    {
        private Lumia.Sense.StepCounterReading sr = new StepCounterReading();

        private async void Test()
        {
            StepCount stc = new StepCount();

            

            StepCounter stCounter = await StepCounter.GetDefaultAsync();

            
        }
    }
}
