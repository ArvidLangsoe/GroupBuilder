using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupBuilderApplication.Commands.CreateGroup;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroupBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {

        ICreateGroupCommand _createGroupCommand;

        public GroupController(ICreateGroupCommand createGroupCommand) {
            _createGroupCommand = createGroupCommand;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateGroupModel newGroup)
        {
            if (ModelState.IsValid)
            {
                var storedGroup = _createGroupCommand.Execute(newGroup);
                return Created(Request.Path.Value + "/" + storedGroup.Id, storedGroup);
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}