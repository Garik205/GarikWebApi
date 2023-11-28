using Microsoft.AspNetCore.Mvc;
using DataBase;


namespace GarikWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class AddUserController : ControllerBase
    {
        ApplicationContext db;

        public AddUserController(ApplicationContext context)
        {
            context = db;
        }

        [HttpPost] // Запрос для получения данных из тела и добавление в бд
        public async 
        
    }
}
