using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using MvvmCross;
using Votings.Common.Interfaces;
using global::Android.App;
using MvvmCross.Platforms.Android;

namespace Votings.UICross.Android.Services
{
    public class DialogService : IDialogService
    {
        public void Alert(string title, string message, string okbtnText)
        {
            var top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;

            var adb = new AlertDialog.Builder(act);
            adb.SetTitle(title);
            adb.SetMessage(message);
            adb.SetPositiveButton(okbtnText, (sender, args) => { /* some logic */ });
            adb.Create().Show();
        }
    }
}