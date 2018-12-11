using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace KymiraApplicationUITests
{
	public class AppInitializer
	{
		public static IApp StartApp(Platform platform)
		{
            return ConfigureApp.Android.EnableLocalScreenshots().ApkFile("G:\\PRJ2.Cosmo\\prj2.cosmo\\KymiraApplication\\bin\\Release\\com.cosmoindustries.kymira-Signed.apk").StartApp();
		}
	}
}