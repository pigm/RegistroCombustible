using Android.App;
using Android.OS;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using RegistroCombustibles.Common.Utils.Utilitarios;
using RegistroCombustibles.Presenter.PresenterActivity;
using RegistroCombustibles.Utilitarios;

namespace RegistroCombustibles
{
    /// <summary>
    /// Main activity.
    /// </summary>
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme.Splash", MainLauncher = true, ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            try
            {
                AppCenter.Start("bd3a519b-80ac-4f59-8f54-c8726076fcc3", typeof(Analytics), typeof(Crashes));
                DataManager.AppCenterActive = true;
            } 
            catch
            {
                DataManager.AppCenterActive = false;
            }
        }

        /// <summary>
        /// Ons the resume.
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
            MainPresenter.inicioApp(this);
            BluetoothActivate.Disconnected();
        }
    }
}