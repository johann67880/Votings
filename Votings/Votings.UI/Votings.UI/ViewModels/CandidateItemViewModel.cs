using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Votings.Common.Models;
using Votings.Common.Services;
using Votings.UI.Helpers;
using Xamarin.Forms;

namespace Votings.UI.ViewModels
{
    public class CandidateItemViewModel : Candidate
    {
        private readonly ApiService apiService;

        public ICommand SelectCandidateCommand => new RelayCommand(this.SelectCandidate);

        public CandidateItemViewModel()
        {
            this.apiService = new ApiService();
        }

        private async void SelectCandidate()
        {
            var candidate = (Candidate)this;

            var confirm = await Application.Current.MainPage.DisplayAlert(
                Languages.Confirmation,
                $"{Languages.EventConfirmation} {candidate.Name} ?",
                Languages.Accept,
                Languages.Cancel);

            if (!confirm)
            {
                return;
            }

            var vote = new Vote()
            {
                Candidate = candidate,
                RegistrationDate = DateTime.Now,
                User = MainViewModel.GetInstance().User,
                VotingEvent = MainViewModel.GetInstance().VotingEventDetail.votingEvent
            };

            var url = Application.Current.Resources["UrlAPI"].ToString();

            var response = await this.apiService.PostAsync<Vote>(
                url,
                "/api",
                "/VotingEvent/Save",
                vote,
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

            await Application.Current.MainPage.DisplayAlert(
                Languages.Confirmation,
                Languages.VoteRegistered,
                Languages.Accept);

            await App.Navigator.PopAsync();
        }
    }
}
