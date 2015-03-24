using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Steppy.ViewModels;

namespace Steppy.Pages.Concepts
{
    public partial class SolidFillBackground : PhoneApplicationPage
    {
        private readonly StepsDataVm _vm;

        public SolidFillBackground()
        {
            InitializeComponent();

            if (!DesignerProperties.IsInDesignTool)
            {
                _vm = new StepsDataVm();

                DataContext = _vm;

                _vm.DataLoaded += delegate { Intro.Begin(); };
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _vm.UpdateTodayData();
            
            base.OnNavigatedTo(e);

            
        }
    }
}