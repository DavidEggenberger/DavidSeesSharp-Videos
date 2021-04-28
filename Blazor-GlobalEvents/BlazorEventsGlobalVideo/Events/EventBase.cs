using BlazorEventsGlobalVideo.Events.CustomEventArgs;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEventsGlobalVideo.Events
{
    public class EventBase : ComponentBase
    {
        public static event EventHandler<WarningEventArgs> WarningTriggered;
        public static event EventHandler WarningResseted;
        public void TriggerWarning(string message)
        {
            WarningTriggered?.Invoke(this, new WarningEventArgs { Message = message });
        }
        public void ResetWarning()
        {
            WarningResseted?.Invoke(this, null);
        }
    }
}
