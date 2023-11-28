using Microsoft.AspNetCore.Mvc;
using DataBase;


namespace GarikWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class AddUserController : ControllerBase
    {
        ApplicationContext _db;

        public AddUserController(ApplicationContext context)
        {
            context = _db;
        }

        [HttpPost] // Запрос для получения данных из тела и добавление в бд
        public async Task<ActionResult<User>> Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return Ok(user);
        }
        
    }
}
