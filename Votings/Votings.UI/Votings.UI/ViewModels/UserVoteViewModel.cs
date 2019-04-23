using System;
using System.Collections.Generic;
using System.Text;
using Votings.Common.Models;
using Votings.Common.Services;

namespace Votings.UI.ViewModels
{
    public class UserVoteViewModel : BaseViewModel
    {
        public Vote vote { get; set; }

        public UserVoteViewModel(Vote vote)
        {
            this.vote = vote;
        }
    }
}
