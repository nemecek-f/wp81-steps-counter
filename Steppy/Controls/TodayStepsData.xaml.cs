using System;
using System.Collections.Generic;
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
        private TodayStepsDataVm _vm;

        public TodayStepsData()
        {
            InitializeComponent();

            _vm = new TodayStepsDataVm();

            DataContext = _vm;

            Loaded += delegate { _vm.UpdateData(); };
        }


        private void RefreshGrid_Tap(object sender, GestureEventArgs e)
        {
            _vm.UpdateData();
        }
    }
}
