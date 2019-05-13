using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Util;
using RegistroCombustibles.Common.Models.Services;
using RegistroCombustibles.Common.Services.Delegate;
using RegistroCombustibles.Common.Utils.Properties;
using RegistroCombustibles.Common.Utils.Utilitarios;
using RegistroCombustibles.Utilitarios;

namespace RegistroCombustibles.Presenter.PresenterActivity
{
    /// <summary>
    /// Main presenter.
    /// </summary>
    public class MainPresenter
    {
        /// <summary>
        /// Mensajes the android.
        /// </summary>
        /// <param name="mensaje">Mensaje.</param>
        /// <param name="positiveButton">Positive button.</param>
        /// <param name="negativeButton">Negative button.</param>
        /// <param name="cancelable">If set to <c>true</c> cancelable.</param>
        /// <param name="action">Action.</param>
        public static void mensajeAndroid(Activity activity, string mensaje, string positiveButton, string negativeButton, bool cancelable, string action)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(activity);
            builder.SetTitle(ConstantesApp.APP_NAME);
            builder.SetIcon(Resource.Mipmap.ic_app);
            builder.SetCancelable(cancelable);
            builder.SetMessage(mensaje);
            builder.SetPositiveButton(positiveButton, delegate {
                if (action.Equals("mainSinSucursales") 
                 || action.Equals("caida")
                 || action.Equals("mainSinInternet")
                 || action.Equals("mainError"))
                {
                    Cerrar.closeApplication(activity);
                }
            });
            builder.SetNegativeButton(negativeButton, delegate {

            });
            builder.Show();
        }

        /// <summary>
        /// Inicios the app.
        /// </summary>
        /// <param name="activity">Activity.</param>
        public static void inicioApp(Activity activity)
        {
            try
            {
                Task startupWork = new Task(() =>
                {
                    Task.Delay(3000);
                });
                startupWork.ContinueWith(async t =>
                {
                    var branches = await ServiceDelegate.Instance.GetBranches();
                    if (branches.Success)
                    {
                        var responseBranches = branches.Response as SucursalesResult;
                        if (responseBranches.Estado == 200)
                        {
                            DataManager.Sucursales = responseBranches.Sucursales;
                            DataManager.Aeropuertos = responseBranches.Aeropuertos;
                            Intent iAlLogin = new Intent(activity, typeof(LoginActivity));
                            activity.StartActivity(iAlLogin);
                        }
                        else
                        {
                            MainPresenter.mensajeAndroid(activity, ConstantesApp.MSJ_ERROR_INESPERADO, ConstantesApp.BTN_ACEPTAR, null, false, "mainSinSucursales");
                        }
                    }
                    else
                    {
                        try
                        {
                            int responseErr = Convert.ToInt32(branches.Response);
                            if (responseErr == 1000)
                            {
                                MainPresenter.mensajeAndroid(activity, ConstantesApp.MENSAJE_NOT_CONNECTION_INTERNET, ConstantesApp.BTN_ACEPTAR, null, false, "mainSinInternet");
                            }
                            else
                            {
                                MainPresenter.mensajeAndroid(activity, ConstantesApp.MSJ_ERROR_INESPERADO, ConstantesApp.BTN_ACEPTAR, null, false, "mainError");
                            }
                        }
                        catch (Exception)
                        {
                            MainPresenter.mensajeAndroid(activity, ConstantesApp.MSJ_ERROR_INESPERADO, ConstantesApp.BTN_ACEPTAR, null, false, "caida");
                        }

                    }

                }, TaskScheduler.FromCurrentSynchronizationContext());
                startupWork.Start();
            }
            catch (Exception ex)
            {
                Log.Info("onResume()", ex.Message);
            }
        }
    }
}
