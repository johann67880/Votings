package md58a78947c3d4c69ebe19a7485c61553d2;


public class SplashView
	extends mvvmcross.platforms.android.views.MvxSplashScreenActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Votings.UICross.Android.Views.SplashView, Votings.UICross.Android", SplashView.class, __md_methods);
	}


	public SplashView ()
	{
		super ();
		if (getClass () == SplashView.class)
			mono.android.TypeManager.Activate ("Votings.UICross.Android.Views.SplashView, Votings.UICross.Android", "", this, new java.lang.Object[] {  });
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
