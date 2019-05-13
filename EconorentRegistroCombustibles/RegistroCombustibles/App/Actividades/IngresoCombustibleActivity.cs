using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using FR.Ganfra.Materialspinner;
using RegistroCombustibles.Presenter.PresenterActivity;
using RegistroCombustibles.Utilitarios;

namespace RegistroCombustibles
{
    /// <summary>
    /// Ingreso combustible activity.
    /// </summary>
    [Activity(Label = "Ingreso Combustible", Theme = "@style/ThemeNoActionBarYellow", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class IngresoCombustibleActivity : Activity
    {
        EditText txtKilometraje, txtLitrosCargados, txtObservaciones;
        LinearLayout llBtnBack;
        LinearLayout llBtnCancelarRegistro, llBtnRegistrarCombustible;
        MascarasTextWatcher mascarasTextWatcherNumeroSeparadorMiles, mascarasTextWatcherNumeroDecimales;
        MaterialSpinner msCombustibleInicial, msCombustibleFinal, msMotivo;
        TextView lblMarcaModeloCar, lblPatente, lblColor, lblCapacidadEstanque, lblCombustible;
        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_ingresocombustible);
            txtKilometraje = FindViewById<EditText>(Resource.Id.txtKilometraje);
            txtLitrosCargados = FindViewById<EditText>(Resource.Id.txtLitrosCargados);
            txtObservaciones = FindViewById<EditText>(Resource.Id.txtObservaciones);
            llBtnBack = FindViewById<LinearLayout>(Resource.Id.llBtnBack);
            llBtnCancelarRegistro = FindViewById<LinearLayout>(Resource.Id.llBtnCancelarRegistro);
            llBtnRegistrarCombustible = FindViewById<LinearLayout>(Resource.Id.llBtnRegistrarCombustible);
            msCombustibleInicial = FindViewById<MaterialSpinner>(Resource.Id.msCombustibleInicial);
            msCombustibleFinal = FindViewById<MaterialSpinner>(Resource.Id.msCombustibleFinal);
            msMotivo = FindViewById<MaterialSpinner>(Resource.Id.msMotivo);
            lblMarcaModeloCar = FindViewById<TextView>(Resource.Id.lblMarcaModeloCar);
            lblPatente = FindViewById<TextView>(Resource.Id.lblPatente);
            lblColor = FindViewById<TextView>(Resource.Id.lblColor);
            lblCapacidadEstanque = FindViewById<TextView>(Resource.Id.lblCapacidadEstanque);
            lblCombustible = FindViewById<TextView>(Resource.Id.lblCombustible);

            txtLitrosCargados.ImeOptions = Android.Views.InputMethods.ImeAction.Done;
            llBtnBack.Click += delegate { Finish(); };
            llBtnCancelarRegistro.Click += delegate { IngresoCombustiblePresenter.btnCancelar(this); };
            llBtnRegistrarCombustible.Click += delegate {
                LoadingDialogo.viewLoadingShow(this, 1);
                IngresoCombustiblePresenter.RegistrarCombustible(this, msCombustibleInicial, msCombustibleFinal, msMotivo, txtKilometraje, txtLitrosCargados, txtObservaciones); 
            };

            mascarasTextWatcherNumeroSeparadorMiles = new MascarasTextWatcher(txtKilometraje, this, MascarasTextWatcher.TIPO_ENTERO);
            txtKilometraje.AddTextChangedListener(mascarasTextWatcherNumeroSeparadorMiles);
            mascarasTextWatcherNumeroDecimales = new MascarasTextWatcher(txtLitrosCargados, this, MascarasTextWatcher.TIPO_DECIMAL);
            txtLitrosCargados.AddTextChangedListener(mascarasTextWatcherNumeroDecimales);
            IngresoCombustiblePresenter.spinnersCargados(this, msCombustibleInicial, msCombustibleFinal, msMotivo);
            IngresoCombustiblePresenter.cargaInfoVehiculo(this, lblMarcaModeloCar, lblPatente, lblColor, lblCapacidadEstanque, lblCombustible, txtKilometraje, msCombustibleInicial);
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
        /// Ons the back pressed.
        /// </summary>
        public override void OnBackPressed(){ base.OnBackPressed(); }
    }
}