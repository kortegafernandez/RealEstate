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
    public class PropertyCategoriesController : ControllerBase
    {
        private readonly IPropertyCategoryService _propertyCategoryService;
        public PropertyCategoriesController(IPropertyCategoryService propertyCategoryService)
        {
            _propertyCategoryService = propertyCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPropertyCategories()
        {
            var categories = await _propertyCategoryService.GetAllAsync();
            var response = new ApiResponse<IEnumerable<PropertyCategoryDto>>(categories);

            return Ok(response);
        }
    }
}
