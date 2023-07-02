using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace proyecto
{
    public partial class MainPage : ContentPage
    {
        private string Url = "http://192.168.1.247/pawpal/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<pawpal> post;
        public MainPage()
        {
            InitializeComponent();
            ObtenerDatos();
        }

        public async void ObtenerDatos()
        {
            var contenido = await cliente.GetStringAsync(Url);
            List<pawpal> listPost = JsonConvert.DeserializeObject<List<pawpal>>(contenido);
            post = new ObservableCollection<pawpal>(listPost);
            ListaPawpal.ItemsSource = post;
        }
        private void btnMostrar_Clicked(object sender, EventArgs e)
        {

        }
    }
}
