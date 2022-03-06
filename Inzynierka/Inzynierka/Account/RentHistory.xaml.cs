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
            myItems.Add(new MyItem() { Date = "22.01.2022 10:43", Time = 4, LenghtRoute = 1, StartPoint = "Kartuska 42A, 80-104 Gdańsk, Poland",FinishPoint= "Hucisko 04, 80-854 Gdańsk,Poland" });
            myItems.Add(new MyItem() { Date = "25.01.2022 8:15", Time = 4, LenghtRoute = 1.3, StartPoint = "Klesza 2, 80-833 Gdańsk, Poland", FinishPoint = "Klesza 2, 80-833 Gdańsk,Poland" });
            myItems.Add(new MyItem() { Date = "25.01.2022 15:18", Time = 4, LenghtRoute = 1.3, StartPoint = "Rajska 10, 80-850 Gdańsk, Poland", FinishPoint = "Rajska 10, 80-850 Gdańsk,Poland" });
            myItems.Add(new MyItem() { Date = "26.01.2022 20:36", Time = 31, LenghtRoute = 8.4, StartPoint = "Północna 13-7, 80-512 Gdańsk, Poland", FinishPoint = "Ogarna 116, 80-826 Gdańsk,Poland" });
            myItems.Add(new MyItem() { Date = "29.01.2022 10:04", Time = 46, LenghtRoute = 12, StartPoint = "Szara 41, 80-116 Gdańsk, Poland", FinishPoint = "Szyprów 1459, 80-335 Gdańsk,Poland" });
            myItems.Add(new MyItem() { Date = "30.01.2022 10:04", Time = 75, LenghtRoute = 3, StartPoint = "Morska 4, 80-341 Gdańsk, Poland", FinishPoint = "Cicha 2-4, 80-520 Gdańsk,Poland" });

            //myItems.Add(new MyItem() { Switch = false, Addend1 = 1, Addend2 = 2 });
            //myItems.Add(new MyItem() { Switch = true, Addend1 = 2, Addend2 = 3 });
            //myItems.Add(new MyItem() { Switch = false, Addend1 = 2, Addend2 = 3 });











        }
    }


    
}