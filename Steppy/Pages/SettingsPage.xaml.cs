using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Linq;
using Steppy.BusinessLayer.Models;
using Steppy.BusinessLayer.Reference;
using Steppy.ViewModels;

namespace Steppy.Pages
{
    public partial class SettingsPage : PhoneApplicationPage
    {
        private SettingsPageVm _vm;

        public SettingsPage()
        {
            InitializeComponent();

            _vm = new SettingsPageVm();

            DataContext = _vm;
        }
      
        private void ThemeOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var theme = (ThemeOption)e.AddedItems[0];

                ((SolidColorBrush) App.Current.Resources["ThemeColor"]).Color = theme.Color;
                IsolatedStorageSettings.ApplicationSettings["themeColor"] = theme.Color.ToString();
                IsolatedStorageSettings.ApplicationSettings.Save();
            }
        }
    }
}