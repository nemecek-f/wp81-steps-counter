using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Steppy.BusinessLayer.Reference;

namespace Steppy.Pages
{
    public partial class SettingsPage : PhoneApplicationPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void ThemeSelect_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(ConstantValues.Pages.ColorPicker, UriKind.Relative));
        }
    }
}