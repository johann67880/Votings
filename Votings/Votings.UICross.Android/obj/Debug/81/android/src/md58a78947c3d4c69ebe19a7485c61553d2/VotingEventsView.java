package md58a78947c3d4c69ebe19a7485c61553d2;


public class VotingEventsView
	extends md5231beb04e46a1dc811e36737109a7a02.MvxActivity_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Votings.UICross.Android.Views.VotingEventsView, Votings.UICross.Android", VotingEventsView.class, __md_methods);
	}


	public VotingEventsView ()
	{
		super ();
		if (getClass () == VotingEventsView.class)
			mono.android.TypeManager.Activate ("Votings.UICross.Android.Views.VotingEventsView, Votings.UICross.Android", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
