using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio1_3App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonasPage : ContentPage
    {
        public PersonasPage()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var pagina = new Views.PageCrearPersonas();
            await Navigation.PushAsync(pagina);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ListaPersonas.ItemsSource = await App.BaseDatos.listapersonas();
        }

        private async void ListaPersonas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                //await DisplayAlert("Aviso", "Has dado clik en una persona!!!", "Ok");
                Models.Personas item = (Models.Personas)e.Item;
                var newpage = new Views.PageUpdatePersonas();
                newpage.BindingContext = item;
                await Navigation.PushAsync(newpage);
            }
            catch(Exception ex)
            {
                await DisplayAlert("Aviso", ex.Message, "Ok");
            }
        }

    }
}