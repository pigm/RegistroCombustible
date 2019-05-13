using Android.App;
using Android.OS;
using RegistroCombustibles.Utilitarios;

namespace RegistroCombustibles
{
    /// <summary>
    /// Loading dialogo.
    /// </summary>
    [Activity(ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class LoadingDialogo : Activity
    {
        static Dialog customDialog = null;
        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.dialogo_loading);
        }

        /// <summary>
        /// Ons the resume.
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
            BluetoothActivate.Disconnected();
        }

        /// <summary>
        /// Views the loading show.
        /// </summary>
        /// <param name="activity">Activity.</param>
        public static void viewLoadingShow(Activity activity, int codigo)
        {
            if (codigo == 1)
            {
                customDialog = new Dialog(activity, Resource.Style.Theme_Dialog_Translucent);
                customDialog.SetCancelable(false);
                customDialog.SetContentView(Resource.Layout.dialogo_loading);
                customDialog.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
                customDialog.Show();
            }
            else
            {
                if (customDialog != null)
                    customDialog.Dismiss();
            }
        }
    }
}