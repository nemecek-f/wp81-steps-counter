using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steppy.BusinessLayer.Models;

namespace Steppy.BusinessLayer.Mocks
{
    public static class Achievements
    {
        public static List<Achievement> Mocks
        {
            get
            {
                return new List<Achievement>
                {
                    new Achievement("Walker", "Walk 10 kilometeres"),
                    new Achievement("I am serious", "Walk 15000 steps in one day", true),
                    new Achievement("Couch Potato", "Walk less than 1000 steps in one day"),
                    new Achievement("I Run!", "Run 4000 steps in one day", true),
                    new Achievement("Who needs technology when you got legs?", "Walk total 500 000 steps")
                };
            }
        }
    }
}
