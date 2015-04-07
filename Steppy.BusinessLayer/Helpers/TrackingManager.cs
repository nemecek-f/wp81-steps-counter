using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lumia.Sense;
using Steppy.BusinessLayer.Models;
using Steppy.BusinessLayer.SensorCore;

namespace Steppy.BusinessLayer.Helpers
{
    public class TrackingManager
    {
        private static readonly Lazy<TrackingManager> _instance = new Lazy<TrackingManager>(() => new TrackingManager());
        private bool _trackingActive;

        public static TrackingManager Instance { get { return _instance.Value; } }

        private TrackingManager() { }

        private static readonly string trackingStart = "trackingSettingsX";

        public bool TrackingActive
        {
            get { return IsolatedStorageHelper.ContainsKey(trackingStart); }
        }

        public void StartTracking()
        {
            IsolatedStorageHelper.Add(trackingStart, DateTime.Now.Ticks);
        }

        public async Task StopTracking()
        {
            var ticks = IsolatedStorageHelper.GetValue<long>(trackingStart);
            IsolatedStorageHelper.Remove(trackingStart);

            var result = await SensorCoreWrapper.Instance.GetForRange(new DateTimeOffset(new DateTime(ticks)));

            _latestResult = new TrackingResult(result);
        }

        public async Task ToggleTracking()
        {
            if (TrackingActive)
            {
                await StopTracking();
            }
            else
            {
                StartTracking();
            }
        }

        public async Task<TrackingResult> GetCurrentResult()
        {
            var ticks = IsolatedStorageHelper.GetValue<long>(trackingStart);

            return new TrackingResult(await SensorCoreWrapper.Instance.GetForRange(new DateTimeOffset(new DateTime(ticks))));
        }

        private TrackingResult _latestResult;

        public TrackingResult GetLatestResult()
        {
            return _latestResult;
        }
    }
}
