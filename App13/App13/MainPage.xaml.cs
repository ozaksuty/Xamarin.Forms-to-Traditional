using System;
using Xamarin.Forms;

namespace App13
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Subscribe<App, Tip>
                (this, "tip", (s, c) =>
            {
                DisplayAlert("Tip", $"tip : {c.tip.ToString("C")} total : {c.total.ToString("C")}", "OK");
                
            });
            DependencyService.Get<INativeScreen>().OpenNativeScreen();
        }
    }
}