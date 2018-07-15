using CrossfitTitans.Views.Timers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrossfitTitans.ViewModel
{
    class WodTimersViewModel : INotifyPropertyChanged
    {
        INavigation Navigation;

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
        public Command StopWatch { get; }
        public Command CountDown { get; }
        public Command Lap { get; }
        public Command TabataWod { get; }
        #endregion

        public WodTimersViewModel(INavigation TimersNavigation)
        {
            StopWatch = new Command(StopWatchEvent);
            CountDown = new Command(CountDownEvent);
            TabataWod = new Command(TabataWodEvent);
            Lap = new Command(LapEvent);

            Navigation = TimersNavigation;
        }

        #region Methodes
        private async void LapEvent(object obj)
        {
            var lapPage = new StopWatch();
            await Navigation.PushModalAsync(lapPage);
        }

        private async void CountDownEvent(object obj)
        {
            var countDownPage = new StopWatch();
            await Navigation.PushModalAsync(countDownPage);
        }

        private async void StopWatchEvent(object obj)
        {
            try
            {
                var stopWatchPage = new StopWatch();
                await Navigation.PushModalAsync(stopWatchPage);
            } catch (Exception ex) { }
        }
        private async void TabataWodEvent(object obj)
        {
            try
            {
                var TabataWodPage = new TabataTimer();
                await Navigation.PushModalAsync(TabataWodPage);
            } catch (Exception ex) { }
        }
        #endregion
    }

}
