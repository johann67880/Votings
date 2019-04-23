using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Votings.Common.Models;
using Votings.UI.Helpers;
using Xamarin.Forms;

namespace Votings.UI.ViewModels
{
    public class CandidateItemViewModel : Candidate
    {
        public ICommand SelectCandidateCommand => new RelayCommand(this.SelectCandidate);

        private async void SelectCandidate()
        {
            var candidate = (Candidate)this;

            var confirm = await Application.Current.MainPage.DisplayAlert(
                "Confirmation",
                $"Are you sure you want to vote for: {candidate.Name} ?",
                Languages.Accept,
                "Cancel");

            if (!confirm)
            {
                return;
            }

            ////TODO: Consume API to save vote.
        }
    }
}
