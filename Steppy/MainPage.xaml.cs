﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Steppy.Resources;

namespace Steppy
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();


            //Loaded += delegate
            //{
            //    NavigationService.Navigate(new Uri("/Pages/Concepts/NatureBackground.xaml", UriKind.Relative));
            //};

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            NavigationService.Navigate(new Uri("/Pages/Concepts/SolidFillBackground.xaml", UriKind.Relative));
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
        private void ConceptOnce_BtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Concepts/NatureBackground.xaml", UriKind.Relative));
        }

        private void ConceptTwo_BtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Concepts/SolidFillBackground.xaml", UriKind.Relative));
        }
    }
}