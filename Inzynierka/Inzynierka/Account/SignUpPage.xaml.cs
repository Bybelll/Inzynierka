using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inzynierka
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            DBConnect dBConnect = new DBConnect();

            if (passwordEntry.Text == repeatPasswordEntry.Text)
            {
                errorLabel.Text = "Hasła nie sa identyczne";
            }
            else if(dBConnect.InsertUsers(nameEntry.Text, surmnameEntry.Text, (int)ageSlider.Value, 0, loginEntry.Text, passwordEntry.Text))
            {
                Navigation.PopAsync();
            }
            else
            {
                errorLabel.Text = "Rejestracja nie powiodła się";
            }
        }
    }
}