using Android.App;
using Android.OS;
using RegistroCombustibles.Presenter.PresenterDialog;

namespace RegistroCombustibles.AppDialog
{
    /// <summary>
    /// Close app dialog.
    /// </summary>
    [Activity(Theme = "@style/ThemeNoActionBarLogin", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class CloseAppDialog : Activity
    {
        static Dialog customDialog = null;
        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.dialog_close_app);
        }

        /// <summary>
        /// Views the dialogo salir app.
        /// </summary>
        /// <param name="activity">Activity.</param>
        public static void ViewDialogoSalirApp(Activity activity)
        {
            CloseAppPresenter.ViewMensajeDialogo(activity, customDialog);
        }
    }
}
