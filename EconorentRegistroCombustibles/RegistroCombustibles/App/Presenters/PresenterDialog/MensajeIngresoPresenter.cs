using System;
using Android.App;
using Android.Content;
using Android.Widget;

namespace RegistroCombustibles.Presenter.PresenterDialog
{
    /// <summary>
    /// Mensaje ingreso presenter.
    /// </summary>
    public class MensajeIngresoPresenter
    {
        /// <summary>
        /// Views the mensaje dialogo.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="customDialog">Custom dialog.</param>
        public static void viewMensajeDialogo(Activity activity, Dialog customDialog)
        {
            customDialog = new Dialog(activity, Resource.Style.Theme_Dialog_Translucent);
            customDialog.SetCancelable(false);
            customDialog.SetContentView(Resource.Layout.dialogo_mensajeingreso);
            LinearLayout llBtnIngresoCombustibleOK = customDialog.FindViewById<LinearLayout>(Resource.Id.llBtnIngresoCombustibleOK);
            llBtnIngresoCombustibleOK.Click += delegate {
                Intent iAIngresoAuto = new Intent(activity, typeof(IngresoCodigoAutoActivity));
                activity.StartActivity(iAIngresoAuto);
            };
            customDialog.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
            customDialog.Show();
        }
    }
}
