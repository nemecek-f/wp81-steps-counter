using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steppy.BusinessLayer.Models;

namespace Steppy.ViewModels
{
    public class AchievementsPageVm : PropertyChangedBase
    {
        public AchievementsPageVm()
        {
            Achievements = BusinessLayer.Mocks.Achievements.Mocks;
        }

        public List<Achievement> Achievements { get; set; }
    }
}
