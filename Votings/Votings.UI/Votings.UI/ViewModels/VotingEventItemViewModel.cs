using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Votings.Common.Models;
using Votings.UI.Views;

namespace Votings.UI.ViewModels
{
    public class VotingEventItemViewModel : VotingEvent
    {
        public ICommand SelectVotingEventCommand => new RelayCommand(this.SelectVotingEvent);

        private async void SelectVotingEvent()
        {
            MainViewModel.GetInstance().VotingEventDetail = new VotingEventDetailViewModel((VotingEvent)this);
            await App.Navigator.PushAsync(new VotingEventDetailPage());
        }
    }
}
