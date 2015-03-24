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
using Steppy.BusinessLayer.Helpers;

namespace Steppy.Pages
{
    public partial class ThemePickerPage : PhoneApplicationPage
    {
        public ThemePickerPage()
        {
            InitializeComponent();


            ColorsList.ItemsSource = PrepareColorSelection();
        }

        private List<Color> PrepareColorSelection()
        {
            var list = PrepareThemeColorsSelection();
            list.AddRange(ColorHelper.GetBaseColorSelection());
            return list;
        }

        private List<Color> PrepareThemeColorsSelection()
        {
            return new List<Color>()
            {
                ColorHelper.ConvertStringToColor("#C9A64A"),

            };
        }

        private void ColorsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                ((SolidColorBrush) App.Current.Resources["ThemeColor"]).Color = (Color)e.AddedItems[0];
                IsolatedStorageSettings.ApplicationSettings["themeColor"] = ((Color) e.AddedItems[0]).ToString();
                IsolatedStorageSettings.ApplicationSettings.Save();
                NavigationService.GoBack();
            }
        }
    }
}