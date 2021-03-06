﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using WhooingTransactionMaker.Droid.Ports;

namespace WhooingTransactionMaker.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            global::Xamarin.Forms.DependencyService.Register<SubsystemUtilsPort>();

            LoadApplication(new App());
        }
    }
}