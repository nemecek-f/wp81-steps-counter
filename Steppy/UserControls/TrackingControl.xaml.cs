using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Steppy.BusinessLayer.Helpers;
using Steppy.BusinessLayer.SensorCore;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace Steppy.UserControls
{
    public partial class TrackingControl : UserControl, INotifyPropertyChanged
    {
        private bool _trackingActive;
        private const string PlayBtnPath = "Assets/play-button.png";
        private const string StopBtnPath = "Assets/stop-button.png";

        public bool TrackingActive
        {
            get { return _trackingActive; }
            set
            {
                _trackingActive = value;
                OnPropertyChanged();
                OnPropertyChanged("TrackingInactive");
            }
        }

        public bool TrackingInactive { get { return !TrackingActive; } }

        public event EventHandler Closed;

        public event EventHandler DataUpdated;

        public TrackingControl()
        {
            InitializeComponent();
        }

        public async Task UpdateData()
        {
            var data = await TrackingManager.Instance.GetCurrentResult();
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

        private void OnDataUpdated()
        {
            if (DataUpdated != null)
            {
                DataUpdated(this, new EventArgs());
            }
        }

        private void TrackingButton_Tap(object sender, GestureEventArgs e)
        {
            if (TrackingManager.Instance.IsTrackingActive)
            {
                TrackingManager.Instance.StopTracking();
            }
            else
            {
                TrackingManager.Instance.StartTracking();
            }
        }

        private void StartTracking()
        {
            
        }

        private void StopTracking()
        {
            
        }

        #region PropertyChangedImplementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}
