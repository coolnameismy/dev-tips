using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Threading;

namespace PhoneApp2
{
   public class Clock:INotifyPropertyChanged
    {
        int hour, min, second;
        public event PropertyChangedEventHandler PropertyChanged;

        public Clock()
        {
            //get time now!
            OnTimerTick(null, null);

            //Set Timer
            DispatcherTimer tmr = new DispatcherTimer();
            tmr.Interval = TimeSpan.FromSeconds(0.1);
            tmr.Tick += OnTimerTick;
            tmr.Start();
        }

        public int Hour
        {
            protected set
            {
                if (value != hour)
                {
                    hour = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Hour"));
                }
            }
            get
            {
                return hour;
            }
        }

        public int Min
        {
            protected set
            {
                if (value != min)
                {
                    min = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Min"));
                }
            }
            get
            {
                return min;
            }
        }
        public int Second
        {
            protected set
            {
                if (value != second)
                {
                    second = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Second"));
                }
            }
            get
            {
                return second;
            }
        }
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,args);
            }
        }

        void OnTimerTick(object sender,EventArgs args)
        {
            DateTime dt = DateTime.Now;
            Hour = dt.Hour;
            Min = dt.Minute;
            Second = dt.Second;
        }
    }
}
