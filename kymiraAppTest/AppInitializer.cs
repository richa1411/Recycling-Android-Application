using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace kymiraAppTest
{
	public class AppInitializer
	{
		public static IApp StartApp(Platform platform)
		{
			if (platform == Platform.Android)
			{
				return ConfigureApp.Android.InstalledApp("com.cosmoindustries.kymira").StartApp();
			}

			return ConfigureApp.iOS.StartApp();
		}
	}
}