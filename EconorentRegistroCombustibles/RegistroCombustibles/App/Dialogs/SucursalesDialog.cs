using Android.App;
using Android.OS;
using RegistroCombustibles.Presenter.PresenterDialog;

namespace RegistroCombustibles.AppDialog
{
    /// <summary>
    /// Sucursales dialog.
    /// </summary>
    [Activity(Theme = "@style/ThemeNoActionBarLogin", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class SucursalesDialog : Activity
    {
        static Dialog customDialog = null;
        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.dialog_sucursales);
        }

        /// <summary>
        /// Views the dialogo selecciona sucursal.
        /// </summary>
        /// <param name="activity">Activity.</param>
        public static void ViewDialogoSeleccionaSucursal(Activity activity)
        {
            SucursalesPresenter.ViewMensajeDialogo(activity, customDialog);
        }
    }
}
