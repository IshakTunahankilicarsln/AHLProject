using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using NLayer_Task.Business.Interface;
using NLayer_Task.Model.Dtos.Addres;
using NLayer_Task.Model.Dtos.Categories;
using NLayer_Task.Model.Entites;
using NLayer_Task.WebApi.Base;

namespace NLayer_Task.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : BaseController
    {
        private readonly IAddresBS _adsresBs;
        public AddressController(IAddresBS adsresBs) { _adsresBs = adsresBs; }

        [HttpGet]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<AddresGetDto>>))]
        public async Task<ActionResult> GetAll()
        {
            var repo =await _adsresBs.GetAllAddresAsync("Customer");
            return SendResponse(repo);
        }


        [HttpGet("bycity")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<AddresGetDto>>))]
        public async Task<ActionResult> GetByCity([FromQuery]string city)
        {
            var repo = await _adsresBs.GetByCityAsync(city, "Customer");
            return SendResponse(repo);
        }


        [HttpGet("bycountry")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<AddresGetDto>>))]
        public async Task<ActionResult> GetByCountry([FromQuery] string country)
        {
            var repo = await _adsresBs.GetByCountryAsync(country, "Customer");
            return SendResponse(repo);
        }


        [HttpGet("byId")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<AddresGetDto>))]
        public async Task<ActionResult> GetById([FromQuery]int id)
        {
            var repo = await _adsresBs.GetByIdAsync(id,"Customer");
            return SendResponse(repo);
        }

        [HttpDelete("{id}")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> Deleteaddres([FromRoute] int id)
        {
            var repo = await _adsresBs.DeleteAddresAsync(id);
            return SendResponse(repo);
        }

        [HttpPost]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<Addres>))]
        public async Task<ActionResult> AddAdres([FromBody] AddresPostDto adress)
        {
            var repo = await _adsresBs.AddAddresasync(adress, "Customer");
            return SendResponse(repo);
        }

        [HttpPut]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> UpdateAddres([FromBody] AddresPutDto adress)
        {
            var repo = await _adsresBs.UpdateAddresAsync(adress);
            return SendResponse(repo);
        }
    }
}
