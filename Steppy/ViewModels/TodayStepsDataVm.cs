using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steppy.BusinessLayer.Models;
using Steppy.BusinessLayer.SensorCore;

namespace Steppy.ViewModels
{
    public class TodayStepsDataVm : PropertyChangedBase
    {
        private double _todayDistance;
        private int _todaySteps;
        private int _activeTime;
        private double StepLength = 76.2;
        private const int CentimetersInKilometer = 100000;

        public TodayStepsDataVm()
        {
            
        }

        public async void UpdateData()
        {
            try
            {
                var todayStats = await SensorCoreWrapper.Instance.GetTodayStats();
                TodaySteps = (int)(todayStats.WalkingStepCount + todayStats.RunningStepCount);
                TodayDistance = Math.Round((TodaySteps * StepLength) / CentimetersInKilometer, 2);
                ActiveTime = (int)(todayStats.RunTime.Minutes + todayStats.WalkTime.Minutes);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public int TodaySteps
        {
            get { return _todaySteps; }
            private set
            {
                _todaySteps = value;
                OnPropertyChanged();
            }
        }

        public double TodayDistance
        {
            get { return _todayDistance; }
            private set
            {
                _todayDistance = value;
                OnPropertyChanged();
            }
        }

        public int ActiveTime
        {
            get { return _activeTime; }
            private set
            {
                _activeTime = value;
                OnPropertyChanged();
            }
        }
    }
}
