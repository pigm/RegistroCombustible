using System;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RegistroCombustibles.Common.Models.Modelo;
using RegistroCombustibles.Common.Models.Services;
using RegistroCombustibles.Common.Services.Delegate;
using RegistroCombustibles.Common.Utils.Properties;
using RegistroCombustibles.Common.Utils.Utilitarios;
using RegistroCombustibles.Utilitarios;

namespace RegistroCombustibles.Presenter.PresenterActivity
{
    /// <summary>
    /// Ingreso codigo auto presenter.
    /// </summary>
    public class IngresoCodigoAutoPresenter
    {
        /// <summary>
        /// Cerrars the sesion.
        /// </summary>
        /// <param name="activity">Activity.</param>
        public static void cerrarSesion(Activity activity)
        {
            activity.StartActivity(new Intent(activity, typeof(LoginActivity)));
        }

        public static PatioDatosAutoModel objectoRequest(string txtPatente, string txtCodigoVehiculo, string txtChasis)
        {
            PatioDatosAutoModel patioDatosAuto = null;
            if (!string.IsNullOrEmpty(txtPatente))
            {
                patioDatosAuto = new PatioDatosAutoModel
                {
                    PatenteAuto = txtPatente,
                    CodigoAuto = "",
                    Chasis = ""
                };
            }
            else if (!string.IsNullOrEmpty(txtCodigoVehiculo))
            {
                patioDatosAuto = new PatioDatosAutoModel
                {
                    PatenteAuto = "",
                    CodigoAuto = txtCodigoVehiculo,
                    Chasis = ""
                };
            }
            else if (!string.IsNullOrEmpty(txtChasis))
            {
                patioDatosAuto = new PatioDatosAutoModel
                {
                    PatenteAuto = "",
                    CodigoAuto = "",
                    Chasis = txtChasis
                };
            }

            return patioDatosAuto;

        }

        /// <summary>
        /// Buscars the vehiculo.
        /// </summary>
        /// <param name="activity">Activity.</param>
        public static void buscarVehiculo(Activity activity
            , int tipoBusqueda
            , EditText txtPatente
            , EditText txtChasis
            , EditText txtCodigoVehiculo
            , ImageView btnPistola
            , ImageView btnPatente
            , ImageView btnChasis
            , LinearLayout llBtnPistola
            , LinearLayout llBtnPatente
            , LinearLayout llBtnChasis
            , LinearLayout llPanelIngresoPistola
            , LinearLayout llPanelIngresoPatente
            , LinearLayout llPanelIngresoChasis
            , LinearLayout llBtnBuscarBarCode)
        {
            try{
                if (tipoBusqueda == 1)//Pistola petente
                {
                    if (!string.IsNullOrEmpty(txtPatente.Text))
                    {
                        PatioDatosAutoModel patioDatosAuto = objectoRequest(txtPatente.Text.ToUpper(), null, null);
                        string postData = JsonConvert.SerializeObject(patioDatosAuto);
                        IngresoCodigoAutoPresenter.wsPatioAutos(activity
                            , postData
                            , txtPatente
                            , txtChasis
                            , txtCodigoVehiculo
                            , btnPistola
                            , btnPatente
                            , btnChasis
                            , llBtnPistola
                            , llBtnPatente
                            , llBtnChasis
                            , llPanelIngresoPistola
                            , llPanelIngresoPatente
                            , llPanelIngresoChasis
                            , llBtnBuscarBarCode);
                    }
                    else
                    {
                        LoadingDialogo.viewLoadingShow(activity, 2);
                        IngresoCodigoAutoPresenter.mensajeAndroid(activity
                        , ConstantesApp.MENSAJE_DATOS_INVALIDOS_LOGIN
                        , ConstantesApp.BTN_ACEPTAR
                        , null
                        , false
                        , "datosInvalidos"
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null);
                    }
                }
                else if (tipoBusqueda == 2)//codigo
                {
                    if (!string.IsNullOrEmpty(txtCodigoVehiculo.Text))
                    {
                        PatioDatosAutoModel patioDatosAuto = objectoRequest(null, txtCodigoVehiculo.Text.ToUpper(), null);
                        string postData = JsonConvert.SerializeObject(patioDatosAuto);
                        IngresoCodigoAutoPresenter.wsPatioAutos(activity
                        , postData
                        , txtPatente
                        , txtChasis
                        , txtCodigoVehiculo
                        , btnPistola
                        , btnPatente
                        , btnChasis
                        , llBtnPistola
                        , llBtnPatente
                        , llBtnChasis
                        , llPanelIngresoPistola
                        , llPanelIngresoPatente
                        , llPanelIngresoChasis
                        , llBtnBuscarBarCode);
                    }
                    else
                    {
                        LoadingDialogo.viewLoadingShow(activity, 2);
                        IngresoCodigoAutoPresenter.mensajeAndroid(activity
                        , ConstantesApp.MENSAJE_DATOS_INVALIDOS_LOGIN
                        , ConstantesApp.BTN_ACEPTAR
                        , null
                        , false
                        , "datosInvalidos"
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null);
                    }

                }
                else if (tipoBusqueda == 3)//Chasis
                {
                    if (!string.IsNullOrEmpty(txtChasis.Text))
                    {
                        PatioDatosAutoModel patioDatosAuto = objectoRequest(null, null, txtChasis.Text.ToUpper());
                        string postData = JsonConvert.SerializeObject(patioDatosAuto);
                        IngresoCodigoAutoPresenter.wsPatioAutos(activity
                            , postData
                            , txtPatente
                            , txtChasis
                            , txtCodigoVehiculo
                            , btnPistola
                            , btnPatente
                            , btnChasis
                            , llBtnPistola
                            , llBtnPatente
                            , llBtnChasis
                            , llPanelIngresoPistola
                            , llPanelIngresoPatente
                            , llPanelIngresoChasis
                            , llBtnBuscarBarCode);
                    }
                    else
                    {
                        LoadingDialogo.viewLoadingShow(activity, 2);
                        IngresoCodigoAutoPresenter.mensajeAndroid(activity
                        , ConstantesApp.MENSAJE_DATOS_INVALIDOS_LOGIN
                        , ConstantesApp.BTN_ACEPTAR
                        , null
                        , false
                        , "datosInvalidos"
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null);
                    }
                }
                else
                {
                    LoadingDialogo.viewLoadingShow(activity, 2);
                    IngresoCodigoAutoPresenter.mensajeAndroid(activity
                        , ConstantesApp.MSJ_ERROR_INESPERADO
                        , ConstantesApp.BTN_ACEPTAR
                        , null
                        , false
                        , "busquedaError"
                        , txtPatente
                        , txtChasis
                        , txtCodigoVehiculo
                        , btnPistola
                        , btnPatente
                        , btnChasis
                        , llBtnPistola
                        , llBtnPatente
                        , llBtnChasis
                        , llPanelIngresoPistola
                        , llPanelIngresoPatente
                        , llPanelIngresoChasis
                        , llBtnBuscarBarCode);
                }


            }
            catch{
                LoadingDialogo.viewLoadingShow(activity, 2);
                IngresoCodigoAutoPresenter.mensajeAndroid(activity
                        , ConstantesApp.MSJ_ERROR_INESPERADO
                        , ConstantesApp.BTN_ACEPTAR
                        , null
                        , false
                        , "busquedaError"
                        , txtPatente
                        , txtChasis
                        , txtCodigoVehiculo
                        , btnPistola
                        , btnPatente
                        , btnChasis
                        , llBtnPistola
                        , llBtnPatente
                        , llBtnChasis
                        , llPanelIngresoPistola
                        , llPanelIngresoPatente
                        , llPanelIngresoChasis
                        , llBtnBuscarBarCode);
            }
        }

        private static async void wsPatioAutos(Activity activity
                        , string postData
                        , EditText txtPatente
                        , EditText txtChasis
                        , EditText txtCodigoVehiculo
                        , ImageView btnPistola
                        , ImageView btnPatente
                        , ImageView btnChasis
                        , LinearLayout llBtnPistola
                        , LinearLayout llBtnPatente
                        , LinearLayout llBtnChasis
                        , LinearLayout llPanelIngresoPistola
                        , LinearLayout llPanelIngresoPatente
                        , LinearLayout llPanelIngresoChasis
                        , LinearLayout llBtnBuscarBarCode)
        {
            var datosPatioAuto = await ServiceDelegate.Instance.GetVehiculo(JObject.Parse(postData));
            if (datosPatioAuto.Success)
            {
                DataManager.DatosPatioAuto = datosPatioAuto.Response as DatosPatioAutoResult;
                Intent iAIngresoCombustible = new Intent(activity, typeof(IngresoCombustibleActivity));
                activity.StartActivity(iAIngresoCombustible);
                LoadingDialogo.viewLoadingShow(activity, 2);
            }
            else
            {
                var responseErr = Convert.ToInt32(datosPatioAuto.Response);
                if (responseErr == 1000)
                {
                    LoadingDialogo.viewLoadingShow(activity, 2);
                    IngresoCodigoAutoPresenter.mensajeAndroid(activity
                        , ConstantesApp.MENSAJE_NOT_CONNECTION_INTERNET
                        , ConstantesApp.BTN_ACEPTAR
                        , null
                        , false
                        , "busquedaAutoSinInternet"
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null
                        , null);
                }
                else if (responseErr == 8)
                {
                    LoadingDialogo.viewLoadingShow(activity, 2);
                    IngresoCodigoAutoPresenter.mensajeAndroid(activity
                        , ConstantesApp.MENSAJE_VEHICULO_NO_EXISTE
                        , ConstantesApp.BTN_ACEPTAR
                        , null
                        , false
                        , "vehiculoNoExiste"
                        , txtPatente
                        , txtChasis
                        , txtCodigoVehiculo
                        , btnPistola
                        , btnPatente
                        , btnChasis
                        , llBtnPistola
                        , llBtnPatente
                        , llBtnChasis
                        , llPanelIngresoPistola
                        , llPanelIngresoPatente
                        , llPanelIngresoChasis
                        , llBtnBuscarBarCode);
                }
                else
                {
                    LoadingDialogo.viewLoadingShow(activity, 2);
                    IngresoCodigoAutoPresenter.mensajeAndroid(activity
                        , ConstantesApp.MSJ_ERROR_INESPERADO
                        , ConstantesApp.BTN_ACEPTAR
                        , null
                        , false
                        , "busquedaAutoError"
                        , txtPatente
                        , txtChasis
                        , txtCodigoVehiculo
                        , btnPistola
                        , btnPatente
                        , btnChasis
                        , llBtnPistola
                        , llBtnPatente
                        , llBtnChasis
                        , llPanelIngresoPistola
                        , llPanelIngresoPatente
                        , llPanelIngresoChasis
                        , llBtnBuscarBarCode);
                }

            }
            txtCodigoVehiculo.Text = "";
            txtPatente.Text = "";
            txtChasis.Text = "";
        }

        /// <summary>
        /// Estados the componentes user interface.
        /// </summary>
        /// <param name="click">Click.</param>
        /// <param name="btnPistola">Button pistola.</param>
        /// <param name="btnPatente">Button patente.</param>
        /// <param name="btnChasis">Button chasis.</param>
        /// <param name="llBtnPistola">Ll button pistola.</param>
        /// <param name="llBtnPatente">Ll button patente.</param>
        /// <param name="llBtnChasis">Ll button chasis.</param>
        public static void estadoComponentesUI(Activity activity
            , int click
            , ImageView btnPistola
            , ImageView btnPatente
            , ImageView btnChasis
            , LinearLayout llBtnPistola
            , LinearLayout llBtnPatente
            , LinearLayout llBtnChasis
            , LinearLayout llPanelIngresoPistola
            , LinearLayout llPanelIngresoPatente
            , LinearLayout llPanelIngresoChasis
            , LinearLayout llBtnBuscarBarCode)
        {
            if (click == 1)
            {
                DataManager.TipoBusqueda = 1;
                btnPistola.SetImageResource(Resource.Drawable.ic_pistolaon);
                btnPatente.SetImageResource(Resource.Drawable.ic_patenteoff);
                btnChasis.SetImageResource(Resource.Drawable.ic_chasisoff);
                llBtnPistola.SetBackgroundResource(Resource.Color.colorBlanco);
                llBtnPatente.SetBackgroundResource(Resource.Color.colorFondoPantallaBusqueda);
                llBtnChasis.SetBackgroundResource(Resource.Color.colorFondoPantallaBusqueda);
                llPanelIngresoPistola.Visibility = ViewStates.Visible;
                llPanelIngresoPatente.Visibility = ViewStates.Gone;
                llPanelIngresoChasis.Visibility = ViewStates.Gone;
                llBtnBuscarBarCode.Visibility = ViewStates.Visible;
                BluetoothActivate.Activated();
            }
            else if (click == 2)
            {
                DataManager.TipoBusqueda = 2;
                btnPistola.SetImageResource(Resource.Drawable.ic_pistolaoff);
                btnPatente.SetImageResource(Resource.Drawable.ic_patenteon);
                btnChasis.SetImageResource(Resource.Drawable.ic_chasisoff);
                llBtnPistola.SetBackgroundResource(Resource.Color.colorFondoPantallaBusqueda);
                llBtnPatente.SetBackgroundResource(Resource.Color.colorBlanco);
                llBtnChasis.SetBackgroundResource(Resource.Color.colorFondoPantallaBusqueda);
                llPanelIngresoPistola.Visibility = ViewStates.Gone;
                llPanelIngresoPatente.Visibility = ViewStates.Visible;
                llPanelIngresoChasis.Visibility = ViewStates.Gone;
                llBtnBuscarBarCode.Visibility = ViewStates.Visible;
                BluetoothActivate.Disconnected();
            }
            else
            {
                DataManager.TipoBusqueda = 3;
                btnPistola.SetImageResource(Resource.Drawable.ic_pistolaoff);
                btnPatente.SetImageResource(Resource.Drawable.ic_patenteoff);
                btnChasis.SetImageResource(Resource.Drawable.ic_chasison);
                llBtnPistola.SetBackgroundResource(Resource.Color.colorFondoPantallaBusqueda);
                llBtnPatente.SetBackgroundResource(Resource.Color.colorFondoPantallaBusqueda);
                llBtnChasis.SetBackgroundResource(Resource.Color.colorBlanco);
                llPanelIngresoPistola.Visibility = ViewStates.Gone;
                llPanelIngresoPatente.Visibility = ViewStates.Gone;
                llPanelIngresoChasis.Visibility = ViewStates.Visible;
                llBtnBuscarBarCode.Visibility = ViewStates.Visible;
                BluetoothActivate.Disconnected();
            }
        }

        /// <summary>
        /// Refreshs the view.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="txtPatente">Text patente.</param>
        /// <param name="txtChasis">Text chasis.</param>
        /// <param name="btnPistola">Button pistola.</param>
        /// <param name="btnPatente">Button patente.</param>
        /// <param name="btnChasis">Button chasis.</param>
        /// <param name="llBtnPistola">Ll button pistola.</param>
        /// <param name="llBtnPatente">Ll button patente.</param>
        /// <param name="llBtnChasis">Ll button chasis.</param>
        /// <param name="llPanelIngresoPistola">Ll panel ingreso pistola.</param>
        /// <param name="llPanelIngresoPatente">Ll panel ingreso patente.</param>
        /// <param name="llPanelIngresoChasis">Ll panel ingreso chasis.</param>
        /// <param name="llBtnBuscarBarCode">Ll button buscar bar code.</param>
        public static void refreshView(Activity activity
            , EditText txtPatente
            , EditText txtChasis
            , EditText txtCodigoAuto
            , ImageView btnPistola
            , ImageView btnPatente
            , ImageView btnChasis
            , LinearLayout llBtnPistola
            , LinearLayout llBtnPatente
            , LinearLayout llBtnChasis
            , LinearLayout llPanelIngresoPistola
            , LinearLayout llPanelIngresoPatente
            , LinearLayout llPanelIngresoChasis
            , LinearLayout llBtnBuscarBarCode)
        {
            DataManager.TipoBusqueda = 1;
            txtPatente.Text = "";
            txtChasis.Text = "";
            txtCodigoAuto.Text = "";
            btnPistola.SetImageResource(Resource.Drawable.ic_pistolaoff);
            btnPatente.SetImageResource(Resource.Drawable.ic_patenteon);
            btnChasis.SetImageResource(Resource.Drawable.ic_chasisoff);
            llBtnPistola.SetBackgroundResource(Resource.Color.colorFondoPantallaBusqueda);
            llBtnPatente.SetBackgroundResource(Resource.Color.colorBlanco);
            llBtnChasis.SetBackgroundResource(Resource.Color.colorFondoPantallaBusqueda);
            llPanelIngresoPistola.Visibility = ViewStates.Gone;
            llPanelIngresoPatente.Visibility = ViewStates.Visible;
            llPanelIngresoChasis.Visibility = ViewStates.Gone;
            llBtnBuscarBarCode.Visibility = ViewStates.Visible;
        }

        /// <summary>
        /// Mensajes the android.
        /// </summary>
        /// <param name="mensaje">Mensaje.</param>
        /// <param name="positiveButton">Positive button.</param>
        /// <param name="negativeButton">Negative button.</param>
        /// <param name="cancelable">If set to <c>true</c> cancelable.</param>
        /// <param name="action">Action.</param>
        public static void mensajeAndroid(Activity activity
            , string mensaje
            , string positiveButton
            , string negativeButton
            , bool cancelable
            , string action
            , EditText txtPatente
            , EditText txtChasis
            , EditText txtCodigoAuto
            , ImageView btnPistola
            , ImageView btnPatente
            , ImageView btnChasis
            , LinearLayout llBtnPistola
            , LinearLayout llBtnPatente
            , LinearLayout llBtnChasis
            , LinearLayout llPanelIngresoPistola
            , LinearLayout llPanelIngresoPatente
            , LinearLayout llPanelIngresoChasis
            , LinearLayout llBtnBuscarBarCode)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(activity);
            builder.SetTitle(ConstantesApp.APP_NAME);
            builder.SetIcon(Resource.Mipmap.ic_app);
            builder.SetCancelable(cancelable);
            builder.SetMessage(mensaje);
            builder.SetPositiveButton(positiveButton, delegate {
                if (action.Equals("busquedaError")
                 || action.Equals("vehiculoNoExiste")
                 || action.Equals("busquedaAutoError"))
                {
                    //IngresoCodigoAutoPresenter.refreshView(activity, txtPatente, txtChasis, txtCodigoAuto, btnPistola, btnPatente, btnChasis, llBtnPistola, llBtnPatente, llBtnChasis, llPanelIngresoPistola, llPanelIngresoPatente, llPanelIngresoChasis, llBtnBuscarBarCode);
                }else if (action.Equals("datosInvalidos")
                       || action.Equals("busquedaAutoSinInternet")
                       || action.Equals("infoBluethooth")) { }
                else{ }
            });
            builder.SetNegativeButton(negativeButton, delegate { });
            builder.Show();
        }
    }
}