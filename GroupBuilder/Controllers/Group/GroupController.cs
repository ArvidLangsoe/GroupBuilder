using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupBuilderApplication.Commands.AddGroupMember;
using GroupBuilderApplication.Commands.CreateGroup;
using GroupBuilderApplication.Commands.RemoveGroup;
using GroupBuilderApplication.Commands.RemoveGroupMember;
using GroupBuilderApplication.Queries;
using GroupBuilderApplication.Queries.GetGroupDetails;
using GroupBuilderApplication.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroupBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {

        [Authorize]
        [HttpGet]
        public IActionResult Get([FromServices] IGetGroupListQuery getGroupListQuery)
        {
            if (ModelState.IsValid)
            {
                var groups = getGroupListQuery.Execute();

                return Ok(groups);
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetGroupDetailsQuery getGroupDetailsQuery)
        {
            if (ModelState.IsValid)
            {
                var group = getGroupDetailsQuery.Execute(id);
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

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateGroupModel newGroup, [FromServices] ICreateGroupCommand createGroupCommand)
        {
            if (ModelState.IsValid)
            {
                var storedGroup = createGroupCommand.Execute(newGroup);
                return Created(Request.Path.Value + "/" + storedGroup.Id, storedGroup);
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveGroupCommand removeGroupCommand)
        {
            if (ModelState.IsValid)
            {
                removeGroupCommand.Execute(id);
                return Ok();
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [Authorize]
        [HttpPost("{id}/Members")]
        public IActionResult AddMember(int id, [FromBody] Member newMember, [FromServices] IAddGroupMemberCommand addGroupMemberCommand)
        {
            if (ModelState.IsValid)
            {
                addGroupMemberCommand.Execute(id, newMember);
                return Ok();
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [Authorize]
        [HttpDelete("{id}/Members")]
        public IActionResult RemoveMember(int id, [FromBody] Member member, [FromServices] IRemoveGroupMemberCommand removeGroupMemberCommand)
        {
            if (ModelState.IsValid)
            {
                removeGroupMemberCommand.Execute(id, member);
                return Ok();
            }
            else
            {
                return BadRequest("Error");
            }
        }
    }
}