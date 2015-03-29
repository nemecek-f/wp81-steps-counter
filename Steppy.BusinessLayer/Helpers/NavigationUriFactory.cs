using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steppy.BusinessLayer.Reference;

namespace Steppy.BusinessLayer.Helpers
{
    public static class NavigationUriFactory
    {
        public static Uri FromString(string navigationUrl)
        {
            return new Uri(navigationUrl, UriKind.Relative);
        }

        public static Uri HistoryPage
        {
            get { return FromString(ConstantValues.Pages.HistoryPage); }
        }

        public static Uri SettingsPage
        {
            get { return FromString(ConstantValues.Pages.SettingsPage); }
        }

        public static Uri AchievementsPage
        {
            get { return FromString(ConstantValues.Pages.AchievementsPage); }
        }

        public static Uri TrackingPage
        {
            get { return FromString(ConstantValues.Pages.TrackingPage); }
        }
    }
}
