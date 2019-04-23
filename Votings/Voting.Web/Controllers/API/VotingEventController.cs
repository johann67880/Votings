using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Voting.Web.Data.Entities;
using Voting.Web.Data.Repositories;
using Voting.Web.Helpers;

namespace Voting.Web.Controllers.API
{
    [Route("api/[Controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VotingEventController : Controller
    {
        private readonly IVotingEventRepository votingEventRepository;
        private readonly ICandidateRepository candidateRepository;
        private readonly IUserHelper userHelper;
        private readonly IVoteRepository voteRepository;

        public VotingEventController(
            IVotingEventRepository votingEventRepository,
            ICandidateRepository candidateRepository,
            IUserHelper userHelper,
            IVoteRepository voteRepository)
        {
            this.votingEventRepository = votingEventRepository;
            this.candidateRepository = candidateRepository;
            this.userHelper = userHelper;
            this.voteRepository = voteRepository;
        }

        [HttpGet]
        [Route("All")]
        public IActionResult GetVotingEvents()
        {
            return Ok(this.votingEventRepository.GetAll());
        }

        [HttpGet]
        public IActionResult GetVotingEvent(int votingId)
        {
            return Ok(this.votingEventRepository.GetVotingEvent(votingId));
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> SaveUserVote([FromBody] Vote vote)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var user = await this.userHelper.GetUserByEmailAsync(vote.User.UserName);

            if (user == null)
            {
                return this.BadRequest("Invalid user");
            }

            var newVote = await this.voteRepository.CreateAsync(vote);
            return Ok(newVote);
        }
    }
}