using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrossfitTitans.ViewModel
{
    class StopWatchViewModel : INotifyPropertyChanged
    {
        public int Minutes { get; set; }
        public int Secondes { get; set; } 
        public int MilliSecondes { get; set; }
        public string numericCounter { get; set; }
        public bool IsRunning { get; set; }

        public double hourHandRotation { get; set; }
        public double minuteHandRotation { get; set; }
        public double secondHandRotation { get; set; }


        #region Event 
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {

                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Command
        public Command StartCount { get; }
        public Command PauseCount { get; }
        public Command StopCount { get; }
        #endregion


        public StopWatchViewModel()
        {
            StartCount = new Command(StartEvent);
            PauseCount = new Command(PauseEvent);
            StopCount = new Command(StopEvent);
        }

        #region Methodes
        private void StartEvent(object obj)
        {
            if (!IsRunning)
            {
                IsRunning = true;
                Device.StartTimer(TimeSpan.FromSeconds(1 / 60), OnTimerClick);
            }
        }

        private void PauseEvent(object obj)
        {
            if (IsRunning)
            {
                IsRunning = false;
                Device.StartTimer(TimeSpan.FromSeconds(1 / 60), OnTimerClick);
            }
        }

        private void StopEvent(object obj)
        {
            IsRunning = false;
            Device.StartTimer(TimeSpan.FromSeconds(0), OnTimerClick);
            MilliSecondes = 00;
            Secondes = 00;
            Minutes = 00;
            OnPropertyChanged("MilliSecondes");
            OnPropertyChanged("Secondes");
            OnPropertyChanged("Minutes");

            hourHandRotation = 0;
            minuteHandRotation = 0;
            secondHandRotation = 0;

            OnPropertyChanged("hourHandRotation");
            OnPropertyChanged("minuteHandRotation");
            OnPropertyChanged("secondHandRotation");
        }

        #endregion

        private bool OnTimerClick()
        {
            if (IsRunning)
            {
                MilliSecondes++;
                OnPropertyChanged("MilliSecondes");
                if (MilliSecondes > 59)
                {
                    Secondes++;
                    MilliSecondes = 00;
                    OnPropertyChanged("Secondes");
                }
                if (Secondes > 59)
                {
                    Secondes = 00;
                    Minutes++;
                    OnPropertyChanged("Minutes");
                }

                OnTimerTick();
            }
            return IsRunning;
        }

        private bool OnTimerTick()
        {
            // Set rotation angles for hour and minute hands.
            //DateTime dateTime = DateTime.Now;
            hourHandRotation = 30 * Minutes;
            minuteHandRotation = 6 * Secondes;

            // Do an animation for the second hand.
            double t = MilliSecondes / 1000.0;

            if (t < 0.5)
            {
                t = 0.5 * Easing.SpringIn.Ease(t / 0.5);
            }
            else
            {
                t = 0.5 * (1 + Easing.SpringOut.Ease((t - 0.5) / 0.5));
            }

            secondHandRotation = 6 * (MilliSecondes + t);

            OnPropertyChanged("hourHandRotation");
            OnPropertyChanged("minuteHandRotation");
            OnPropertyChanged("secondHandRotation");
            return true;
        }
    }
}
