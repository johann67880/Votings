using System;
using System.Collections.Generic;
using System.Text;
using Votings.UI.ViewModels;

namespace Votings.UI.Infrastructure
{
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}
