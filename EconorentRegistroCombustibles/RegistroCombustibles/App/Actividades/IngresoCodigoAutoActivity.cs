using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using RegistroCombustibles.Common.Utils.Utilitarios;
using RegistroCombustibles.Presenter.PresenterActivity;
using RegistroCombustibles.Utilitarios;

namespace RegistroCombustibles
{
    /// <summary>
    /// Ingreso codigo auto activity.
    /// </summary>
    [Activity(Label = "Ingreso BarCode", Theme = "@style/ThemeNoActionBarBlue", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class IngresoCodigoAutoActivity : Activity
    {
        EditText txtPatente, txtChasis, txtCodigoVehiculo;
        ImageView btnPistola, btnPatente, btnChasis;
        LinearLayout llPanelIngresoPistola, llPanelIngresoPatente, llPanelIngresoChasis, llPanelInfoBluetooth;
        LinearLayout llBtnPistola, llBtnPatente, llBtnChasis;
        LinearLayout llBtnCerrarSesion, llBtnBuscarBarCode, llBtnCleanInput;
        TextView lblNombreUsuario, lblNombreSucursalSesion;
        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_ingresocodigoauto);
            txtPatente = FindViewById<EditText>(Resource.Id.txtPatente);
            txtChasis = FindViewById<EditText>(Resource.Id.txtChasis);
            txtCodigoVehiculo = FindViewById<EditText>(Resource.Id.txtCodigoVehiculo);
            btnPistola = FindViewById<ImageView>(Resource.Id.btnPistola);
            btnPatente = FindViewById<ImageView>(Resource.Id.btnPatente);
            btnChasis = FindViewById<ImageView>(Resource.Id.btnChasis);
            llPanelIngresoPistola = FindViewById<LinearLayout>(Resource.Id.llPanelIngresoPistola);
            llPanelIngresoPatente = FindViewById<LinearLayout>(Resource.Id.llPanelIngresoPatente);
            llPanelIngresoChasis = FindViewById<LinearLayout>(Resource.Id.llPanelIngresoChasis);
            llPanelInfoBluetooth = FindViewById<LinearLayout>(Resource.Id.llPanelInfoBluetooth);
            llBtnPistola = FindViewById<LinearLayout>(Resource.Id.llBtnPistola);
            llBtnPatente = FindViewById<LinearLayout>(Resource.Id.llBtnPatente);
            llBtnChasis = FindViewById<LinearLayout>(Resource.Id.llBtnChasis);
            llBtnCerrarSesion = FindViewById<LinearLayout>(Resource.Id.llBtnCerrarSesion);
            llBtnCleanInput = FindViewById<LinearLayout>(Resource.Id.llBtnCleanInput);
            llBtnBuscarBarCode = FindViewById<LinearLayout>(Resource.Id.llBtnBuscarBarCode);
            lblNombreUsuario = FindViewById<TextView>(Resource.Id.lblNombreUsuario);
            lblNombreSucursalSesion = FindViewById<TextView>(Resource.Id.lblNombreSucursalSesion);
            llBtnCerrarSesion.Click += delegate { IngresoCodigoAutoPresenter.cerrarSesion(this); };
            llBtnBuscarBarCode.Click += delegate {
                llBtnBuscarBarCode.Enabled = false;
                LoadingDialogo.viewLoadingShow(this, 1);
                IngresoCodigoAutoPresenter.buscarVehiculo(this, DataManager.TipoBusqueda, txtPatente, txtChasis, txtCodigoVehiculo, btnPistola, btnPatente, btnChasis, llBtnPistola, llBtnPatente, llBtnChasis, llPanelIngresoPistola, llPanelIngresoPatente, llPanelIngresoChasis, llBtnBuscarBarCode);
                llBtnBuscarBarCode.Enabled = true;
            }; 
            BluetoothActivate.Activated();
            llBtnPistola.Click += delegate { llPanelInfoBluetooth.Visibility = ViewStates.Visible; IngresoCodigoAutoPresenter.estadoComponentesUI(this, 1, btnPistola, btnPatente, btnChasis, llBtnPistola, llBtnPatente, llBtnChasis, llPanelIngresoPistola, llPanelIngresoPatente, llPanelIngresoChasis, llBtnBuscarBarCode); };
            llBtnPatente.Click += delegate { llPanelInfoBluetooth.Visibility = ViewStates.Gone; IngresoCodigoAutoPresenter.estadoComponentesUI(this, 2, btnPistola, btnPatente, btnChasis, llBtnPistola, llBtnPatente, llBtnChasis, llPanelIngresoPistola, llPanelIngresoPatente, llPanelIngresoChasis, llBtnBuscarBarCode); };
            llBtnChasis.Click  += delegate { llPanelInfoBluetooth.Visibility = ViewStates.Gone; IngresoCodigoAutoPresenter.estadoComponentesUI(this, 3, btnPistola, btnPatente, btnChasis, llBtnPistola, llBtnPatente, llBtnChasis, llPanelIngresoPistola, llPanelIngresoPatente, llPanelIngresoChasis, llBtnBuscarBarCode); };
            llBtnCleanInput.Click += delegate { txtPatente.Text = ""; };
            lblNombreUsuario.Text = DataManager.NombreUsuario;
            lblNombreSucursalSesion.Text = "Sucursal " + DataManager.SucursalSeleccionada.Nombre;
        }

        /// <summary>
        /// Ons the resume.
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
           /// IngresoCodigoAutoPresenter.refreshView(this, txtPatente, txtChasis, btnPistola, btnPatente, btnChasis, llBtnPistola, llBtnPatente, llBtnChasis, llPanelIngresoPistola, llPanelIngresoPatente, llPanelIngresoChasis, llBtnBuscarBarCode);
           /// BluetoothActivate.Disconnected();
        }

        /// <summary>
        /// Ons the back pressed.
        /// </summary>
        public override void OnBackPressed(){}
    }
}