using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Votings.Common.Models;
using Votings.Common.Services;
using Votings.UI.Helpers;
using Xamarin.Forms;

namespace Votings.UI.ViewModels
{
    public class VotingEventDetailViewModel : BaseViewModel
    {
        private bool isRunning;
        private bool isEnabled;
        private readonly ApiService apiService;
        private VotingEvent myVotingEvent;
        private ObservableCollection<CandidateItemViewModel> items;

        public VotingEvent votingEvent { get; set; }

        public ObservableCollection<CandidateItemViewModel> Items
        {
            get => this.items;
            set => this.SetValue(ref this.items, value);
        }

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
            this.GetEventWithCandidates(votingEvent);
        }

        private async void GetEventWithCandidates(VotingEvent votingEvent)
        {
            var url = Application.Current.Resources["UrlAPI"].ToString();

            var response = await this.apiService.GetSingleAsync<VotingEvent>(
                url,
                "/api",
                $"/VotingEvent/{votingEvent.Id}",
                "bearer",
                MainViewModel.GetInstance().Token.Token);

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    response.Message,
                    Languages.Accept);
                return;
            }

            this.myVotingEvent = (VotingEvent)response.Result;
            this.RefreshCandidatesList();
        }

        private void RefreshCandidatesList()
        {
            this.Items = new ObservableCollection<CandidateItemViewModel>(
                this.myVotingEvent.Candidates.Select(p => new CandidateItemViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageFullPath = p.ImageFullPath,
                    Proposal = p.Proposal
                })
            .OrderBy(p => p.Name)
            .ToList());
        }
    }
}
