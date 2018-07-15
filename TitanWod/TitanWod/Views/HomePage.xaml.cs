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
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
            BindingContext = new HomePageViewModel();
		}
	}
}