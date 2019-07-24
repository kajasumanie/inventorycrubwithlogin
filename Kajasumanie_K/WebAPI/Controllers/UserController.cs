using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly ModelItemContext _context;

        public UserController(ModelItemContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<User> GetUser()
        {
            return _context.User;
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.User.SingleOrDefaultAsync(m => m.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost("{token}")]
        [Route("token")]
        public ActionResult CreateToken([FromBody] User item_2)
        {
            var item_1 = _context.User.FirstOrDefault(t => t.UserName == item_2.UserName && t.Password == item_2.Password);
            if (item_1 == null)
            {
                return NotFound();
            }
            _context.User.Update(item_1);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.User.SingleOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        

      //  [AllowAnonymous]
      //  [HttpPost("authenticate")]
       // public IActionResult Authenticate([FromBody]UserDto userDto)
       // {
         //   var user = _userService.Authenticate(userDto.Username, userDto.Password);

          //  if (user == null)
             //   return BadRequest(new { message = "Username or password is incorrect" });

           // var tokenHandler = new JwtSecurityTokenHandler();
           // var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
          //  var tokenDescriptor = new SecurityTokenDescriptor
          //  {
              //  Subject = new ClaimsIdentity(new Claim[]
              //  {
                 //   new Claim(ClaimTypes.Name, user.Id.ToString())
              //  }),
              //  Expires = DateTime.UtcNow.AddDays(7),
               // SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
          //  };
           // var token = tokenHandler.CreateToken(tokenDescriptor);
          //  var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
         //   return Ok(new
          //  {
             //   Id = user.Id,
              //  Username = user.Username,
              //  FirstName = user.FirstName,
              //  LastName = user.LastName,
               // Token = tokenString
         //   });
     //   }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.UserId == id);
        }
    }
}