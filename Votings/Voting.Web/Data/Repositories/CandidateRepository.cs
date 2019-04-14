using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voting.Web.Data.Entities;

namespace Voting.Web.Data.Repositories
{
    public class CandidateRepository : GenericRepository<Candidate>, ICandidateRepository
    {
        private readonly DataContext context;

        public CandidateRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
