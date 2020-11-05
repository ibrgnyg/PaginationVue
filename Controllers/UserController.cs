using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaginationV.FakerData;
using PaginationV.Models;

namespace PaginationV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private List<User> users = FakeUser.AllUser(150);
      
        [HttpGet]
        public IEnumerable<User> AllUser()
        {
            return (users.ToList());
        }
        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            var findem = users.FirstOrDefault(x => x.ID == id);
            return findem;
        }


    }
}