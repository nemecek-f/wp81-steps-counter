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
        private TimeSpan _activeTime;
        private double StepLength = 76.2;
        private double _dailyGoalPercentage;
        private double _dailyGoalWidth;
        private int _yesterdaySteps;
        private double _yesterdayDistance;
        private TimeSpan _yesterdayActiveTime;
        private const int CentimetersInKilometer = 100000;

        public event EventHandler DataLoaded;

        public StepsDataVm()
        {
            SensorCoreWrapper.Instance.SensorConnected += delegate
            {
                UpdateTodayData();
                UpdateYesterdayData();
            };
        }

        private void OnDataLoaded()
        {
            if (DataLoaded != null)
            {
                DataLoaded(this, new EventArgs());
            }
        }

        public async void UpdateTodayData()
        {
            try
            {
                var todayStats = await SensorCoreWrapper.Instance.GetTodayStats();

                TodaySteps = (int)(todayStats.WalkingStepCount + todayStats.RunningStepCount);
                TodayDistance = Math.Round((TodaySteps * TempValues.StepCentimeterLength) / CentimetersInKilometer, 2);
                ActiveTime = todayStats.RunTime.Add(todayStats.WalkTime);
                DailyGoalPercentage = (TodaySteps/TempValues.DailyGoal)*100;
                OnDataLoaded();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public async void UpdateYesterdayData()
        {
            try
            {
                var yesterdayStats = await SensorCoreWrapper.Instance.GetYesterdayStatsAsync();
                YesterdaySteps = (int)(yesterdayStats.RunningStepCount + yesterdayStats.WalkingStepCount);
                YesterdayDistance = Math.Round((YesterdaySteps*TempValues.StepCentimeterLength)/CentimetersInKilometer,
                    2);
                YesterdayActiveTimeTs = yesterdayStats.RunTime.Add(yesterdayStats.WalkTime);

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

        public int YesterdaySteps
        {
            get { return _yesterdaySteps; }
            set
            {
                _yesterdaySteps = value;
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

        public double YesterdayDistance
        {
            get { return _yesterdayDistance; }
            set
            {
                _yesterdayDistance = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan ActiveTime
        {
            get { return _activeTime; }
            private set
            {
                _activeTime = value;
                OnPropertyChanged();
                OnPropertyChanged("TodayActiveTime");
            }
        }

        public TimeSpan YesterdayActiveTimeTs
        {
            get { return _yesterdayActiveTime; }
            set
            {
                _yesterdayActiveTime = value;
                OnPropertyChanged("YesterdayActiveTime");
            }
        }

        public string TodayActiveTime
        {
            get { return ActiveTime.FormatToTime(); }
        }

        public string YesterdayActiveTime
        {
            get { return YesterdayActiveTimeTs.FormatToTime(); }
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
