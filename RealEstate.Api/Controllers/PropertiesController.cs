﻿using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Response;
using RealEstate.Core.DTOs;
using RealEstate.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertiesController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProperties()
        {
            var properties = await _propertyService.GetAllAsync();
            var response = new ApiResponse<IEnumerable<PropertyDto>>(properties);
            
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProperty(int id)
        {
            var property = await _propertyService.GetByIdAsync(id);
            var response = new ApiResponse<PropertyDto>(property);
            
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProperty(PropertyDto property)
        {           
            property = await _propertyService.InsertAsync(property);
            var response = new ApiResponse<PropertyDto>(property);
            
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty(int id, PropertyDto property)
        {
            property.Id = id;

            await _propertyService.UpdateAsync(property);
            var response = new ApiResponse<PropertyDto>(property);
            
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            await _propertyService.DeleteAsync(id);
            var response = new ApiResponse<bool>(true);
            
            return Ok(response);
        }
    }
}
