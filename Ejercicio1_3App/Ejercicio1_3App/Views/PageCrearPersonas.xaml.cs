using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ejercicio1_3App.Controllers;
using Ejercicio1_3App.Models;

namespace Ejercicio1_3App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCrearPersonas : ContentPage
    {
        public PageCrearPersonas()
        {
            InitializeComponent();
        }

        private async void btnagregar_Clicked(object sender, EventArgs e)
        {
            var persona = new Personas
            {
                nombres = nombre.Text,
                apellidos = apellido.Text,
                edad = Convert.ToInt32(edad.Text),
                correo = correo.Text,
                direccion = direccion.Text
            };

            var resultado = await App.BaseDatos.PersonaGuardar(persona);

            if (resultado != 0)
            {
                await DisplayAlert("Aviso", "Persona Ingresada con Exito!!!", "Ok");
            }
            else
            {
                await DisplayAlert("Aviso", "Ha Ocurrido un Error", "Ok");
            }

            await Navigation.PopAsync();
        }

    }
}