using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
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
    public class UserVoteCrossViewModel : MvxViewModel<NavigationArgs>
    {
        private readonly IApiService apiService;
        private readonly IDialogService dialogService;
        private readonly IMvxNavigationService navigationService;
        private VotingEvent votingEvent;
        private Candidate candidate;

        public Candidate Candidate
        {
            get => this.candidate;
            set => this.SetProperty(ref this.candidate, value);
        }

        public UserVoteCrossViewModel(
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
            this.Candidate = this.votingEvent.Candidates.FirstOrDefault();
        }

        public override void Prepare(NavigationArgs parameter)
        {
            this.votingEvent = parameter.VotingEvent;
        }
    }
}
