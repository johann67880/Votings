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
        public ICommand SelectProductCommand => new RelayCommand(this.SelectProduct);

        private async void SelectProduct()
        {
            MainViewModel.GetInstance().VotingEventDetail = new VotingEventDetailViewModel((VotingEvent)this);
            await App.Navigator.PushAsync(new VotingEventDetailPage());
        }
    }
}
