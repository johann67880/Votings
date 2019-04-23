using System;
using System.Collections.Generic;
using System.Text;
using Votings.Common.Models;
using Votings.Common.Services;
using Xamarin.Forms;

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

        private async void GetEventWithCandidates(VotingEvent votingEvent)
        {
            var url = Application.Current.Resources["UrlAPI"].ToString();

            var response = await this.apiService.GetListAsync<VotingEvent>(
                url,
                "/api",
                "/VotingEvent/",
                "bearer",
                MainViewModel.GetInstance().Token.Token);

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }
        }
    }
}
