using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Models
{
    public class UsersController : ApiController
    {
        ClientAgentEntities db = new ClientAgentEntities();
        [HttpGet]
        [Route("api/Users/{lastName}")]
        public IHttpActionResult GetUsers(string lastName)
        {
            var foundUser = db.Client.FirstOrDefault(u => u.LastName == lastName);
            if (foundUser == null)
                return BadRequest("Пользователя с таким именем не существует");
            else
                return Ok(new
                {
                    foundUser.LastName,
                    Agent = foundUser.Agent.LastName
                });

        }
    }
}
