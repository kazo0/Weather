﻿using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Core;

namespace Weather
{
	public static class Resolver
	{
		private static IContainer _container;

		public static void Initialize(IContainer container)
		{
			_container = container;
		}

		public static T Resolve<T>()
		{
			return _container.Resolve<T>();
		}
	}
}
