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
    public partial class PageUpdatePersonas : ContentPage
    {
        public PageUpdatePersonas()
        {
            InitializeComponent();
        }

        private async void btnactualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id.Text))
            {

                Personas persona = new Personas()
                {
                    codigo = Convert.ToInt32(id.Text),
                    nombres = nombre.Text,
                    apellidos = apellido.Text,
                    edad = Convert.ToInt32(edad.Text),
                    correo = correo.Text,
                    direccion = direccion.Text
                };

                var resultado = await App.BaseDatos.PersonaGuardar(persona);

                if (resultado != 0)
                {
                    await DisplayAlert("Aviso", "Persona Actualizada con Exito!!!", "Ok");
                }
                else
                {
                    await DisplayAlert("Aviso", "Ha Ocurrido un Error", "Ok");
                }

                await Navigation.PopAsync();

            }
        }

        private async void btneliminar_Clicked(object sender, EventArgs e)
        {
            var persona = await App.BaseDatos.ObtenerPersona(Convert.ToInt32(id.Text));

            if (persona != null)
            {
                await App.BaseDatos.PersonaEliminar(persona);
                await DisplayAlert("Aviso", "Persona Eliminada con Exito!!!", "Ok");
            }
            else
            {
                await DisplayAlert("Aviso", "Ha Ocurrido un Error", "Ok");
            }

            await Navigation.PopAsync();
        }


    }
}