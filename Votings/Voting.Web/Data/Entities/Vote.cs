namespace Voting.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Vote : IEntity
    {
        public int Id { get; set; }

        [Required]
        public VotingEvent VotingEvent { get; set; }

        [Required]
        public Candidate Candidate { get; set; }

        [Required]
        public User User { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Registration Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime RegistrationDateLocal
        {
            get
            {
                return this.RegistrationDate.ToLocalTime();
            }
        }
    }
}
