using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TestGUIBinCollectionDate
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            //deploy the app to the emulator and the emulator has to be running

            //get the app manifest that will have the name of the file
            return ConfigureApp.Android.InstalledApp("com.cosmoindustries.kymira").StartApp();
        }
    }
}