﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrossfitTitans
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }
        public MasterPage()
        {
            InitializeComponent();
        }
    }
}