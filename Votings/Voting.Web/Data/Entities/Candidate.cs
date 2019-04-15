namespace Voting.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Candidate : IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MaxLength(50, ErrorMessage = "The field {0} can only contain {1} characters length.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Proposal")]
        [MaxLength(500, ErrorMessage = "The field {0} can only contain {1} characters length.")]
        public string Proposal { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        public int VotingEventId { get; set; }

        public IEnumerable<Vote> Votes { get; set; } = new List<Vote>();

        [Display(Name = "# Votes")]
        public int TotalVotes { get { return this.Votes == null ? 0 : this.Votes.Count(); } }
    }
}
