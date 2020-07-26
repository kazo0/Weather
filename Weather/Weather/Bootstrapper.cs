using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;
using Weather.Services;
using Weather.ViewModels;
using Xamarin.Forms;

namespace Weather
{
	public static class Bootstrapper
	{
		public static void Init()
		{
			var containerBuilder = new ContainerBuilder();

			containerBuilder.RegisterType<OpenWeatherMapWeatherService>()
				.As<IWeatherService>();

			var types = Assembly.GetExecutingAssembly()
				.DefinedTypes
				.Where(t => t.IsSubclassOf(typeof(ViewModel)) ||
				            t.IsSubclassOf(typeof(Page)));

			foreach (var type in types)
			{
				containerBuilder.RegisterType(type.AsType());
			}

			Resolver.Initialize(containerBuilder.Build());
		}
	}
}
