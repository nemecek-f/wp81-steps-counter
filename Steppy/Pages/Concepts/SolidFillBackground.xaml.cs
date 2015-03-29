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
using Steppy.BusinessLayer.Helpers;
using Steppy.BusinessLayer.Reference;
using Steppy.ViewModels;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace Steppy.Pages.Concepts
{
    public partial class SolidFillBackground : PhoneApplicationPage
    {
        private readonly StepsDataVm _vm;

        private bool _trackingIsShown;

        public SolidFillBackground()
        {
            InitializeComponent();

            if (!DesignerProperties.IsInDesignTool)
            {
                _vm = new StepsDataVm();

                DataContext = _vm;

                _vm.DataLoaded += _vm_DataLoaded;
            }
        }

        void _vm_DataLoaded(object sender, EventArgs e)
        {
            Intro.Begin();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _vm.UpdateTodayData();

            base.OnNavigatedTo(e);
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            e.Cancel = true;

            Application.Current.Terminate();

            base.OnBackKeyPress(e);
        }

        private void HistoryButton_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(NavigationUriFactory.HistoryPage);
        }

        private void SettingsButton_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(NavigationUriFactory.SettingsPage);
        }

        private void AchievementsButton_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(NavigationUriFactory.AchievementsPage);
        }

        private void TrackingButton_Tap(object sender, GestureEventArgs e)
        {
            if (_trackingIsShown)
            {
                HideTracking.Begin();
            }
            else
            {
                TrackingControl.Visibility = System.Windows.Visibility.Visible;
                ShowTracking.Begin();
            }
        }

        private double _initialX;

        private void GesturesGrid_ManipulationStarted(object sender, System.Windows.Input.ManipulationStartedEventArgs e)
        {
            _initialX = e.ManipulationOrigin.X;
        }

        private void GesturesGrid_ManipulationCompleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
        {
            double totalManipulation = _initialX + Math.Abs(e.TotalManipulation.Translation.X);
            if (totalManipulation > 300 && totalManipulation < 500)
            {
                // 
            }
        }

        private void ShowTracking_Completed(object sender, EventArgs e)
        {
            _trackingIsShown = true;
        }

        private void HideTracking_Completed(object sender, EventArgs e)
        {
            _trackingIsShown = false;
            TrackingControl.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}