using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Inzynierka.ViewModels;


namespace Inzynierka
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RentHistory : ContentPage
    {
        ObservableCollection<MyItem> myItems = new ObservableCollection<MyItem>();
        public ObservableCollection<MyItem> MyItems { get { return myItems; } }
       
        public RentHistory()
        {
            InitializeComponent();
            listViewm.ItemsSource = myItems;
            myItems.Add(new MyItem() { Switch = true, Addend1 = 1, Addend2 = 2 });
            myItems.Add(new MyItem() { Switch = false, Addend1 = 1, Addend2 = 2 });
            myItems.Add(new MyItem() { Switch = true, Addend1 = 2, Addend2 = 3 });
            myItems.Add(new MyItem() { Switch = false, Addend1 = 2, Addend2 = 3 });






            

            
            

        }
    }


    
}