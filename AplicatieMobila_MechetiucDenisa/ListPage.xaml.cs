using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicatieMobila_MechetiucDenisa.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicatieMobila_MechetiucDenisa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)   // event handler - la click pe butonul Save 
        {
            var clista = (CerinteLista)BindingContext;
            clista.Data = DateTime.UtcNow;
            await App.Database.SaveCerinteListaAsync(clista);  // se salveaza lista de cerinte 
            await Navigation.PopAsync();                       // si se deschide pagina precedenta, adica ListEntryPage
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)  // event handler - la click pe butonul Delete
        {
            var clista = (CerinteLista)BindingContext;
            await App.Database.DeleteCerinteListaAsync(clista);      // se sterge lista de cerinte
            await Navigation.PopAsync();                             // si se deschide pagina precedenta, adica ListEntryPage 
        }
        async void OnChooseButtonClicked(object sender, EventArgs e)   // event handler - la click pe buton 
        {
            await Navigation.PushAsync(new ApartamentePage((CerinteLista)this.BindingContext)   // se deschide pagina ApartamentePage si se pot adauga cerintele dorite in lista 
            {
                BindingContext = new Apartamente()
            });
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var cerintel = (CerinteLista)BindingContext;

            listView.ItemsSource = await App.Database.GetListaApartamentesAsync(cerintel.ID);
        }
    }
}