using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Votings.Common.Models;
using Votings.Common.Services;
using Xamarin.Forms;

namespace Votings.UI.ViewModels
{
    public class VotingEventViewModel : BaseViewModel
    {
        private bool isRunning;
        private bool isEnabled;
        private readonly ApiService apiService;
        private List<VotingEvent> myEvents;
        private ObservableCollection<VotingEventItemViewModel> items;
        private bool isRefreshing = false;

        public bool IsRefreshing
        {
            get => this.isRefreshing;
            set => this.SetValue(ref this.isRefreshing, value);
        }

        public ICommand SelectRefreshCommand => new RelayCommand(this.RefreshCommand);

        private void RefreshCommand()
        {
            if (this.IsRefreshing)
            {
                this.IsRefreshing = false;
            }

            this.LoadVotingEvents();
        }

        public ObservableCollection<VotingEventItemViewModel> Items
        {
            get => this.items;
            set => this.SetValue(ref this.items, value);
        }

        public VotingEventViewModel()
        {
            this.apiService = new ApiService();
            this.LoadVotingEvents();
            this.IsRefreshing = false;
        }

        private async void LoadVotingEvents()
        {
            if(this.IsRefreshing)
            {
                this.IsRefreshing = false;
            }

            this.IsRefreshing = true;

            var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await this.apiService.GetListAsync<VotingEvent>(
                url,
                "/api",
                "/VotingEvent/All",
                "bearer",
                MainViewModel.GetInstance().Token.Token);

            this.IsRefreshing = false;

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            this.myEvents = (List<VotingEvent>)response.Result;
            this.RefreshVotingEventsList();
        }

        private void RefreshVotingEventsList()
        {
            this.Items = new ObservableCollection<VotingEventItemViewModel>(
                this.myEvents.Select(p => new VotingEventItemViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    EndDate = p.EndDate,
                    StartDate = p.StartDate,
                    Candidates = p.Candidates,
                    Votes = p.Votes
                })
            .OrderBy(p => p.Name)
            .ToList());
        }
    }
}
