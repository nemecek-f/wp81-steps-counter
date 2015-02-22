using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steppy.BusinessLayer.Models;
using Steppy.BusinessLayer.Reference;
using Steppy.BusinessLayer.SensorCore;

namespace Steppy.ViewModels
{
    public class StepsDataVm : PropertyChangedBase
    {
        private double _todayDistance;
        private int _todaySteps;
        private int _activeTime;
        private double StepLength = 76.2;
        private double _dailyGoalPercentage;
        private double _dailyGoalWidth;
        private const int CentimetersInKilometer = 100000;

        public StepsDataVm()
        {
            SensorCoreWrapper.Instance.SensorConnected += delegate { UpdateData(); };
        }

        public async void UpdateData()
        {
            try
            {
                var todayStats = await SensorCoreWrapper.Instance.GetTodayStats();
                TodaySteps = (int)(todayStats.WalkingStepCount + todayStats.RunningStepCount);
                TodayDistance = Math.Round((TodaySteps * TempValues.StepCentimeterLength) / CentimetersInKilometer, 2);
                ActiveTime = (int)(todayStats.RunTime.Minutes + todayStats.WalkTime.Minutes);
                DailyGoalPercentage = (TodaySteps/TempValues.DailyGoal)*100;
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

        public double DailyGoalPercentage
        {
            get { return _dailyGoalPercentage; }
            set
            {
                _dailyGoalPercentage = value;
                OnPropertyChanged();
            }
        }

        public double DailyGoalWidth
        {
            get { return _dailyGoalWidth; }
            set
            {
                _dailyGoalWidth = value;
                OnPropertyChanged();
            }
        }
    }
}
