using System;
using System.Collections.Generic;
using System.Text;
using Votings.Common.Models;
using Votings.Common.Services;

namespace Votings.UI.ViewModels
{
    public class CandidatesViewModel : BaseViewModel
    {
        private bool isRunning;
        private bool isEnabled;
        private readonly ApiService apiService;
        private List<Candidate> candidates;

        public Candidate Candidate { get; set; }

        public bool IsRunning
        {
            get => this.isRunning;
            set => this.SetValue(ref this.isRunning, value);
        }

        public bool IsEnabled
        {
            get => this.isEnabled;
            set => this.SetValue(ref this.isEnabled, value);
        }
    }
}
