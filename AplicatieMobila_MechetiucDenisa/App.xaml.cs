using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using AplicatieMobila_MechetiucDenisa.Data;


namespace AplicatieMobila_MechetiucDenisa
{
    public partial class App : Application
    {
        static CerinteListaDatabase database;
        public static CerinteListaDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   CerinteListaDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CerinteLista.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListEntryPage());   // se deschide pagina ListEntryPage
        }

        
    }
}
