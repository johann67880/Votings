namespace Voting.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

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
    }
}
