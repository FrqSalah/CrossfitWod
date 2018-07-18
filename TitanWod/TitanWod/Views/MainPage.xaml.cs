using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TitanWod.Helpers.MenuItems;

namespace TitanWod.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : MasterDetailPage
    {
		public MainPage ()
		{
			InitializeComponent ();

            masterPage.ListView.ItemSelected += OnItemSelected;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var item = e.SelectedItem as MasterPageItem;
                if (item != null)
                {
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                    masterPage.ListView.SelectedItem = null;
                    IsPresented = false;
                }
            }
            catch (Exception ex) { }
        }
    }
}