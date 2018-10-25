using Bookstore.Models;
using Bookstore.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Bookstore.Controllers
{
    [Route("api/user/{id}")]
    public class APIUsersController : ApiController
    {
        UsersService uService = new UsersService();

        // GET: api/APIUsers
        [Route("api/users")]
        public IEnumerable<VMUser> GetUsers()
        {
            return uService.GetAllUsers();
        }

        // GET: api/APIUsers/5
        [ResponseType(typeof(VMUser))]
        public IHttpActionResult GetDBUser(Guid id)
        {
            VMUser user = uService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/APIUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDBUser(Guid id, VMUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserID)
            {
                return BadRequest();
            }

            uService.UpdateUser(user);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/APIUsers
        [ResponseType(typeof(VMUser))]
        public IHttpActionResult PostDBUser(VMUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            uService.AddUser(user);
            return CreatedAtRoute("DefaultApi", new { id = user.UserID }, user);
        }

        // DELETE: api/APIUsers/5
        [ResponseType(typeof(VMUser))]
        public IHttpActionResult DeleteDBUser(Guid id)
        {
            VMUser user = uService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            uService.AddUser(user);
            return Ok(user);
        }
    }
}