using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using RegistroCombustibles.Adapters;
using RegistroCombustibles.Common.Models.Services;
using RegistroCombustibles.Common.Utils.Utilitarios;
using RegistroCombustibles.Utilitarios;

namespace RegistroCombustibles.Actividades
{
    [Activity(Theme = "@style/ThemeNoActionBarToolbar", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
            Android.Content.PM.ConfigChanges.Orientation,
            ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class SucursalesActivity : AppCompatActivity
    {
        AdapterListaSucursales adapter;
        LinearLayoutManager layoutManager;
        LinearLayout llPanelSinSucursales;
        List<Sucursal> oficinasRegion;
        List<Sucursal> oficinasCombustibleTrue;
        RecyclerView rvListaSucursales;

        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_sucursales);
            layoutManager = new LinearLayoutManager(this);
            llPanelSinSucursales = FindViewById<LinearLayout>(Resource.Id.llPanelSinSucursales);
            rvListaSucursales = FindViewById<RecyclerView>(Resource.Id.rvListaSucursales);
            oficinasRegion = new List<Sucursal>();
            oficinasCombustibleTrue = new List<Sucursal>();
        }

        /// <summary>
        /// Ons the resume.
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
            BluetoothActivate.Disconnected();
            if (DataManager.Sucursales != null)
            {
                foreach (var auxRegion in DataManager.Sucursales)
                {
                    if (auxRegion.Region == DataManager.Region)
                    {
                        oficinasRegion.Add(auxRegion);
                    }
                }
                if (oficinasRegion != null)
                {
                    foreach (var auxCombustible in oficinasRegion)
                    {
                        if (auxCombustible.Combustible == 1)
                        {
                            oficinasCombustibleTrue.Add(auxCombustible);
                        }
                    }

                    if (oficinasCombustibleTrue.Count >= 1)
                    {
                        llPanelSinSucursales.Visibility = ViewStates.Gone;
                        rvListaSucursales.Visibility = ViewStates.Visible;
                        adapter = new AdapterListaSucursales(oficinasCombustibleTrue, this);
                        adapter.itemClick += OnItemClick;
                        rvListaSucursales.SetAdapter(adapter);
                        rvListaSucursales.SetLayoutManager(layoutManager);
                    }
                    else
                    {
                        llPanelSinSucursales.Visibility = ViewStates.Visible;
                        rvListaSucursales.Visibility = ViewStates.Gone;
                    }
                }
            }
            else
            {
                llPanelSinSucursales.Visibility = ViewStates.Visible;
                rvListaSucursales.Visibility = ViewStates.Gone;
            }

        }

        //EVENTO CLICK ITEMS RECYCLERVIEW
        /// <summary>
        /// Ons the item click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void OnItemClick(object sender, List<Object> e)
        {
            StartActivity(new Intent(this, typeof(IngresoCodigoAutoActivity)), ActivityOptions.MakeSceneTransitionAnimation(this).ToBundle());
        }

        /// <summary>
        /// Ons the back pressed.
        /// </summary>
        public override void OnBackPressed()
        {
            StartActivity(new Intent(this, typeof(LoginActivity)), ActivityOptions.MakeSceneTransitionAnimation(this).ToBundle()); Finish();
        }
    }
}
