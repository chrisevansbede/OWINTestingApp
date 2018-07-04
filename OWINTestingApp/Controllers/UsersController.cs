using OWINTestingApp.Models;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace OWINTestingApp.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/users
        public IHttpActionResult Get()
        {
            using (var db = new DatabaseContext())
            {
                return Ok(db.Users.ToList());
            }
        }

        // GET api/users/5
        public User Get(int id)
        {
            using (var db = new DatabaseContext())
            {
                return db.Users.FirstOrDefault(u => u.UserId == id);
            }
        }

        // POST api/users
        public void Post([FromBody]User user)
        {
            using (var db = new DatabaseContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

            Ok();
        }

        // PUT api/users/5
        public void Put([FromBody]User user)
        {
            using (var db = new DatabaseContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

            Ok();
        }

        // DELETE api/users/5
        public void Delete(int id)
        {
            using (var db = new DatabaseContext())
            {
                var user = db.Users.FirstOrDefault(u => u.UserId == id);
                if (user == null)
                {
                    return;
                }
                db.Users.Remove(user);
                db.SaveChanges();
            }

            Ok();
        }
    }
}
