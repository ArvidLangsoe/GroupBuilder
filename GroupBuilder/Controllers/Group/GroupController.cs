using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupBuilderApplication.Commands.AddGroupMember;
using GroupBuilderApplication.Commands.CreateGroup;
using GroupBuilderApplication.Commands.RemoveGroup;
using GroupBuilderApplication.Queries;
using GroupBuilderApplication.Queries.GetGroupDetails;
using GroupBuilderApplication.Shared;
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
        private IRemoveGroupCommand _removeGroupCommand;
        private IAddGroupMemberCommand _addGroupMemberCommand;
        private readonly IGetGroupDetailsQuery _getGroupDetailsQuery;

        public GroupController(ICreateGroupCommand createGroupCommand, IGetGroupListQuery getGroupListQuery, IGetGroupDetailsQuery getGroupDetailsQuery, IRemoveGroupCommand removeGroupCommand, IAddGroupMemberCommand groupMemberCommand) {
            _createGroupCommand = createGroupCommand;
            _getGroupListQuery = getGroupListQuery;
            _getGroupDetailsQuery = getGroupDetailsQuery;
            _removeGroupCommand = removeGroupCommand;
            _addGroupMemberCommand = groupMemberCommand;
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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (ModelState.IsValid)
            {
                var group = _getGroupDetailsQuery.Execute(id);
                if (group == null)
                {
                    return NotFound();
                }
                return Ok(group);
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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _removeGroupCommand.Execute(id);
                return Ok();
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [HttpPost("{id}/Members")]
        public IActionResult AddParticipant(int id, [FromBody] Member newMember)
        {
            if (ModelState.IsValid)
            {
                _addGroupMemberCommand.Execute(id, newMember);
                return Ok();
            }
            else
            {
                return BadRequest("Error");
            }
        }
    }
}