using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Votings.Common.Models;
using Votings.Common.Services;
using Votings.UI.Helpers;
using Votings.UI.Views;
using Xamarin.Forms;

namespace Votings.UI.ViewModels
{
    public class VotingEventItemViewModel : VotingEvent
    {
        private readonly ApiService apiService;
        public ICommand SelectVotingEventCommand => new RelayCommand(this.SelectVotingEvent);

        public VotingEventItemViewModel()
        {
            this.apiService = new ApiService();
        }

        private async void SelectVotingEvent()
        {
            var votingEvent = (VotingEvent)this;
            var currentDate = DateTime.UtcNow.ToLocalTime();

            if (currentDate < votingEvent.StartDate)
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.EventNotStarted,
                    Languages.Accept);

                return;
            }

            if (currentDate > votingEvent.EndDate)
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.EventFinished,
                    Languages.Accept);

                return;
            }

            //Checking if user already voted for some candidate.
            var user = MainViewModel.GetInstance().User;
            var url = Application.Current.Resources["UrlAPI"].ToString();

            var response = await this.apiService.GetSingleAsync<Vote>(
                url,
                "/api",
                $"/VotingEvent/UserVote/{votingEvent.Id}/{user.Id}",
                "bearer",
                MainViewModel.GetInstance().Token.Token);

            //If user voted, then Navigate to Anothe content page
            if (response.Result != null && response.IsSuccess)
            {
                MainViewModel.GetInstance().UserVoteDetail = new UserVoteViewModel((Vote)response.Result);
                await App.Navigator.PushAsync(new UserVotePage());
                return;
            }

            //Otherwise, navigate to Voting Event Details
            MainViewModel.GetInstance().VotingEventDetail = new VotingEventDetailViewModel((VotingEvent)this);
            await App.Navigator.PushAsync(new VotingEventDetailPage());
        }
    }
}
