using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FropCorn.Views;
using Xamarin.Forms;

namespace FropCorn
{
    public class App : Application
    {
        public App()
        {
			// The root page of your applicatio
			MainPage = new NavigationPage(new SearchPage());

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
    }
}
