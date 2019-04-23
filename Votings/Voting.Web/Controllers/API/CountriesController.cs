using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Voting.Web.Data.Repositories;

namespace Voting.Web.Controllers.API
{
    [Route("api/[Controller]")]
    public class CountriesController : Controller
    {
        private readonly ICountryRepository countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        [HttpGet]
        public IActionResult GetCountries()
        {
            return Ok(this.countryRepository.GetCountriesWithCities());
        }
    }
}