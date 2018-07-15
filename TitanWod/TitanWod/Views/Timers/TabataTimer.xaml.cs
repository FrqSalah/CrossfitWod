using CrossfitTitans.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CrossfitTitans.Models;
namespace CrossfitTitans.Views.Timers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabataTimer : ContentPage
    {
        

        public TabataTimer()
        {
            InitializeComponent();
            BindingContext = new TabataViewModel();
        }
    }
}