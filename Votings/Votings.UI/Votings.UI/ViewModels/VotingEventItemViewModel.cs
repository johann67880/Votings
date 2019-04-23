using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Votings.Common.Models;
using Votings.UI.Helpers;
using Votings.UI.Views;
using Xamarin.Forms;

namespace Votings.UI.ViewModels
{
    public class VotingEventItemViewModel : VotingEvent
    {
        public ICommand SelectVotingEventCommand => new RelayCommand(this.SelectVotingEvent);

        private async void SelectVotingEvent()
        {
            var votingEvent = (VotingEvent)this;
            var currentDate = DateTime.UtcNow.ToLocalTime();

            /*
            if (currentDate < votingEvent.StartDate.ToLocalTime())
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    "Event has not started yet",
                    Languages.Accept);

                return;
            }

            if (currentDate > votingEvent.EndDate.ToLocalTime())
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    "Event has finished. You are not able to vote for this event.",
                    Languages.Accept);

                return;
            }
            */

            MainViewModel.GetInstance().VotingEventDetail = new VotingEventDetailViewModel((VotingEvent)this);
            await App.Navigator.PushAsync(new VotingEventDetailPage());
        }
    }
}
