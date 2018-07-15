using CarouselView.FormsPlugin.Abstractions;
using FFImageLoading.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace TitanWod.ViewModels
{
    class HomePageViewModel : INotifyPropertyChanged
    {
        public HomePageViewModel()
        {
            MyItemsSource = new ObservableCollection<View>()
            {
                new CachedImage() { Source = "homeSlide1.jpg", DownsampleToViewSize = true, Aspect = Aspect.AspectFill },
                new CachedImage() { Source = "homeSlide2.jpg", DownsampleToViewSize = true, Aspect = Aspect.AspectFill },
                new CachedImage() { Source = "homeSlide3.jpg", DownsampleToViewSize = true, Aspect = Aspect.AspectFill }
               // new CachedImage() { Source = "c3.jpg", DownsampleToViewSize = true, Aspect = Aspect.AspectFill }
            };

            MyCommand = new Command(() =>
            {
                Debug.WriteLine("Position selected.");
            });
        }

        ObservableCollection<View> _myItemsSource;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<View> MyItemsSource
        {
            set
            {
                _myItemsSource = value;
            }
            get
            {
                return _myItemsSource;
            }
        }

        public Command MyCommand { protected set; get; }

    }
}
