using CrossfitTitans.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrossfitTitans.ViewModel
{
    class TabataViewModel : INotifyPropertyChanged
    {
        public Tabata TabatWod = new Tabata();

        public int Minutes { get; set; }
        public int Secondes { get; set; }
        public int MilliSecondes { get; set; }

        public string WorkOrRelax { get; set; }
        public int WorkCounter { get; set; }
        public int RelaxCounter { get; set; }
        public int RoundsCounter { get; set; }

        public bool IsRunning { get; set; }

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


        public TabataViewModel()
        {
            StartCount = new Command(StartEvent);
            StopCount = new Command(StopEvent);

            TabatWod.Rounds = 8;
            TabatWod.Work = 20;
            TabatWod.Relax = 10;
        }

        #region Methodes
        /// <summary>
        /// Start the tabata workout
        /// </summary>
        /// <param name="obj"></param>
        private void StartEvent(object obj)
        {
            if (!IsRunning)
            {
                IsRunning = true;
                Device.StartTimer(TimeSpan.FromSeconds(1 / 60), OnTimerClick);
            }
        }

        /// <summary>
        /// Stop tabata workout
        /// </summary>
        /// <param name="obj"></param>
        private void StopEvent(object obj)
        {

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
                    WorkCounter++;
                    MilliSecondes = 00;
                    OnPropertyChanged("Secondes");
                }
                if (Secondes > 59)
                {
                    Secondes = 00;
                    Minutes++;
                    OnPropertyChanged("Minutes");
                }

                //Tant que le temps passé est inférieur à la duré du wod continuer
                if (WorkCounter < TabatWod.Work)
                {
                    WorkOrRelax = "Work";
                    OnPropertyChanged("WorkOrRelax");
                }
                else // Si on dépassé la duré du wod commencer le repos
                {
                    if (MilliSecondes > 59)
                    {
                        RelaxCounter++;
                    }
                        WorkOrRelax = "Relax";
                    OnPropertyChanged("WorkOrRelax");
                }

                // Si le temps du repos est fini. On remet tout à 0 et on déclare un round de plus
                if(RelaxCounter == TabatWod.Relax)
                {
                    WorkCounter = 0;
                    RelaxCounter = 0;
                    RoundsCounter++;
                    OnPropertyChanged("RoundsCounter");
                }
            }
            return IsRunning;
        }
    }
}
