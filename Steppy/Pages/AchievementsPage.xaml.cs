using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Steppy.ViewModels;

namespace Steppy.Pages
{
    public partial class AchievementsPage : PhoneApplicationPage
    {
        private AchievementsPageVm _vm;

        public AchievementsPage()
        {
            InitializeComponent();

            _vm = new AchievementsPageVm();

            DataContext = _vm;
        }
    }
}