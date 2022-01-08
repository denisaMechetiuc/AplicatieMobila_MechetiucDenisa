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
    public partial class ListEntryPage : ContentPage
    {
        public ListEntryPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetCerinteListasAsync();
        }
        async void OnCerinteListaAddedClicked(object sender, EventArgs e)   // event handler - click pe ToolbarItem
        {
            await Navigation.PushAsync(new ListPage   //  se deschide pagina ListPage, in care se poate crea o lista noua si se pot adauga cerinte in ea 
            {
                BindingContext = new CerinteLista()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)   // event handler - click pe fiecare element din lista 
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ListPage   // se deschide pagina ListPage
                {
                    BindingContext = e.SelectedItem as CerinteLista
                });

            }
        }
        private async void OnSendButtonClicked(object sender, EventArgs e)  // event handler - click pe buton
            {
                await Navigation.PushAsync(new TrimiteLista());   // se deschide pagina TrimiteLista
            }
        }
    }
