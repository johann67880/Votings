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
    public class CandidatesCrossViewModel : MvxViewModel<NavigationArgs>
    {
        private readonly IApiService apiService;
        private readonly IDialogService dialogService;
        private readonly IMvxNavigationService navigationService;
        private MvxCommand<Candidate> itemClickCommand;
        private VotingEvent votingEvent;
        private List<Candidate> candidates;

        public ICommand ItemClickCommand
        {
            get
            {
                this.itemClickCommand =  this.itemClickCommand ?? new MvxCommand<Candidate>(this.SelectCandidate);
                return this.itemClickCommand;
            }
        }

        public List<Candidate> Candidates
        {
            get => this.candidates;
            set => this.SetProperty(ref this.candidates, value);
        }

        public CandidatesCrossViewModel(
            IApiService apiService,
            IDialogService dialogService,
            IMvxNavigationService navigationService)
        {
            this.apiService = apiService;
            this.dialogService = dialogService;
            this.navigationService = navigationService;
        }

        public override void Prepare(NavigationArgs parameter)
        {
            this.votingEvent = parameter.VotingEvent;
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
                Settings.Token);

            if (!response.IsSuccess)
            {
                this.dialogService.Alert("Error", "An error has occurred saving your vote. Try again", "Accept");

                return;
            }

            await this.navigationService.Close(this);
        }
    }
}
