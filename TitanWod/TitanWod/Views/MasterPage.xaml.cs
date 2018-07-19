using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitanWod.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TitanWod.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPage : ContentPage
	{
        public ListView ListView { get { return listView; } }

        public MasterPage()
        {
            BindingContext = new MasterPageViewModel();
            InitializeComponent();
        }
    }
}