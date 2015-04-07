using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace Steppy.BusinessLayer.Helpers
{
    public static class BackgroundTasksHelper
    {
        private static readonly string _taskName = "SteppyBackgroundWork";

        public static void RegisterBackgroundTask()
        {
            if (BackgroundTaskRegistered()) return;
            
            var builder = PrepareTaskRegistration();

            builder.Register();
        }

        private static BackgroundTaskBuilder PrepareTaskRegistration()
        {
            var builder = new BackgroundTaskBuilder();

            builder.Name = _taskName;

            builder.TaskEntryPoint = "Steppy.Background.BackgroundTask";

            builder.SetTrigger(new TimeTrigger(15, false));

            return builder;
        }

        private static bool BackgroundTaskRegistered()
        {
            return Windows.ApplicationModel.Background.BackgroundTaskRegistration.AllTasks.Any(task => task.Value.Name == _taskName);
        }
    }
}
