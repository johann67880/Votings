namespace Voting.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class VotingEvent : IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MaxLength(100, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [MaxLength(500, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public IEnumerable<Candidate> Candidates { get; set; }

        [Display(Name = "# Candidates")]
        public int TotalCandidates { get { return this.Candidates == null ? 0 : this.Candidates.Count(); } }
    }
}
