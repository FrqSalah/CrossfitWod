using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrossfitTitans.Views.Timers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountDown : ContentView
    {
        public CountDown()
        {
            InitializeComponent();
        }
    }
}