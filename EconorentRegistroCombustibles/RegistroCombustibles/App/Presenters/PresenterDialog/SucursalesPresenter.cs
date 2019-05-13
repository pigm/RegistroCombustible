using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using RegistroCombustibles.Adapters;
using RegistroCombustibles.Common.Models.Services;
using RegistroCombustibles.Common.Utils.Utilitarios;
using RegistroCombustibles.Utilitarios;

namespace RegistroCombustibles.Presenter.PresenterDialog
{
    public class SucursalesPresenter
    {

        /// <summary>
        /// Views the mensaje dialogo.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="customDialog">Custom dialog.</param>
        public static void ViewMensajeDialogo(Activity activity, Dialog customDialog)
        {
            AdapterListaSucursales adapter;
            LinearLayoutManager layoutManager;
            LinearLayout llPanelSinSucursales, llPanelSeleccionaSucursal, llBtnCloseDialog;
            List<Sucursal> oficinasRegion;
            List<Sucursal> oficinasCombustibleTrue;
            RecyclerView rvListaSucursales;
            View dividerSucursal;

            customDialog = new Dialog(activity, Resource.Style.MyThemeTranslucent);
            customDialog.SetCancelable(false);
            customDialog.SetContentView(Resource.Layout.dialog_sucursales);
            layoutManager = new LinearLayoutManager(activity);
            llPanelSinSucursales = customDialog.FindViewById<LinearLayout>(Resource.Id.llPanelSinSucursales);
            llPanelSeleccionaSucursal = customDialog.FindViewById<LinearLayout>(Resource.Id.llPanelSeleccionaSucursal);
            llBtnCloseDialog = customDialog.FindViewById<LinearLayout>(Resource.Id.llBtnCloseDialog);
            rvListaSucursales = customDialog.FindViewById<RecyclerView>(Resource.Id.rvListaSucursales);
            dividerSucursal = customDialog.FindViewById<View>(Resource.Id.dividerSucursal);
            oficinasRegion = new List<Sucursal>();
            oficinasCombustibleTrue = new List<Sucursal>();
            llBtnCloseDialog.Click += delegate { customDialog.Dismiss(); };
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
                        llPanelSeleccionaSucursal.Visibility = ViewStates.Visible;
                        dividerSucursal.Visibility = ViewStates.Visible;
                        adapter = new AdapterListaSucursales(oficinasCombustibleTrue, activity);
                        adapter.itemClick += delegate {
                            activity.StartActivity(new Intent(activity, typeof(IngresoCodigoAutoActivity)), ActivityOptions.MakeSceneTransitionAnimation(activity).ToBundle());
                        };
                        rvListaSucursales.SetAdapter(adapter);
                        rvListaSucursales.SetLayoutManager(layoutManager);
                    }
                    else
                    {
                        llPanelSinSucursales.Visibility = ViewStates.Visible;
                        llPanelSeleccionaSucursal.Visibility = ViewStates.Gone;
                        rvListaSucursales.Visibility = ViewStates.Gone;
                        dividerSucursal.Visibility = ViewStates.Gone;
                    }
                }
            }
            else
            {
                llPanelSinSucursales.Visibility = ViewStates.Visible;
                llPanelSeleccionaSucursal.Visibility = ViewStates.Gone;
                rvListaSucursales.Visibility = ViewStates.Gone;
                dividerSucursal.Visibility = ViewStates.Gone;
            }

            customDialog.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
            customDialog.Show();
        }
    }
}
