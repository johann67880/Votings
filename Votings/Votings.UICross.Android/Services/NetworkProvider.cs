using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net.Wifi;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross;
using MvvmCross.Platforms.Android;
using Votings.Common.Interfaces;

namespace Votings.UICross.Android.Services
{
    public class NetworkProvider : INetworkProvider
    {
        private const string TAG = "DroidNetworkProvider";
        Context context;
        public NetworkProvider()
        {
            context = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
        }

        public bool IsConnectedToWifi()
        {
            WifiManager wifi = (WifiManager)context.GetSystemService(Context.WifiService);

            if (wifi.IsWifiEnabled)
            {
                return true;
            }

            return false;
        }
    }
}