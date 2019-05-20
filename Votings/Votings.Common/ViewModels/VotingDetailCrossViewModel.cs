using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Votings.Common.Helpers;
using Votings.Common.Interfaces;
using Votings.Common.Models;
using Votings.Common.Services;

namespace Votings.Common.ViewModels
{
    public class VotingDetailCrossViewModel : MvxViewModel<NavigationArgs>
    {
        private readonly IApiService apiService;
        private readonly IDialogService dialogService;
        private readonly IMvxNavigationService navigationService;
        private VotingEvent votingEvent;
        private MvxCommand<Candidate> itemClickCommand;

        private List<Candidate> candidates;

        public ICommand ItemClickCommand
        {
            get
            {
                this.itemClickCommand = this.itemClickCommand ?? new MvxCommand<Candidate>(this.SelectCandidate);
                return this.itemClickCommand;
            }
        }

        public VotingEvent VotingEvent
        {
            get => this.votingEvent;
            set => this.SetProperty(ref this.votingEvent, value);
        }

        public List<Candidate> Candidates
        {
            get => this.candidates;
            set => this.SetProperty(ref this.candidates, value);
        }

        public VotingDetailCrossViewModel(
            IApiService apiService,
            IDialogService dialogService,
            IMvxNavigationService navigationService)
        {
            this.apiService = apiService;
            this.dialogService = dialogService;
            this.navigationService = navigationService;

        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
            this.GetEventWithCandidates(this.votingEvent);
        }

        public override void Prepare(NavigationArgs parameter)
        {
            this.votingEvent = parameter.VotingEvent;
        }

        private async void GetEventWithCandidates(VotingEvent votingEvent)
        {
            var response = await this.apiService.GetSingleAsync<VotingEvent>(
                "https://betoappservice.azurewebsites.net",
                "/api",
                $"/VotingEvent/{votingEvent.Id}",
                "bearer",
                Settings.StrToken);

            if (!response.IsSuccess)
            {
                this.dialogService.Alert("Error", "An error has occurred getting candidates. Try again", "Accept");
                return;
            }

            //this.candidates = (List<Candidate>)response.Result;
            var result = (VotingEvent)response.Result;
            this.Candidates = result.Candidates;
        }

        private async void SelectCandidate(Candidate candidate)
        {
            var vote = new Vote()
            {
                Candidate = candidate,
                RegistrationDate = DateTime.Now,
                UserName = Settings.User,
                VotingEvent = this.votingEvent
            };

            var response = await this.apiService.PostAsync<Vote>(
                "https://betoappservice.azurewebsites.net",
                "/api",
                "/VotingEvent/Save",
                vote,
                "bearer",
                Settings.StrToken);

            if (!response.IsSuccess)
            {
                this.dialogService.Alert("Error", "An error has occurred saving your vote. Try again", "Accept");
                return;
            }

            await this.navigationService.Close(this);
        }
    }
}
