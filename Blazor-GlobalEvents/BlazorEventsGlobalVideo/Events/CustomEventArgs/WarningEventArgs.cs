using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEventsGlobalVideo.Events.CustomEventArgs
{
    public class WarningEventArgs : EventArgs
    {
        public string Message { get; set; }
        public DateTime Date { get; } = DateTime.Now;
    }
}
