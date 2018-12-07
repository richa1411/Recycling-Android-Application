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
            //return ConfigureApp.Android.InstalledApp("com.cosmoindustries.kymira").StartApp();


            //Will need to change this for the time being to our individual apk location on our PC
            return ConfigureApp.Android.EnableLocalScreenshots().ApkFile("G:\\COSACPMG\\prj2.cosmo\\KymiraApplication\\bin\\Release\\com.cosmoindustries.kymira-Signed.apk").StartApp();
            
            //TAYLOR: //G:\\COSACPMG\\prj2.cosmo\\KymiraApplication\\bin\\Release\\


            //RICHA:  //G:\\KymiraApp\\prj2.cosmo\\KymiraApplication\\bin\\Release\\
        }


    }
}