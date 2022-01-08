using AplicatieMobila_MechetiucDenisa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicatieMobila_MechetiucDenisa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApartamentePage : ContentPage
    {
        CerinteLista cl;
        public ApartamentePage(CerinteLista clista)
        {
            InitializeComponent();
            cl = clista;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)   // event handler - la click pe butonul Save
        {
            var apartamente = (Apartamente)BindingContext;
            await App.Database.SaveApartamenteAsync(apartamente);    // se salveaza cerintele pt. un apartament
            listView.ItemsSource = await App.Database.GetApartamentesAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)  // event handler - la click pe butonul Delete
        {
            var apartamente = (Apartamente)BindingContext;
            await App.Database.DeleteApartamenteAsync(apartamente);   // se sterg cerintele pt. un apartament
            listView.ItemsSource = await App.Database.GetApartamentesAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetApartamentesAsync();
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)   // event handler - la click pe cerintele din lista 
        {

            Apartamente a;
            if (e.SelectedItem != null)
            {
                a = e.SelectedItem as Apartamente;
                var la = new ListaApartamente()
                {
                    CerinteListaID = cl.ID,
                    ApartamenteID = a.ID
                };
                await App.Database.SaveListaApartamenteAsync(la);    // se salveaza cerintele predefinite in lista de cerinte creata de catre client si apoi navigheaza la pagina ListPage 
                a.ListaApartamente = new List<ListaApartamente> { la };

                await Navigation.PopAsync();
            }

        }
    }
}