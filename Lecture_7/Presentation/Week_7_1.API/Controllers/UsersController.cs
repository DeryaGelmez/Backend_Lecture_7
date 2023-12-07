using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using Week_7_1.API.Models;
using Week_7_1.Domain.Entities;
using Week_7_1.Persistence.Contexts;

namespace Week_7_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Week_7_1DbContext _context;
        public UsersController()
        {
            _context = new();
        }
        [HttpGet]
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
        [HttpPost]
        public void CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            Week_7_1.Domain.Entities.User user = new();
            {
                FirstName = createUserRequest.FirstName,
                LastName = createUserRequest.LastName,
                CreatedOn = DateTime.UtcNow,
                CreatedByUserId = "hakan"
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }

    }
}
