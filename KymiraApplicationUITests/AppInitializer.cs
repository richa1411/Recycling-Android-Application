using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace KymiraApplicationUITests
{
	public class AppInitializer
	{
		public static IApp StartApp(Platform platform)
		{
            return ConfigureApp.Android.EnableLocalScreenshots().ApkFile("com.cosmoindustries.kymira").StartApp();
		}
	}
}