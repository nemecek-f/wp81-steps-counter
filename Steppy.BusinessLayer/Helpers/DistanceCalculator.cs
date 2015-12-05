using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steppy.BusinessLayer.Reference;

using static System.Math;

namespace Steppy.BusinessLayer.Helpers
{
    public static class DistanceCalculator
    {
        private const int CentimetersInKilometer = 100000;

        public static double CalculateFromSteps(int steps, double stepLength = TempValues.StepCentimeterLength)
        {
            return Round((steps * stepLength) / CentimetersInKilometer, 2);
        }
    }
}
