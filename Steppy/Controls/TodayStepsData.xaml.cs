using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Steppy.ViewModels;

namespace Steppy.Controls
{
    public partial class TodayStepsData : UserControl
    {
        private readonly StepsDataVm _vm;

        public TodayStepsData()
        {
            InitializeComponent();

            if (!DesignerProperties.IsInDesignTool)
            {
                _vm = new StepsDataVm();

                DataContext = _vm;
            }
            
        }

        private void UpdateData()
        {
            _vm.UpdateTodayData();
            _vm.DailyGoalWidth = DailyProgressBar.Width * (_vm.DailyGoalPercentage / 100);
        }

        private void RefreshGrid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            UpdateData();
        }
    }
}
