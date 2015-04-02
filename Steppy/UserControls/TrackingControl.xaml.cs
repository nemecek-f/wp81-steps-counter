using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace Steppy.UserControls
{
    public partial class TrackingControl : UserControl
    {
        public event EventHandler Closed;

        public TrackingControl()
        {
            InitializeComponent();
        }

        private void Close_Tap(object sender, GestureEventArgs e)
        {
            OnClosed();
        }

        private void OnClosed()
        {
            if (Closed != null)
            {
                Closed(this, new EventArgs());
            }
        }
    }
}
