using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GroupBuilderApplication.Commands.CreateRoom;
using GroupBuilderApplication.Queries.GetRoomDetails;
using GroupBuilderApplication.Queries.GetRoomList;
using GroupBuilderApplication.Commands.RemoveRoom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GroupBuilderApplication.Commands.AddParticipant;
using GroupBuilderApplication.Shared;
using GroupBuilderApplication.Commands.RemoveParticipant;
using Microsoft.AspNetCore.Authorization;
using GroupBuilderApplication.Commands.RandomizeGroups;
using GroupBuilderApplication.Commands.RandomizeRoom;
using GroupBuilderApplication.Queries.GetGroupDetails;

namespace GroupBuilder.Controllers.Room
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {


        // GET: api/Room
        [HttpGet]
        public IActionResult Get([FromServices] IGetRoomListQuery getRoomListQuery)
        {
            if (ModelState.IsValid)
            {
                var rooms = getRoomListQuery.Execute();

                return Ok(rooms);
            }
            else
            {
                return BadRequest("Error");
            }
        }

        // GET: api/Room/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetRoomDetailsQuery getRoomDetailsQuery)
        {
            if (ModelState.IsValid)
            {
                var room = getRoomDetailsQuery.Execute(id);
                if (room == null)
                {
                    return NotFound();
                }
                return Ok(room);
            }
            else
            {
                return BadRequest("Error");
            }
        }

        // POST: api/Room

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateRoomModel newRoom, [FromServices] ICreateRoomCommand createRoomCommand)
        {
            if (ModelState.IsValid)
            {
                var storedRoom = createRoomCommand.Execute(newRoom);
                return Created(Request.Path.Value + "/" + storedRoom.Id, storedRoom);
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveRoomCommand removeRoomCommand)
        {
            if (ModelState.IsValid)
            {
                removeRoomCommand.Execute(id);
                return Ok();
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [Authorize]
        [HttpPost("{id}/Participants")]
        public IActionResult AddParticipant(int id, [FromBody] Participant participant, [FromServices] AddParticipantCommand addParticipantCommand)
        {
            if (ModelState.IsValid)
            {
                addParticipantCommand.Execute(participant, id);
                return Ok();
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [Authorize]
        [HttpDelete("{id}/Participants")]
        public IActionResult RemoveParticipant(int id, [FromBody] Participant participant, [FromServices] IRemoveParticipantCommand removeParticipantCommand)
        {
            if (ModelState.IsValid)
            {
                removeParticipantCommand.Execute(participant, id);
                return Ok();
            }
            else
            {
                return BadRequest("Error");
            }
        }


        [Authorize]
        [HttpPost("{roomId}/Randomizer")]
        public IActionResult RandomizeGroups(int roomId, [FromBody] RandomizerModel randomizerModel, [FromServices] IRandomizeRoomCommand randomiseRoomCommand) {
            if (ModelState.IsValid)
            {
                List<GroupDetailModel> groups = randomiseRoomCommand.Execute(roomId, randomizerModel);
                return Ok(groups);
            }
            else
            {
                return BadRequest("Error");
            }
        }

    }
}
