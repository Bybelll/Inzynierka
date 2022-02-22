using System;
using Xamarin.Forms;

namespace Inzynierka
{
    public partial class SignPage : ContentPage
    {
        public SignPage()
        {
            InitializeComponent();
            
        }

        private void OnSignInButtonClicked(object sender, EventArgs e)
        {
            
        }

        private void OnCreateAccauntButtonCLicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            Navigation.PushAsync(new SignUpPage());
        }
    }
}