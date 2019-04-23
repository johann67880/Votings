using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voting.Web.Data.Entities;

namespace Voting.Web.Data.Repositories
{
    public class VoteRepository : GenericRepository<Vote>, IVoteRepository
    {
        private readonly DataContext context;

        public VoteRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public Vote GetUserVoteByVotingEvent(int votingEventId, string userId)
        {
            return this.context.Votes
                .Include(v => v.VotingEvent)
                .Include(v => v.Candidate)
                .Where(v => v.VotingEvent.Id == votingEventId && v.User.Id == userId)
                .FirstOrDefault();
        }
    }
}
