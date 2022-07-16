using Ejercicio2.Models;
using NativeMedia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ejercicio2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnGuardarSQLite_Clicked(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtDescrpcion.Text != "")
            {
                Stream streamTest = await firmaSPV.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
                StreamReader reader = new StreamReader(await firmaSPV.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Jpeg));
                byte[] bytedata = System.Text.Encoding.Default.GetBytes(reader.ReadToEnd());
                string strBase64 = Convert.ToBase64String(bytedata);
                Firma firma = new Firma
                {
                    Titulo = txtNombre.Text,
                    Descripcion = txtDescrpcion.Text,
                    FirmaPic = strBase64
                };
                await App.SQLiteDB.SaveFirmaAsync(firma);
                var status = await Permissions.RequestAsync<SaveMediaPermission>();

                if (status != PermissionStatus.Granted)
                    return;
                await MediaGallery.SaveAsync(MediaFileType.Image, streamTest, "asdad.jpeg");
                txtDescrpcion.Text = "";
                txtNombre.Text = "";
                firmaSPV.Clear();

                await DisplayAlert("Registro", "Registro añadido exitosamente", "OK");
                //Stream image = await firmaSPV.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
                //using (FileStream file = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),String.Concat(txtNombre.Text,".png")), FileMode.Create, System.IO.FileAccess.Write))
                //
                    //image.CopyTo(file);
                //}

            }
            else
            {
                await DisplayAlert("Error", "Debe llenar todos los datos", "OK");
            }
        }

        private async void btnLista_Clicked(object sender, EventArgs e)
        {
            Page page = new SecondPage();
            await Navigation.PushAsync(page);
        }
    }
}
