using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Storage;
using Lumia.Sense;
using System.Linq;

namespace Steppy.Background
{
    public sealed class BackgroundTask : IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral deferral = taskInstance.GetDeferral();

            try
            {
                IStepCounter stepCounter = await StepCounter.GetDefaultAsync();

                var days = await stepCounter.GetStepCountHistoryAsync(DateTimeOffset.Now.AddDays(2), TimeSpan.FromDays(2));

                var history = days.Select(FormatStepReading);

                await WriteIntoFileAsync(history);
            }
            catch
            {

            }


            deferral.Complete();
        }

        private string FormatStepReading(StepCounterReading reading)
        {
            return
                $"{reading.Timestamp.Ticks};{reading.WalkingStepCount};{reading.WalkTime};{reading.RunningStepCount};{reading.RunTime}";
        }

        private async Task WriteIntoFileAsync(IEnumerable<string> lines)
        {
            StorageFolder local = ApplicationData.Current.LocalFolder;

            using (
                var fileStream =
                    await local.OpenStreamForWriteAsync("data.csv", CreationCollisionOption.ReplaceExisting))
            {
                using (StreamWriter sw = new StreamWriter(fileStream))
                {
                    
                }
                foreach (var line in lines)
                {
                    byte[] fileBytes = Encoding.UTF8.GetBytes(line);
                    fileStream.Write(fileBytes, 0, fileBytes.Length);
                }
            }

        }
    }
}
