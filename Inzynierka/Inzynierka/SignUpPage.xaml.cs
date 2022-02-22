using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }
            else
            {
                Console.WriteLine("Passwords do not match");
            }
            Navigation.PopAsync();
        }
    }
}