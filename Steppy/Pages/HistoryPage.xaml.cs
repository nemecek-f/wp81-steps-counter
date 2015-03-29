using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Telerik.Charting;
using Telerik.Windows.Controls;

namespace Steppy.Pages
{
    public partial class HistoryPage : PhoneApplicationPage
    {
        public HistoryPage()
        {
            InitializeComponent();

            Loaded += delegate
            {
                UpdateChart();
            };
        }

        private void UpdateChart()
        {
            

            MainChart.Series[0].ItemsSource = new double[] {20, 30, 40};



        }
    }
}