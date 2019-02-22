using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupBuilderApplication.Commands.CreateGroup;
using GroupBuilderApplication.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroupBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {

        ICreateGroupCommand _createGroupCommand;
        IGetGroupListQuery _getGroupListQuery;

        public GroupController(ICreateGroupCommand createGroupCommand, IGetGroupListQuery getGroupListQuery) {
            _createGroupCommand = createGroupCommand;
            _getGroupListQuery = getGroupListQuery;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (ModelState.IsValid)
            {
                var groups = _getGroupListQuery.Execute();

                return Ok(groups);
            }
            else
            {
                return BadRequest("Error");
            }
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