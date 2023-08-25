using Microsoft.AspNetCore.Mvc;
using NLayer_Task.Business.Implementation;
using NLayer_Task.Business.Interface;
using NLayer_Task.Model.Dtos.Order;
using NLayer_Task.WebApi.Base;

namespace NLayer_Task.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        private readonly IOrderBS _orderBS;
        public OrdersController(IOrderBS orderBS) { _orderBS = orderBS; }


        [HttpGet]
        public async Task<ActionResult> GetAllOrder()
        {
            var response = await _orderBS.GetAllOrderAsync("Customer");
            return SendResponse(response);
        }

        [HttpGet("{orderid}")]
        public async Task<ActionResult> GetByOrderIDOrder([FromRoute] int orderid)
        {
            var response = await _orderBS.GetByOrderIdAsync(orderid);
            return SendResponse(response);
        }

        [HttpGet("bycustomerid")]
        public async Task<ActionResult> GetbyCustomerIDOrder([FromQuery] int customerid)
        {
            var response = await _orderBS.GetByCustomerIdAsync(customerid);
            return SendResponse(response);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrder([FromBody] OrderPostDto order)
        {
            if (order == null)
                return BadRequest();
            var response = await _orderBS.AddorderAsync(order);
            //var resp = await _odetailBS. (new EmployePostDto() { })
            return CreatedAtAction(nameof(GetByOrderIDOrder), new { id = response.Data.OrderID }, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder([FromRoute] int id)
        {
            var response = await _orderBS.DeletebyIdAsync(id);
            return SendResponse(response);
        }
    }
}
