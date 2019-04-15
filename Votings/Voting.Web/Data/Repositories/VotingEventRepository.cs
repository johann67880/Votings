using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voting.Web.Data.Entities;

namespace Voting.Web.Data.Repositories
{
    public class VotingEventRepository : GenericRepository<VotingEvent>, IVotingEventRepository
    {
        private readonly DataContext context;

        public VotingEventRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetAllVotingEventsWithCandidates()
        {
            return this.context.VotingEvents.Include(v => v.Candidates).OrderBy(v => v.StartDate);
        }
    }
}
