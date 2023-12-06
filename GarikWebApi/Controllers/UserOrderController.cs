using AutoMapper;
using DataBase;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;

namespace GarikWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOrderController : ControllerBase
    {
        private readonly ApplicationContext _db;
        private readonly IMapper _mapper;

        public UserOrderController(ApplicationContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }

        [HttpPost] // Запрос на добавление заказа
        public async Task<ActionResult<AddOrderForUser>> Post(AddOrderForUser addOrderForUser)
        {
            if (addOrderForUser == null)
            {
                return BadRequest();
            }

            var order = _mapper.Map<Order>(addOrderForUser);

            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
            return Ok(order);
        }

        [HttpGet("{id}")] // Запрос на вывод заказов прикрепленных к пользователю
        public async Task<ActionResult<Order>> Get(Guid id)
        {
            var order = _db.Orders.Where(c => c.UserId == id).ToList();
            return Ok(order);

        }
    }
}
