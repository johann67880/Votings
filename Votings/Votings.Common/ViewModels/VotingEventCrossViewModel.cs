using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Votings.Common.Helpers;
using Votings.Common.Interfaces;
using Votings.Common.Models;
using Votings.Common.Services;

namespace Votings.Common.ViewModels
{
    public class VotingEventCrossViewModel : MvxViewModel
    {
        private List<VotingEvent> votingEvents;
        private readonly IApiService apiService;
        private readonly IDialogService dialogService;
        private readonly IMvxNavigationService navigationService;
        private MvxCommand<VotingEvent> itemClickCommand;

        private INetworkProvider networkProvider;

        public bool isConnetedToWIFI
        {
            get
            {
                return networkProvider.IsConnectedToWifi();
            }
        }

        public List<VotingEvent> VotingEvents
        {
            get => this.votingEvents;
            set => this.SetProperty(ref this.votingEvents, value);
        }

        public ICommand ItemClickCommand
        {
            get
            {
                this.itemClickCommand = new MvxCommand<VotingEvent>(this.OnItemClickCommand);
                return itemClickCommand;
            }
        }

        public VotingEventCrossViewModel(
            IApiService apiService,
            IDialogService dialogService,
            IMvxNavigationService navigationService,
            INetworkProvider networkProvider)
        {
            this.apiService = apiService;
            this.dialogService = dialogService;
            this.navigationService = navigationService;
            this.networkProvider = networkProvider;
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
            this.LoadVotingEvents();
        }

        private async void OnItemClickCommand(VotingEvent votingEvent)
        {
            if(!this.isConnetedToWIFI)
            {
                this.dialogService.Alert("Error", "You are not connected to internet. Please review and try again.", "Accept");
                return;
            }

            //If Event has not started yet
            if (!votingEvent.IsStarted)
            {
                this.dialogService.Alert("Error", "Event has not started yet.", "Accept");
                return;
            }

            //If Event finished, then show candidates with results
            if (votingEvent.IsFinished)
            {
                //Otherwise, navigate to Voting Event Details
                await this.navigationService.Navigate<VotingDetailCrossViewModel, NavigationArgs>(
                new NavigationArgs { VotingEvent = votingEvent });
                return;
            }

            var response = await this.apiService.GetSingleAsync<Vote>(
                "https://betoappservice.azurewebsites.net",
                "/api",
                $"/VotingEvent/UserVote2/{votingEvent.Id}/{Settings.User}",
                "bearer",
                Settings.Token);

            //If user voted, then Navigate to Anothe content page
            if (response.Result != null && response.IsSuccess)
            {
                await this.navigationService.Navigate<UserVoteCrossViewModel, NavigationArgs>(
                new NavigationArgs { VotingEvent = votingEvent });
                return;
            }

            //Otherwise, navigate to Voting Event Details
            await this.navigationService.Navigate<VotingDetailCrossViewModel, NavigationArgs>(
                new NavigationArgs { VotingEvent = votingEvent });
        }

        private async void LoadVotingEvents()
        {
            var token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);

            var response = await this.apiService.GetListAsync<VotingEvent>(
                "https://betoappservice.azurewebsites.net",
                "/api",
                "/VotingEvent/All",
                "bearer",
                token.Token);

            if (!response.IsSuccess)
            {
                this.dialogService.Alert("Error", response.Message, "Accept");
                return;
            }

            this.VotingEvents = (List<VotingEvent>)response.Result;
            this.VotingEvents = this.VotingEvents.OrderByDescending(v => v.StartDate).ToList();
        }
    }
}
