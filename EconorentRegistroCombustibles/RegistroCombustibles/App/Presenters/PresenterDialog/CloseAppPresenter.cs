using Android.App;
using Android.Widget;
namespace RegistroCombustibles.Presenter.PresenterDialog
{
    /// <summary>
    /// Close app presenter.
    /// </summary>
    public class CloseAppPresenter
    {
        /// <summary>
        /// Views the mensaje dialogo.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="customDialog">Custom dialog.</param>
        public static void ViewMensajeDialogo(Activity activity, Dialog customDialog)
        {
            customDialog = new Dialog(activity, Resource.Style.MyThemeTranslucent);
            customDialog.SetCancelable(false);
            customDialog.SetContentView(Resource.Layout.dialog_close_app);
            Button btnCancelarSalir = customDialog.FindViewById<Button>(Resource.Id.btnCancelarSalir);
            Button btnAceptarSalir = customDialog.FindViewById<Button>(Resource.Id.btnAceptarSalir);
            btnCancelarSalir.Click += delegate { customDialog.Dismiss(); };
            btnAceptarSalir.Click += delegate { activity.FinishAffinity(); };
            customDialog.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
            customDialog.Show();
        }
    }
}
