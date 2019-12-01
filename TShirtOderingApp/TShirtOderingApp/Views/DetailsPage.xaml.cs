using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TShirtOderingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        //public List<Tees> Tees { get; private set; }
        public Tees MyItem { get; set; }
        public List<Tees> Tees { get; private set; }

        public DetailsPage(Tees tees)
        {
            InitializeComponent();

            MyItem = tees;
            BindingContext = MyItem;
            
        }
        protected  async override void OnAppearing()
        {
            base.OnAppearing();
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                // Connection to internet is available
                await DisplayAlert("internet", "all good", "ok");
            }

            if (current != NetworkAccess.Internet)
            {
                // Connection to internet is available
                await DisplayAlert("internet", "no internet", "ok");
            }
        }

       

        

        //private async void Button_Clicked(object sender, EventArgs e)
        //{
        //    var databaseContent = App.Database;
        //    Tees = await databaseContent.GetItemsAsync();
        //    var MyServerOrders = Tees.Select(x => new Tees()
        //   {
        //       Name = x.Name,
        //      Gender = x.Gender,
        //       Size = x.Size,
        //       Date = x.Date,
        //       Color = x.Color,
        //       Address = x.Address
        //   });
        //    var json = JsonConvert.SerializeObject(MyServerOrders);
        //    var client = new HttpClient();
        //    var url = "http://10.0.2.2:5000/tees";
        //    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        //    var response = await client.PostAsync(url, content);
        //    await DisplayAlert("Response", response.ReasonPhrase, "ok");
        //}

        private async void Button_Clicked_1(object sender, EventArgs e)
        {

           
            var OrderAddress = MyItem;

            var MapAddress = new MapClass();
            await MapAddress.GetLocation(OrderAddress.Address);



        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            {
                var databaseContent = App.Database;
                Tees = await databaseContent.GetItemsAsync();
                var MyServerOrders = Tees.Select(x => new Tees()
                {
                    Name = x.Name,
                    Gender = x.Gender,
                    Size = x.Size,
                    Date = x.Date,
                    Color = x.Color,
                    Address = x.Address
                });
                var json = JsonConvert.SerializeObject(MyServerOrders);
                var client = new HttpClient();
                var url = "http://10.0.2.2:5000/tees";
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                await DisplayAlert("Response", response.ReasonPhrase, "ok");
            }

        }

        //var info = App.Database;
        //Tees = await info.GetItemsAsync();

        //var address = string.Empty;

        //foreach(var order in Tees)
        //{
        //    address = order.Address;
        //}

        //var location = Geocoding.GetLocationsAsync(address);

        //await Map.OpenAsync(location, find);

        ////var tees = (Tees)BindingContext;

        ////var location = tees.Address;
        ////var MapAddress = new MapFunction();
        ////await MapAddress.GetLocation(location);


        ////await MapAddress.GetLocation(AdressPos.Address);

        //var location = new Xamarin.Essentials.Location(45.345535, -156.777399);
        //var options = new MapLaunchOptions { Name = "Sihle" };

        //await Map.OpenAsync(location, options);

    }






    }

//private async void button_clicked(object sender, eventargs e);
//        {

//         var databasecontent = app.database;
//tees = await databasecontent.getitemsasync();
//var myserverorders = tees.select(x => new tees()
//{
//    name = x.name,
//    gender = x.gender,
//    size = x.size,
//    date = x.date,
//    color = x.color,
//    address = x.address
//});
//var json = jsonconvert.serializeobject(myserverorders);
//var client = new httpclient();
//var url = "http://10.0.2.2:5000/tees";
//var content = new stringcontent(json, system.text.encoding.utf8, "application/json");

//var response = await client.postasync(url, content);
//await displayalert("response", response.reasonphrase, "ok");
//    }    



