using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Votings.Common.Models;

namespace Votings.UI.ViewModels
{
    public class MainViewModel
    {
        private static MainViewModel instance;
        public LoginViewModel Login { get; set; }
        public RegisterViewModel Register { get; set; }
        public RememberPasswordViewModel RememberPassword { get; set; }
        public ChangePasswordViewModel ChangePassword { get; set; }
        public ProfileViewModel Profile { get; set; }
        public CandidatesViewModel Candidates { get; set; }
        public VotingEventViewModel VotingEvents { get; set; }
        public VotingEventDetailViewModel VotingEventDetail { get; set; }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        public User User { get; set; }

        public TokenResponse Token { get; set; }

        public string UserEmail { get; set; }

        public string UserPassword { get; set; }

        public MainViewModel()
        {
            instance = this;
            this.LoadMenus();
        }

        private void LoadMenus()
        {
            var menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "ic_info",
                    PageName = "AboutPage",
                    Title = "About"
                },

                new Menu
                {
                    Icon = "ic_person",
                    PageName = "ProfilePage",
                    Title = "Modify User"
                },

                new Menu
                {
                    Icon = "ic_setting",
                    PageName = "SetupPage",
                    Title = "Setup"
                },

                new Menu
                {
                    Icon = "ic_logout",
                    PageName = "LoginPage",
                    Title = "Close session"
                }
            };

            this.Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title
                }).ToList());
        }

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
    }
}
