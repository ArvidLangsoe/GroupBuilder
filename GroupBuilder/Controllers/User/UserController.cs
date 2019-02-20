using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GroupBuilderApplication.Queries.GetUserList;
using GroupBuilderApplication.Commands.CreateUser;
using GroupBuilderApplication.Queries.GetSingleUser;

namespace GroupBuilder.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IGetUserListQuery _listQuery;
        private ICreateUserCommand _createUserCommand;
        private IGetSingleUserQuery _getSingleUserQuery;

        public UserController(
            IGetUserListQuery listQuery, 
            ICreateUserCommand createUserCommand,
            IGetSingleUserQuery singleUserQuery)
        {
            _listQuery = listQuery;
            _createUserCommand = createUserCommand;
            _getSingleUserQuery = singleUserQuery;
        }


        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            if (ModelState.IsValid)
            {
                return Ok(_listQuery.Execute());
            }
            else
            {
                return BadRequest("Error");
            }
          
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            if (ModelState.IsValid)
            {
                return Ok(_getSingleUserQuery.Execute(id));
            }
            else {
                return BadRequest("Error");
            }
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserModel user)
        {
            if (ModelState.IsValid)
            {
                _createUserCommand.Execute(user);
                return Ok();
            }
            else
            {
                return BadRequest("User data error");
            }

        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
