﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Steppy.BusinessLayer.Reference;
using Steppy.ViewModels;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace Steppy.Pages.Concepts
{
    public partial class NatureBackground : PhoneApplicationPage
    {
        private readonly StepsDataVm _vm;

        public NatureBackground()
        {
            InitializeComponent();

            if (!DesignerProperties.IsInDesignTool)
            {
                _vm = new StepsDataVm();

                DataContext = _vm;

                
            }
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            e.Cancel = true;

            Application.Current.Terminate();
            
            base.OnBackKeyPress(e);
        }

        private void SettingsIcon_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri(ConstantValues.Pages.SettingsPage, UriKind.Relative));
        }
    }
}