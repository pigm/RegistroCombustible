using Android.App;
using Android.Bluetooth;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using RegistroCombustibles.AppDialog;
using RegistroCombustibles.Common.Utils.Properties;
using RegistroCombustibles.Common.Utils.Utilitarios;
using RegistroCombustibles.Presenter.PresenterActivity;
using RegistroCombustibles.Utilitarios;

namespace RegistroCombustibles
{
    /// <summary>
    /// Login activity.
    /// </summary>
    [Activity(Theme = "@style/ThemeNoActionBarLogin", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class LoginActivity : AppCompatActivity
    {
        EditText txtUser, txtPassword;
        LinearLayout llBtnLogin;
        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);
            txtUser = FindViewById<EditText>(Resource.Id.txtUser);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            llBtnLogin = FindViewById<LinearLayout>(Resource.Id.llBtnLogin);
            llBtnLogin.Click += delegate {
                LoadingDialogo.viewLoadingShow(this, 1);
                LoginPresenter.loginAction(this, txtUser, txtPassword); 
            };
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
        public override void OnBackPressed()
        {
            CloseAppDialog.ViewDialogoSalirApp(this);
        }
    }
}