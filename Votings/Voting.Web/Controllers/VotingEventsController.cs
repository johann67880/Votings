using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Voting.Web.Data.Entities;
using Voting.Web.Data.Repositories;
using Voting.Web.Helpers;
using Voting.Web.Models;

namespace Voting.Web.Controllers
{
    public class VotingEventsController : Controller
    {
        private readonly ICandidateRepository candidateRepository;
        private readonly IVotingEventRepository votingEventRepository;

        public VotingEventsController(ICandidateRepository candidateRepository, IVotingEventRepository votingEventRepository)
        {
            this.candidateRepository = candidateRepository;
            this.votingEventRepository = votingEventRepository;
        }

        public IActionResult Results()
        {
            return View("Results");
        }

        public IActionResult Details()
        {
            return View("Details");
        }

        public IActionResult Index()
        {
            var result = this.votingEventRepository.GetAll().OrderByDescending(x => x.StartDate).ToList();
            return View(result);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateCandidate()
        {
            return View("AddCandidate");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("VotingEventNotFound");
            }

            var votingEvent = await this.votingEventRepository.GetByIdAsync(id.Value);

            if (votingEvent == null)
            {
                return new NotFoundViewResult("VotingEventNotFound");
            }

            return View(votingEvent);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var votingEvent = await this.votingEventRepository.GetByIdAsync(id.Value);

            if (votingEvent == null)
            {
                return NotFound();
            }

            var view = this.ToVotingEventViewModel(votingEvent);
            return View("Details");
        }

        private VotingEventViewModel ToVotingEventViewModel(VotingEvent votingEvent)
        {
            return new VotingEventViewModel
            {
                Id = votingEvent.Id,
                Candidates = votingEvent.Candidates,
                Description = votingEvent.Description,
                EndDate = votingEvent.EndDate,
                StartDate = votingEvent.StartDate,
                Name = votingEvent.Name
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VotingEventViewModel view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var votingEvent = this.ToVotingEvent(view);
                    await this.votingEventRepository.UpdateAsync(votingEvent);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.votingEventRepository.ExistAsync(view.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(view);
        }

        private VotingEvent ToVotingEvent(VotingEventViewModel viewModel)
        {
            return new VotingEvent()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                Candidates = viewModel.Candidates,
                EndDate = viewModel.EndDate,
                StartDate = viewModel.StartDate
            };
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await this.votingEventRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await this.votingEventRepository.GetByIdAsync(id);
            await this.votingEventRepository.DeleteAsync(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProductNotFound()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VotingEventViewModel view)
        {
            if (ModelState.IsValid)
            {
                //TODO: Validate Voting event has candidates

                var votingEvent = this.ToVotingEvent(view);
                await this.votingEventRepository.CreateAsync(votingEvent);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCandidate(CandidateViewModel view)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Products",
                        file);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Products/{file}";
                }

                var candidate = this.ToCandidate(view, path);
                await this.candidateRepository.CreateAsync(candidate);
                return RedirectToAction(nameof(Index));
            }

            return View(view);
        }

        private Candidate ToCandidate(CandidateViewModel view, string path)
        {
            return new Candidate
            {
                Id = view.Id,
                ImageUrl = path,
                Proposal = view.Proposal
            };
        }
    }
}