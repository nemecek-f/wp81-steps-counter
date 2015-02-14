using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steppy.BusinessLayer
{
    public class SensorNotConnectedException : Exception
    {
        public SensorNotConnectedException(string message = "Sensor not connected") : base(message)
        {
        }
    }

    public class SensorNotSupportedException : Exception
    {
        public SensorNotSupportedException(string message = "Device does not have sensor") : base(message)
        {
            
        }
    }
}
