namespace Voting.Web.Models
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;
    using Voting.Web.Data.Entities;

    public class CandidateViewModel : Candidate
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
