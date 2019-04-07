namespace Voting.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ChangeUserViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [MaxLength(20, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "City")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a city.")]
        public int CityId { get; set; }

        public IEnumerable<SelectListItem> Cities { get; set; }

        [Display(Name = "Country")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a country.")]
        public int CountryId { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }

        [MaxLength(100, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Occupation { get; set; }

        [Display(Name = "Gender")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a gender.")]
        public int GenderId { get; set; }

        public IEnumerable<SelectListItem> Genders { get; set; }

        [MaxLength(2, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Stratum { get; set; }

        [Display(Name = "Birthdate")]
        public DateTime Birthdate { get; set; }
    }
}
