using System;
using System.Globalization;
using Android.App;
using Android.Content;
using Android.Widget;
using FR.Ganfra.Materialspinner;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RegistroCombustibles.Common.Models.Modelo;
using RegistroCombustibles.Common.Services.Delegate;
using RegistroCombustibles.Common.Utils.Properties;
using RegistroCombustibles.Common.Utils.Utilitarios;

namespace RegistroCombustibles.Presenter.PresenterActivity
{
    /// <summary>
    /// Ingreso combustible presenter.
    /// </summary>
    public class IngresoCombustiblePresenter
    {
        /// <summary>
        /// Spinnerses the cargados.
        /// </summary>
        public static void spinnersCargados(Activity activity, MaterialSpinner msCombustibleInicial, MaterialSpinner msCombustibleFinal, MaterialSpinner msMotivo)
        {
            String[] lvCombustibleInicial = { "E", "1/8", "1/4", "3/8", "1/2", "5/8", "3/4", "7/8", "F" };
            ArrayAdapter<String> adapterLvCombustibleInicial = new ArrayAdapter<String>(activity, Android.Resource.Layout.SimpleSpinnerItem, lvCombustibleInicial);
            adapterLvCombustibleInicial.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            msCombustibleInicial.Adapter = adapterLvCombustibleInicial;
            msCombustibleInicial.SetPaddingSafe(0, 0, 0, 0);
            if (!string.IsNullOrEmpty(DataManager.DatosPatioAuto.NivelGas))
                DataManager.SpinnerPosition = adapterLvCombustibleInicial.GetPosition(DataManager.DatosPatioAuto.NivelGas);
            String[] lvCombustibleFinal = { "E", "1/8", "1/4", "3/8", "1/2", "5/8", "3/4", "7/8", "F" };
            ArrayAdapter<String> adapterLvCombustibleFinal = new ArrayAdapter<String>(activity, Android.Resource.Layout.SimpleSpinnerItem, lvCombustibleFinal);
            adapterLvCombustibleFinal.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            msCombustibleFinal.Adapter = adapterLvCombustibleFinal;
            msCombustibleFinal.SetPaddingSafe(0, 0, 0, 0);

            String[] motivos = { "Vehículo nuevo", "Reposición carga cliente", "Cliente LOP", "Unidad en traslado", "Uso interno" };
            ArrayAdapter<String> adapterMotivos = new ArrayAdapter<String>(activity, Android.Resource.Layout.SimpleSpinnerItem, motivos);
            adapterMotivos.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            msMotivo.Adapter = adapterMotivos;
            msMotivo.SetPaddingSafe(0, 0, 0, 0);
        }

        public static void cargaInfoVehiculo(Activity activity
            , TextView lblMarcaModeloCar
            , TextView lblPatente
            , TextView lblColor
            , TextView lblCapacidadEstanque
            , TextView lblCombustible
            , EditText txtKilometraje
            , MaterialSpinner msCombustibleInicial)
        {
            string marcaModelo = "";
            if (!string.IsNullOrEmpty(DataManager.DatosPatioAuto.Marca)
             || !string.IsNullOrEmpty(DataManager.DatosPatioAuto.Modelo)){
                marcaModelo = DataManager.DatosPatioAuto.Marca + " " + DataManager.DatosPatioAuto.Modelo;
                lblMarcaModeloCar.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(marcaModelo.ToLower());
            }else
            {
                if(!string.IsNullOrEmpty(DataManager.DatosPatioAuto.Marca)
                && !string.IsNullOrEmpty(DataManager.DatosPatioAuto.Modelo))
                {
                    marcaModelo = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DataManager.DatosPatioAuto.Marca.ToLower());                        
                }
                else
                {
                    marcaModelo = "Vehículo no informado";
                }
                lblMarcaModeloCar.Text = marcaModelo;
            }
            if (!string.IsNullOrEmpty(DataManager.DatosPatioAuto.Patente))
                lblPatente.Text = DataManager.DatosPatioAuto.Patente.ToUpper();
            else
                lblPatente.Text = "-- --";
            if (!string.IsNullOrEmpty(DataManager.DatosPatioAuto.Color))
                lblColor.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DataManager.DatosPatioAuto.Color.ToLower());
            else
                lblColor.Text = "-- --";
            if (!string.IsNullOrEmpty(DataManager.DatosPatioAuto.LitrosTanque))
                lblCapacidadEstanque.Text = DataManager.DatosPatioAuto.LitrosTanque + " Litros";
            else
                lblCapacidadEstanque.Text = "-- --";
            if (!string.IsNullOrEmpty(DataManager.DatosPatioAuto.GasDesc))
                lblCombustible.Text = DataManager.DatosPatioAuto.GasDesc;
            else
                lblCombustible.Text = "-- --";
            if (!string.IsNullOrEmpty(DataManager.DatosPatioAuto.KmsAuto))
                txtKilometraje.Text = DataManager.DatosPatioAuto.KmsAuto;
            if (!string.IsNullOrEmpty(DataManager.DatosPatioAuto.NivelGas))
                msCombustibleInicial.SetSelection(DataManager.SpinnerPosition + 1);

        }

        /// <summary>
        /// Buttons the cancelar.
        /// </summary>
        /// <param name="activity">Activity.</param>
        public static void btnCancelar(Activity activity)
        {
            Intent iAIngresoAuto = new Intent(activity, typeof(IngresoCodigoAutoActivity));
            activity.StartActivity(iAIngresoAuto);
        }

        /// <summary>
        /// Registrars the combustible.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="msCombustibleInicial">Ms combustible inicial.</param>
        /// <param name="msCombustibleFinal">Ms combustible final.</param>
        /// <param name="msMotivo">Ms motivo.</param>
        /// <param name="txtKilometraje">Text kilometraje.</param>
        /// <param name="txtLitrosCargados">Text litros cargados.</param>
        /// <param name="txtObservaciones">Text observaciones.</param>
        public static async void RegistrarCombustible(Activity activity
            , MaterialSpinner msCombustibleInicial
            , MaterialSpinner msCombustibleFinal
            , MaterialSpinner msMotivo
            , EditText txtKilometraje
            , EditText txtLitrosCargados
            , EditText txtObservaciones)
        {
            if (!msCombustibleInicial.SelectedItem.ToString().Equals("Nivel de combustible inicial")
             && !msCombustibleFinal.SelectedItem.ToString().Equals("Nivel de combustible final")
             && !msMotivo.SelectedItem.ToString().Equals("Motivo")
             && !string.IsNullOrEmpty(txtKilometraje.Text)
             && !string.IsNullOrEmpty(txtLitrosCargados.Text))
            { double fraccion = IngresoCombustiblePresenter.CombustibleInicialLitros(msCombustibleInicial);
                double litrosCarga = (Double.Parse(DataManager.DatosPatioAuto.LitrosTanque) - fraccion) + 10;
                var litrosDouble = txtLitrosCargados.Text.Replace(",", ".");
                if (double.Parse(litrosDouble) < litrosCarga)
                {
                    if (string.IsNullOrEmpty(DataManager.DatosPatioAuto.NivelGas))
                    {
                        DataManager.DatosPatioAuto.NivelGas = msCombustibleInicial.SelectedItem.ToString();
                    }
                    if (DataManager.DatosPatioAuto.KmsAuto == "0")
                    {
                        DataManager.DatosPatioAuto.KmsAuto = txtKilometraje.Text.Replace(".", "");
                    }
                    PatioCargarGas patioCargarGas = new PatioCargarGas
                    {
                        PatenteAuto = DataManager.DatosPatioAuto.Patente,
                        KmsAuto = DataManager.DatosPatioAuto.KmsAuto,
                        NivelGasSalida = msCombustibleFinal.SelectedItem.ToString(),
                        NivelGasEntrada = DataManager.DatosPatioAuto.NivelGas,
                        LitrosCargados = txtLitrosCargados.Text.Replace(".", ""),
                        CodigoEmpleado = DataManager.CodigoUsuario.ToString(),
                        CodigoAgencia = DataManager.SucursalSeleccionada.Codigo.ToString(),
                        Motivo = msMotivo.SelectedItem.ToString(),
                        Observacion = txtObservaciones.Text,
                        KmsAutoING = txtKilometraje.Text.Replace(".", ""),
                        NivelGasEntradaING = msCombustibleInicial.SelectedItem.ToString()
                    };
                    string postData = JsonConvert.SerializeObject(patioCargarGas);
                    var cargaGas = await ServiceDelegate.Instance.CargaGas(JObject.Parse(postData));
                    if (cargaGas.Success)
                    {
                        LoadingDialogo.viewLoadingShow(activity, 2);
                        MensajeIngresoDialogo.viewDialogoIngresoCombustibleOK(activity);
                    }
                    else
                    {
                        var responseErr = Convert.ToInt32(cargaGas.Response);
                        if (responseErr == 1000)
                        {
                            LoadingDialogo.viewLoadingShow(activity, 2);
                            IngresoCombustiblePresenter.mensajeAndroid(activity
                                , ConstantesApp.MENSAJE_NOT_CONNECTION_INTERNET
                                , ConstantesApp.BTN_ACEPTAR
                                , null
                                , false
                                , "busquedaAutoSinInternet");
                        }
                        else if (responseErr == 9)
                        {
                            LoadingDialogo.viewLoadingShow(activity, 2);
                            IngresoCombustiblePresenter.mensajeAndroid(activity
                                , ConstantesApp.MENSAJE_DATOS_INVALIDOS_LOGIN
                                , ConstantesApp.BTN_ACEPTAR
                                , null
                                , false
                                , "Error al ingresar los datos");
                        }
                        else
                        {
                            LoadingDialogo.viewLoadingShow(activity, 2);
                            IngresoCombustiblePresenter.mensajeAndroid(activity
                                , ConstantesApp.MSJ_ERROR_INESPERADO
                                , ConstantesApp.BTN_ACEPTAR
                                , null
                                , false
                                , "busquedaAutoError");
                        }
                    }
                }
                else
                {
                    LoadingDialogo.viewLoadingShow(activity, 2);
                    Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(activity);
                    builder.SetTitle(ConstantesApp.APP_NAME);
                    builder.SetIcon(Resource.Mipmap.ic_app);
                    builder.SetCancelable(false);
                    builder.SetMessage("Los litros de combustible a cargar debe ser menor a " + litrosCarga);
                    builder.SetPositiveButton(ConstantesApp.BTN_ACEPTAR, delegate {
                        
                    });     
                    builder.Show();
                }
            }
            else
            {
                LoadingDialogo.viewLoadingShow(activity, 2);
                IngresoCombustiblePresenter.mensajeAndroid(activity, ConstantesApp.INFO_INCOMPLETA, ConstantesApp.BTN_ACEPTAR, null, false, "infoIncompleta");
            }
        }

        /// <summary>
        /// Mensajes the android.
        /// </summary>
        /// <param name="activity">Activity.</param>
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
                if (action.Equals("infoIncompleta")){}
            });
            builder.SetNegativeButton(negativeButton, delegate {});
            builder.Show();
        }

        /// <summary>
        /// Combustibles the inicial litros.
        /// </summary>
        /// <param name="msCombustibleInicial">Lv combustible inicio.</param>
        public static double CombustibleInicialLitros(MaterialSpinner msCombustibleInicial)
        {
            double valorCargaLitros = 0;
            if (!string.IsNullOrEmpty(DataManager.DatosPatioAuto.LitrosTanque))
            {
                if (msCombustibleInicial.SelectedItem.ToString().Equals("F"))
                {
                    valorCargaLitros = double.Parse(DataManager.DatosPatioAuto.LitrosTanque);
                }else if (msCombustibleInicial.SelectedItem.ToString().Equals("1/8"))
                {
                    valorCargaLitros = double.Parse(DataManager.DatosPatioAuto.LitrosTanque) / 8; 
                }
                else if (msCombustibleInicial.SelectedItem.ToString().Equals("1/4"))
                {
                    valorCargaLitros = double.Parse(DataManager.DatosPatioAuto.LitrosTanque) / 4;
                }
                else if (msCombustibleInicial.SelectedItem.ToString().Equals("3/8"))
                {
                    valorCargaLitros = (double.Parse(DataManager.DatosPatioAuto.LitrosTanque) * 3) / 8;
                }
                else if (msCombustibleInicial.SelectedItem.ToString().Equals("1/2"))
                {
                    valorCargaLitros = double.Parse(DataManager.DatosPatioAuto.LitrosTanque) / 2;
                }
                else if (msCombustibleInicial.SelectedItem.ToString().Equals("5/8"))
                {
                    valorCargaLitros = (double.Parse(DataManager.DatosPatioAuto.LitrosTanque) * 5) / 8;
                }
                else if (msCombustibleInicial.SelectedItem.ToString().Equals("3/4"))
                {
                    valorCargaLitros = (double.Parse(DataManager.DatosPatioAuto.LitrosTanque) * 3) / 4;
                }
                else if (msCombustibleInicial.SelectedItem.ToString().Equals("7/8"))
                {
                    valorCargaLitros = (double.Parse(DataManager.DatosPatioAuto.LitrosTanque) * 7) / 8;
                }
                else //E
                {
                    valorCargaLitros = 0.0;
                }
            }
            return valorCargaLitros;
        }

    }
}