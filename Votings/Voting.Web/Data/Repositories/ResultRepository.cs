using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voting.Web.Data.Entities;

namespace Voting.Web.Data.Repositories
{
    public class ResultRepository : GenericRepository<Vote>, IResultRepository
    {
        private readonly DataContext context;

        public ResultRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public Vote GetResult()
        {
            return this.context.Votes
                .Include(v => v.VotingEvent)
                .Include(v => v.Candidate)
                .FirstOrDefault();
        }
    }
}
