using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Lumia.Sense;
using Steppy.BusinessLayer.Models;

namespace Steppy.BusinessLayer.SensorCore
{
    public class SensorCoreWrapper
    {
        private IStepCounter _stepCounter;

        public bool IsSensorConnected { get; private set; }

        public event EventHandler SensorConnected;

        private static readonly SensorCoreWrapper _instance = new SensorCoreWrapper();

        public static SensorCoreWrapper Instance
        {
            get { return _instance; }
        }

        private void OnSensorConnected()
        {
            if (SensorConnected != null)
            {
                SensorConnected(this, new EventArgs());
            }
        }

        private SensorCoreWrapper()
        {
            try
            {
                ConnectToSensor();
            }
            catch (SensorNotSupportedException ex)
            {
                MessageBox.Show("Sensor not supported");
            }
            catch (SensorNotConnectedException ex)
            {
                MessageBox.Show("Cannot connect to sensor");
            }
        }

        public async void ConnectToSensor()
        {
            //await CheckIfSensorIsSupported();

            _stepCounter = await StepCounter.GetDefaultAsync();

            IsSensorConnected = true;

            OnSensorConnected();
        }

        public async Task ReconnectSensor()
        {
            await CheckIfSensorIsSupported();

            _stepCounter = null;

            _stepCounter = await StepCounter.GetDefaultAsync();

            OnSensorConnected();
        }

        public async Task DisconnectSensor()
        {
            await _stepCounter.DeactivateAsync();
        }

        private async Task CheckIfSensorIsSupported()
        {
            if (!await StepCounter.IsSupportedAsync())
            {
                throw new SensorNotSupportedException();
            }
        }

        public async Task<StepCounterReading> GetActualReading()
        {
            if (IsSensorConnected)
            {
                return await _stepCounter.GetCurrentReadingAsync();
            }


            throw new SensorNotConnectedException();
        }

        public async Task<StepCount> GetTodayStats()
        {
            if (IsSensorConnected)
            {
                DateTimeOffset dayStart = StartOfTheDay();
                TimeSpan untilNow = UntilNow(dayStart.Ticks);
                return await _stepCounter.GetStepCountForRangeAsync(dayStart, TimeSpan.FromHours(DateTime.Now.Hour - 1));
            }

            throw new SensorNotConnectedException("Sensor not connected");
        }


        public async Task<StepCounterReading> GetTodayStatsTwo()
        {
            if (IsSensorConnected)
            {
                DateTimeOffset dayStart = StartOfTheDay();
                TimeSpan untilNow = UntilNow(dayStart.Ticks);
                return await _stepCounter.GetCurrentReadingAsync();
            }

            throw new SensorNotConnectedException("Sensor not connected");
        }

        public async Task<StepCount> GetYesterdayStatsAsync()
        {
            if (IsSensorConnected)
            {

                return
                    await
                        _stepCounter.GetStepCountForRangeAsync(StartOfTheDay() - TimeSpan.FromHours(24),
                            TimeSpan.FromHours(24));
            }

            throw new SensorNotConnectedException();
        }

        private DateTimeOffset StartOfTheDay()
        {
            DateTime now = DateTime.Now;

            return new DateTimeOffset(now.Year, now.Month, now.Day, 0, 0, 0, TimeSpan.Zero);
        }

        private TimeSpan UntilNow(long offsetInTicks)
        {
            return TimeSpan.FromTicks(DateTime.Now.Ticks - offsetInTicks);
        }
                

        public async Task<List<StepsHistory>> GetStepsHistory()
        {
            var list = new List<StepsHistory>(31);

            if (IsSensorConnected)
            {
                var lastThirtyDays = await _stepCounter.GetStepCountHistoryAsync(DateTimeOffset.Now.AddDays(-31), TimeSpan.FromDays(30));

                list.AddRange(from dayHistory in lastThirtyDays
                    select
                        new StepsHistory((int)dayHistory.WalkingStepCount, (int)dayHistory.RunningStepCount, new DateTime(dayHistory.Timestamp.Ticks), dayHistory.RunTime.Minutes + dayHistory.WalkTime.Minutes));


            }

            return list;
        }
    }
}
