using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steppy.BusinessLayer
{
    class EventDemo
    {
        public event EventHandler DemoEvent;

        private void RaiseEvent()
        {
            if (DemoEvent != null)
                DemoEvent(this, new EventArgs());
        }
    }
}
