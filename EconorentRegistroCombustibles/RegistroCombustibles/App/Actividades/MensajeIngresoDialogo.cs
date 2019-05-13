using Android.App;
using Android.OS;
using RegistroCombustibles.Presenter.PresenterDialog;
using RegistroCombustibles.Utilitarios;

namespace RegistroCombustibles
{
    /// <summary>
    /// Mensaje ingreso dialogo.
    /// </summary>
    [Activity(ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MensajeIngresoDialogo : Activity
    {
        static Dialog customDialog = null;
        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.dialogo_mensajeingreso);
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
        /// Views the dialogo ingreso combustible ok.
        /// </summary>
        /// <param name="activity">Activity.</param>
        public static void viewDialogoIngresoCombustibleOK(Activity activity)
        {
            MensajeIngresoPresenter.viewMensajeDialogo(activity, customDialog);
        }
    }
}