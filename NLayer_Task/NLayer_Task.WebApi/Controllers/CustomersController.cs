using Microsoft.AspNetCore.Mvc;
using NLayer_Task.Business.Interface;
using NLayer_Task.Model.Dtos.Customer;
using NLayer_Task.WebApi.Base;

namespace NLayer_Task.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        private readonly ICustomerBS _custBS;
        public CustomersController(ICustomerBS custBS) { _custBS = custBS; }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response =await _custBS.GetAllCustomerAsync("Addres");
            return SendResponse(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById([FromRoute(Name = "id")] int id)
        {
            var response = await _custBS.GetByIdAsync(id: id, "Addres");
            return SendResponse(response);
        }

        [HttpGet("byname")]
        public async Task<ActionResult> GetByName([FromQuery]string name)
        {
            var response =await _custBS.GetByNameAsync(name:name,"Addres");
            return SendResponse(response);
        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer([FromBody] CustomerPostDto dto)
        {
            var response = await _custBS.AddCustomerAsync(dto,"Addres");
            return SendResponse(response);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomer([FromBody] CustomerPutDto dto)
        {
            var response = await _custBS.UpdateCustomerAsync(dto);
            return SendResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer([FromRoute]int id)
        {
            var response = await _custBS.DeleteCustomerAsync(id);
            return SendResponse(response);
        }
    }
}
