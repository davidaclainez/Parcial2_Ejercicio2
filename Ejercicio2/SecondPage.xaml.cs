using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
            llenarDatos();
        }
        public async void llenarDatos()
        {
            Console.WriteLine("____________________");
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            Console.WriteLine("____________________");
            var FirmasList = await App.SQLiteDB.GetFirmasAsync();
            if (FirmasList!= null)
            {
                lstFirmas.ItemsSource = FirmasList;
            }
        }
    }
}