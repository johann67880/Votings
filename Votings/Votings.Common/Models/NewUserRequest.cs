﻿namespace Votings.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class NewUserRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Occupation { get; set; }

        [Required]
        public string Stratum { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int CityId { get; set; }
    }
}
