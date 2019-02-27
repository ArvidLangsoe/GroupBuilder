using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GroupBuilderApplication.Queries.GetUserList;
using GroupBuilderApplication.Commands.CreateUser;
using GroupBuilderApplication.Queries.GetSingleUser;
using GroupBuilderApplication.Commands.RemoveUser;
using GroupBuilderApplication.Commands.LoginUser;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Text;
using System.Security.Claims;
using GroupBuilder.Controllers.Utility;
using Microsoft.AspNetCore.Authorization;

namespace GroupBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Authentication _authentication;

        public UserController(IOptions<Authentication> appSettings)
        {
            _authentication = appSettings.Value;
        }


        // GET: api/User
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromServices] IGetUserListQuery listQuery)
        {
            if (ModelState.IsValid)
            {
                return Ok(listQuery.Execute());
            }
            else
            {
                return BadRequest("Error");
            }

        }

        // GET: api/User/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetSingleUserQuery getSingleUserQuery)
        {
            if (ModelState.IsValid)
            {
                return Ok(getSingleUserQuery.Execute(id));
            }
            else {
                return BadRequest("Error");
            }
        }


        [HttpPost("authentication")]
        public IActionResult Authenticate([FromBody] LoginUserModel loginUserModel, [FromServices] ILoginUserCommand loginUserCommand)
        {
            var user = loginUserCommand.Execute(loginUserModel);

            if (user == null)
                return BadRequest("Something went wrong");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authentication.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);


            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                User = user,
                Token = tokenString
            });
        }



        // POST: api/User
        [HttpPost]
        public IActionResult Register([FromBody] CreateUserModel user, [FromServices] ICreateUserCommand createUserCommand)
        {
            if (ModelState.IsValid)
            {
                var storedUser = createUserCommand.Execute(user);
                return Created(Request.Path.Value + "/" + storedUser.Id, storedUser);
            }
            else
            {
                return BadRequest("User data error");
            }

        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveUserCommand removeUserCommand)
        {
            if (ModelState.IsValid)
            {
                removeUserCommand.Execute(id);
                return Ok();
            }
            else {
                return BadRequest("Error");
            }
        }
    }
}
