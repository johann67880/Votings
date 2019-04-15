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

        public VotingEvent GetVotingEvent(int id)
        {
            return this.context.VotingEvents
                .Include(v => v.Candidates)
                .Include(v => v.Votes)
                .Where(v => v.Id == id)
                .FirstOrDefault();
        }

        public IQueryable GetAllVotingEvents()
        {
            return this.context.VotingEvents
                .Include(v => v.Candidates)
                .Include(v => v.Votes)
                .OrderBy(v => v.StartDate);
        }
    }
}
