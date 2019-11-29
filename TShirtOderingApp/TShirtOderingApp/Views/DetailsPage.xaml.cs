using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TShirtOderingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage()
        {
            InitializeComponent();
        }

        public List<Tees> Tees { get; private set; }

       // private void Button_Clicked(object sender, EventArgs e);
    //    {
            
    //        var databaseContent = App.Database;
    //        Tees = await databaseContent.GetItemsAsync();
    //        var MyServerOrders = Tees.Select(x => new Tees()
    //        {
    //            Name = x.Name,
    //           Gender = x.Gender,
    //           Size = x.Size,
    //           Date = x.Date,
    //           Color = x.Color,
    //           Address = x.Address
    //        });
    //       var json = JsonConvert.SerializeObject(MyServerOrders);
    //        var client = new HttpClient();
    //        var url = "http://10.0.2.2:5000/tees";
    //        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

    //        var response = await client.PostAsync(url, content);
    //        await DisplayAlert("Response", response.ReasonPhrase, "ok");
    //    }
    }
}