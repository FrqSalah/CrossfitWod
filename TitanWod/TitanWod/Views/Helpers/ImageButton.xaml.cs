using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrossfitTitans.Views.Helpers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImageButton : ContentView
	{
        //Text
        public static readonly BindableProperty ButtonTextProprety =
            BindableProperty.Create("ButtonText", typeof(string), typeof(ImageButton), default(string));

        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProprety); }
            set { SetValue(ButtonTextProprety, value); }
        }

        public EventHandler Clicked;

        public static readonly BindableProperty CommandProprety =
            BindableProperty.Create("Command", typeof(ICommand), typeof(ImageButton), default(string));

        public ICommand Command;

        public ImageButton ()
		{
			InitializeComponent ();
		}
	}
}