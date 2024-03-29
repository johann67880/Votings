﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Views;
using Votings.Common.ViewModels;

namespace Votings.UICross.Android.Views
{
    [Activity(Label = "@string/app_name")]
    public class CandidatesView : MvxActivity<CandidatesCrossViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.SetContentView(Resource.Layout.CandidatePage);
        }
    }
}