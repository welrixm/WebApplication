using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Models
{
    public class UsersController : ApiController
    {
        UserAPIEntities db = new UserAPIEntities();
        [HttpGet]
        [Route("api/Users/GetAllUsers")]
        public IHttpActionResult GetAllUsers()
        {
            //var foundUser = db.User.FirstOrDefault(u => u.Name == name);
            //if (foundUser == null)
            //    return BadRequest("Пользователя с таким именем не существует");
            //else
            //    return Ok(new
            //    {
            //        foundUser.Name,
            //        Role = foundUser.Role.Name
            //    });
            return Ok(db.User.Select(u => new
            {
                u.Name,
                Role = u.Role.Name
            }));

        }
        [HttpPost]
        [Route("api/Users/Add")]
        public IHttpActionResult PostUser(User user)
        {
            if (user != null)
            {
                db.User.Add(user);
                db.SaveChanges();
            }
            return Ok();
        }
        [HttpPut]
        [Route("api/Users/Edit/{id}")]
        public IHttpActionResult PutUser(int id)
        {
            var user = db.User.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return BadRequest("Пользователь не найден");
            db.Entry(user).State = EntityState.Modified;
            return Ok();
        }
        [HttpDelete]
        [Route("api/Users/Delete/{name}")]
        public IHttpActionResult DeleteUser(string name)
        {
            var user = db.User.FirstOrDefault(u => u.Name == name);
            if (user == null)
                return BadRequest("Пользователь не найден");
            db.User.Remove(user);
            db.SaveChanges();
            return Ok();
        }
    }
}
