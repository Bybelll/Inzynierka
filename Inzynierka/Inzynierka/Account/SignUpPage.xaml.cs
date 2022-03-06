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
                dBConnect.InsertUsers(nameEntry.Text, surmnameEntry.Text, (int)ageSlider.Value, 0, loginEntry.Text, passwordEntry.Text);
                Navigation.PopAsync();
            }
            else
            {
                Console.WriteLine("Passwords do not match");
                passwordIncorectLabel.Text = "Hasła nie są identyczne.";
            }
            
        }
    }
}