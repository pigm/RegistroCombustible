using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using RegistroCombustibles.Common.Models.Services;
using RegistroCombustibles.Common.Utils.Utilitarios;

namespace RegistroCombustibles.Adapters
{
    public class AdapterListaSucursales : RecyclerView.Adapter
    {
        Activity activity;
        List<Sucursal> list;
        List<Sucursal> originList;
        List<object> lsucursal;
        public event EventHandler<List<Object>> itemClick;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TrazabilidadCarnes.Adapters.AdapterSucursal"/> class.
        /// </summary>
        /// <param name="lista">Lista.</param>
        /// <param name="activity">Fragment.</param>
        public AdapterListaSucursales(List<Sucursal> lista, Activity activity)
        {           
            list = lista;
            originList = lista;
            this.activity = activity;
        }

        /// <summary>
        /// Gets the item count.
        /// </summary>
        /// <value>The item count.</value>
        public override int ItemCount
        {
            get
            {
                return list.Count;
            }
        }

        /// <summary>
        /// Sucursal view holder.
        /// </summary>
        public class SucursalesViewHolder : RecyclerView.ViewHolder
        {

            public View mView;
            public LinearLayout fila_sucursal_selector { get; private set; }
            public TextView lblNombreSucursal { get; private set; }


            /// <summary>
            /// Initializes a new instance of the
            /// <see cref="T:TrazabilidadCarnes.Adapters.AdapterSucursal.SucursalViewHolder"/> class.
            /// </summary>
            /// <param name="view">View.</param>
            /// <param name="listener">Listener.</param>
            public SucursalesViewHolder(View view, Action<List<Object>> listener) : base(view)
            {
                fila_sucursal_selector = view.FindViewById<LinearLayout>(Resource.Id.fila_sucursal_selector);
                lblNombreSucursal = view.FindViewById<TextView>(Resource.Id.lblNombreSucursal);
            }
        }

        /// <summary>
        /// Ons the bind view holder.
        /// </summary>
        /// <param name="holder">Holder.</param>
        /// <param name="position">Position.</param>
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            SucursalesViewHolder miholder = holder as SucursalesViewHolder;
            LinearLayout view = miholder.fila_sucursal_selector;
            Sucursal of = list[position];
   
            miholder.lblNombreSucursal.Text = of.Nombre;             
        }


        /// <summary>
        /// Ons the create view holder.
        /// </summary>
        /// <returns>The create view holder.</returns>
        /// <param name="parent">Parent.</param>
        /// <param name="viewType">View type.</param>
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View card = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.row_sucursal, parent, false);
            SucursalesViewHolder viewholder = new SucursalesViewHolder(card, onClick);

            viewholder.fila_sucursal_selector.Click += (sender, e) =>
            {
                Sucursal sucursalSeleccionada = list[viewholder.AdapterPosition];
                lsucursal = new List<object>();
                lsucursal.Add(sucursalSeleccionada.Codigo);
                lsucursal.Add(sucursalSeleccionada.Nombre);
                lsucursal.Add(sucursalSeleccionada.Region);
                lsucursal.Add(sucursalSeleccionada.Combustible);
              

                activity.FinishActivity(100);
                itemClick(sender, lsucursal);
                DataManager.SucursalSeleccionada = sucursalSeleccionada;
            };
            return viewholder;
        }

        /// <summary>
        /// Ons the click.
        /// </summary>
        /// <param name="locationName">Location name.</param>
        void onClick(List<Object> locationName)
        {
            Intent intentAHomeAgregaProducto = new Intent(activity, typeof(IngresoCodigoAutoActivity));
            activity.StartActivity(intentAHomeAgregaProducto);
        }
    }
}
