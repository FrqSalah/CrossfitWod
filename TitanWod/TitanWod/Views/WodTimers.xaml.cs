﻿using CrossfitTitans.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrossfitTitans.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WodTimers : ContentPage
	{
		public WodTimers()
		{
			InitializeComponent ();
            BindingContext = new WodTimersViewModel(Navigation);
        }
	}
}