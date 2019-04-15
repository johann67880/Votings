using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voting.Web.Data.Entities;

namespace Voting.Web.Data.Repositories
{
    public interface IVotingEventRepository : IGenericRepository<VotingEvent>
    {
        IQueryable GetAllVotingEventsWithCandidates();
    }
}
