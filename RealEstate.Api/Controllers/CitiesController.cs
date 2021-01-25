using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Response;
using RealEstate.Core.DTOs;
using RealEstate.Services.Interfaces;

namespace RealEstate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _cityService.GetAllAsync();
            var response = new ApiResponse<IEnumerable<CityDto>>(cities);

            return Ok(response);
        }
    }
}
