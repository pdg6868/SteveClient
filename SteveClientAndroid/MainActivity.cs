using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SteveClientAndroid
{
	[Activity (Label = "SteveClientAndroid", MainLauncher = true)]
	public class MainActivity : TabActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			CreateTab(typeof(ConnectionActivity), "connection", "Connection", Resource.Drawable.ic_wifi);
			CreateTab(typeof(RequestActivity), "request", "Request", Resource.Drawable.ic_request);
		}

		private void CreateTab(Type activityType, string tag, string label, int drawableId )
		{
			var intent = new Intent(this, activityType);
			intent.AddFlags(ActivityFlags.NewTask);

			var spec = TabHost.NewTabSpec(tag);
			var drawableIcon = Resources.GetDrawable(drawableId);
			spec.SetIndicator(label, drawableIcon);
			spec.SetContent(intent);

			TabHost.AddTab(spec);
		}
	}
}


