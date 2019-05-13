package md5811001ac5c1e5aba72a79ad35039cd39;


public class AdapterListaSucursales_SucursalesViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("RegistroCombustibles.Adapters.AdapterListaSucursales+SucursalesViewHolder, RegistroCombustibles", AdapterListaSucursales_SucursalesViewHolder.class, __md_methods);
	}


	public AdapterListaSucursales_SucursalesViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == AdapterListaSucursales_SucursalesViewHolder.class)
			mono.android.TypeManager.Activate ("RegistroCombustibles.Adapters.AdapterListaSucursales+SucursalesViewHolder, RegistroCombustibles", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
