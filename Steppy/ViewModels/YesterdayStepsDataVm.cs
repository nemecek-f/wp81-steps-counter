using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steppy.BusinessLayer.Models;

namespace Steppy.ViewModels
{
    public class YesterdayStepsDataVm : PropertyChangedBase
    {
        public double Steps { get; set; }
        public double Distance { get; set; }
        public double ActiveTime { get; set; }
    }
}
