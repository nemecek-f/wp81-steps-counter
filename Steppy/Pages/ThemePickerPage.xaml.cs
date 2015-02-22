using System;
using System.Collections.Generic;
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
                Resources["ThemeColor"] = new SolidColorBrush((Color)e.AddedItems[0]);
                NavigationService.GoBack();
            }
        }
    }
}