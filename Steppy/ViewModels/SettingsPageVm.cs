using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steppy.BusinessLayer.Helpers;
using Steppy.BusinessLayer.Models;

namespace Steppy.ViewModels
{
    public class SettingsPageVm : PropertyChangedBase
    {
        public SettingsPageVm()
        {
            ThemeOptions = ColorHelper.GetFlatThemes();
        }

        public List<ThemeOption> ThemeOptions { get; }
    }
}
