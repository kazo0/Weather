using System;
using Weather.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			Bootstrapper.Init();

			MainPage = new NavigationPage(Resolver.Resolve<MainView>());
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
