using Microsoft.AspNetCore.Mvc;
using DataBase;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DataBase.Models;



namespace GarikWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly ApplicationContext _db;
        private readonly IMapper _mapper;

        public UserController(ApplicationContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper; // передача в конструктор маппера, для того чтобы можно было модифицировать, преобразовывать entity в классе модели 
        }

        [HttpPost] // Запрос для получения данных из тела и добавление в бд
        public async Task<ActionResult<AddUserModel>> Post(AddUserModel addUserModel)
        {
            if (addUserModel == null)
            {
                return BadRequest();
            }
            
            User user = _mapper.Map<User>(addUserModel);

            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return Ok(user);

        }

        [HttpGet] // Запрос для получения данных из бд
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _db.Users.ToListAsync();
        }


        [HttpGet("{id}")] // Запрос для получения данных из бд по параметру id
        public async Task<ActionResult<User>> Get(Guid id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.id == id);
            

            if (user == null)
            {
                return BadRequest();
            }
            
            return user;
        }

        [HttpPut] // Запрос для получения данных из тела и изменение ими обекта бд
        public async Task<ActionResult<User>> Put(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            else if (!_db.Users.Any(x => x.id == user.id))
            {
                return NotFound();
            }

            _db.Update(user);
            await _db.SaveChangesAsync();
            return user;
        }

        [HttpDelete("{id}")] // Запрос для удаление пользователя из бд
        public async Task<ActionResult<User>> Delete(Guid id)
        {
            var user = _db.Users.FirstOrDefault(x => x.id == id);
            if(user == null)            
                return NotFound();
            
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return Ok(user);
        }
    }
}
