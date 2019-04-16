using System;
using System.Collections.Generic;
using System.Text;
using Votings.Common.Models;
using Votings.Common.Services;

namespace Votings.UI.ViewModels
{
    public class VotingEventDetailViewModel : BaseViewModel
    {
        private bool isRunning;
        private bool isEnabled;
        private readonly ApiService apiService;

        public VotingEvent votingEvent { get; set; }

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

        public VotingEventDetailViewModel(VotingEvent votingEvent)
        {
            this.votingEvent = votingEvent;
            this.apiService = new ApiService();
            this.IsEnabled = true;
        }
    }
}
