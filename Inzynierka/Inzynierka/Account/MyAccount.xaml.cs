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
    public partial class MyAccount : ContentPage
    {
        public MyAccount()
        {
            InitializeComponent();
        }

        private void OnRentHistoryButtonCLicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RentHistory());
        }

        private void OnMyDataButtonCLicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyDataPage());
        }
    }
}