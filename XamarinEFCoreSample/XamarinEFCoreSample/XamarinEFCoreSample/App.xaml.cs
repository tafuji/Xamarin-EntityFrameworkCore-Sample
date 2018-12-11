using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinEFCoreSample.Models;
using XamarinEFCoreSample.Views;
using Microsoft.EntityFrameworkCore;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinEFCoreSample
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            InitializeDatabase();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void InitializeDatabase()
        {
            SQLitePCL.Batteries_V2.Init();
            using (var context = new TodoDbContext())
            {
                context.Database.Migrate();
            }
        }
    }
}
