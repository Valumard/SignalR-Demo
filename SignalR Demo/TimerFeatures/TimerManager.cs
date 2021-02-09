using System;
using System.Threading;

namespace SignalR_Demo.TimerFeatures
{
    public class TimerManager
    {
        private Timer timer;
        private AutoResetEvent autoResetEvent;
        private Action action;

        public DateTime TimerStarted { get; set; }

        public TimerManager(Action action)
        {
            this.action = action;
            this.TimerStarted = DateTime.Now;
            this.autoResetEvent = new AutoResetEvent(false);

            this.timer = new Timer(Execute, this.autoResetEvent, 1000, 10000);

        }

        public void Execute(object info)
        {
            this.action();

            if((DateTime.Now - this.TimerStarted).Seconds > 60)
            {
                this.timer.Dispose();
            }
        }
    }
}
