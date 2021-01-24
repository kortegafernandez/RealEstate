using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Response;
using RealEstate.Core.DTOs;
using RealEstate.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOwners()
        {
            var owners = await _ownerService.GetAllAsync();
            var response = new ApiResponse<IEnumerable<OwnerDto>>(owners);
            
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwner(int id)
        {
            var owner = await _ownerService.GetByIdAsync(id);
            var response = new ApiResponse<OwnerDto>(owner);
            
            return Ok(response);
        }

        [HttpGet("GetByIdentificationNumber/{id}")]
        public async Task<IActionResult> GetByIdentificationNumber(string id)
        {
            var owner = await _ownerService.GetByIdendtificationNumberAsync(id);
            var response = new ApiResponse<OwnerDto>(owner);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner(OwnerDto owner)
        {           
            var savedOwner = await _ownerService.InsertAsync(owner);
            var response = new ApiResponse<OwnerDto>(savedOwner);
            
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOwner(int id, OwnerDto owner)
        {          
            owner.Id = id;

            var updatedOwner= await _ownerService.UpdateAsync(owner);
            var response = new ApiResponse<OwnerDto>(updatedOwner);
            
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            await _ownerService.DeleteAsync(id);
            
            return Ok();
        }
    }
}
