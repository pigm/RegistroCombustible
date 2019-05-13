using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Widget;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RegistroCombustibles.Actividades;
using RegistroCombustibles.AppDialog;
using RegistroCombustibles.Common.Models.Modelo;
using RegistroCombustibles.Common.Models.Services;
using RegistroCombustibles.Common.Services.Delegate;
using RegistroCombustibles.Common.Utils.Properties;
using RegistroCombustibles.Common.Utils.Utilitarios;
using RegistroCombustibles.Utilitarios;

namespace RegistroCombustibles.Presenter.PresenterActivity
{
    /// <summary>
    /// Login presenter.
    /// </summary>
    public class LoginPresenter
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
                if (action.Equals("OnBackPressed") || action.Equals("caida"))
                {
                    Cerrar.closeApplication(activity);
                }
                else if (action.Equals("loginSinInternet")
                      || action.Equals("loginError")
                      || action.Equals("loginDatosInvalidos")) { }
            });
            builder.SetNegativeButton(negativeButton, delegate {
                if (action.Equals("OnBackPressed")) { }
            });
            builder.Show();
        }

        /// <summary>
        /// Logins the action.
        /// </summary>
        public static async void loginAction(Activity activity, EditText txtUser, EditText txtPassword)
        {

            if (!string.IsNullOrEmpty(txtUser.Text) &&
                !string.IsNullOrEmpty(txtPassword.Text))
            {
                LoginModel loginUser = new LoginModel
                {
                    Usuario = txtUser.Text,
                    Clave = txtPassword.Text,
                    Dispositivo = ""
                };

                string postData = JsonConvert.SerializeObject(loginUser);
                var login = await ServiceDelegate.Instance.UserLogin(JObject.Parse(postData));
                if (login.Success)
                {
                    var responseLogin = login.Response as LoginResult;                  
                    if (responseLogin.Estado == 200)
                    {
                        DataManager.NombreUsuario = txtUser.Text;
                        DataManager.CodigoUsuario = responseLogin.Codigo_Usuario;
                        DataManager.Region = responseLogin.Region;

                        /// DataManager.CodigoAgencia = DataManager.Sucursales.Where(x => x.Nombre == nombreSucursal).FirstOrDefault().Codigo;
                        /// activity.StartActivity(new Intent(activity, typeof(IngresoCodigoAutoActivity)););
                        ///activity.StartActivity(new Intent(activity, typeof(SucursalesActivity)));
                        LoadingDialogo.viewLoadingShow(activity, 2);
                        txtUser.Text = "";
                        txtPassword.Text = "";
                        txtUser.RequestFocus();
                        SucursalesDialog.ViewDialogoSeleccionaSucursal(activity);
                    }
                    else if (responseLogin.Estado == 0)
                    {
                        LoginPresenter.mensajeAndroid(activity, ConstantesApp.MENSAJE_DATOS_INVALIDOS_LOGIN, ConstantesApp.BTN_ACEPTAR, null, false, "loginDatosInvalidos");
                        LoadingDialogo.viewLoadingShow(activity, 2);
                    }
                    else
                    {
                        LoadingDialogo.viewLoadingShow(activity, 2);
                        LoginPresenter.mensajeAndroid(activity, ConstantesApp.MSJ_ERROR_INESPERADO, ConstantesApp.BTN_ACEPTAR, null, false, "loginError");

                    }

                }
                else
                {
                    try
                    {
                        int responseErr = Convert.ToInt32(login.Response);
                        if (responseErr == 1000)
                        {
                            LoginPresenter.mensajeAndroid(activity, ConstantesApp.MENSAJE_NOT_CONNECTION_INTERNET, ConstantesApp.BTN_ACEPTAR, null, false, "loginSinInternet");
                            LoadingDialogo.viewLoadingShow(activity, 2);
                        }
                        else
                        {
                            LoginPresenter.mensajeAndroid(activity, ConstantesApp.MSJ_ERROR_INESPERADO, ConstantesApp.BTN_ACEPTAR, null, false, "loginError");
                            LoadingDialogo.viewLoadingShow(activity, 2);
                        }
                    }
                    catch (Exception)
                    {
                        LoginPresenter.mensajeAndroid(activity, ConstantesApp.MSJ_ERROR_INESPERADO, ConstantesApp.BTN_ACEPTAR, null, false, "caida");
                        LoadingDialogo.viewLoadingShow(activity, 2);
                    }
                }
            }
            else
            {
                LoginPresenter.mensajeAndroid(activity, ConstantesApp.MENSAJE_DATOS_INVALIDOS_LOGIN, ConstantesApp.BTN_ACEPTAR, null, false, "loginDatosInvalidos");
                LoadingDialogo.viewLoadingShow(activity, 2);
            }
        }
    }  
}