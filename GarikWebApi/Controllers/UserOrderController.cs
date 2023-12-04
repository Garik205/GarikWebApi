using DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GarikWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOrderController : ControllerBase
    {
        private readonly ApplicationContext _db;

        public UserOrderController(ApplicationContext context)
        {
            _db = context;
        }

        [HttpPost] // Запрос на добавление заказа
        public async Task<ActionResult<Order>>Post(Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            if (order.UserId == order.OrderId)
            {
                BadRequest();
            }
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
            return Ok(order);
        }
    }
}
