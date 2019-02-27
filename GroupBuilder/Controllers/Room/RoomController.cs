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

namespace GroupBuilder.Controllers.Room
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private ICreateRoomCommand _createRoomCommand;
        private IGetRoomListQuery _getRoomListQuery;
        private readonly IGetRoomDetailsQuery _getRoomDetailsQuery;
        private readonly IRemoveRoomCommand _removeRoomCommand;
        private readonly IAddParticipantCommand _addParticipantCommand;
        private readonly IRemoveParticipantCommand _removeParticipantCommand;

        public RoomController(ICreateRoomCommand createRoomCommand, IRemoveRoomCommand removeRoomCommand, IGetRoomListQuery getRoomListQuery, IGetRoomDetailsQuery getRoomDetailsQuery, IAddParticipantCommand addParticipantCommand, IRemoveParticipantCommand removeParticipantCommand)
        {
            _createRoomCommand = createRoomCommand;
            _getRoomListQuery = getRoomListQuery;
            _getRoomDetailsQuery = getRoomDetailsQuery;
            _removeRoomCommand = removeRoomCommand;
            _addParticipantCommand = addParticipantCommand;
            _removeParticipantCommand = removeParticipantCommand;
        }

        // GET: api/Room
        [HttpGet]
        public IActionResult Get()
        {
            if (ModelState.IsValid)
            {
                var rooms = _getRoomListQuery.Execute();

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
        public IActionResult Get(int id)
        {
            if (ModelState.IsValid)
            {
                var room = _getRoomDetailsQuery.Execute(id);
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
        public IActionResult Post([FromBody] CreateRoomModel newRoom)
        {
            if (ModelState.IsValid)
            {
                var storedRoom = _createRoomCommand.Execute(newRoom);
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
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _removeRoomCommand.Execute(id);
                return Ok();
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [Authorize]
        [HttpPost("{id}/Participants")]
        public IActionResult AddParticipant(int id, [FromBody] Participant participant)
        {
            if (ModelState.IsValid)
            {
                _addParticipantCommand.Execute(participant, id);
                return Ok();
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [Authorize]
        [HttpDelete("{id}/Participants")]
        public IActionResult RemoveParticipant(int id, [FromBody] Participant participant)
        {
            if (ModelState.IsValid)
            {
                _removeParticipantCommand.Execute(participant, id);
                return Ok();
            }
            else
            {
                return BadRequest("Error");
            }
        }
    }
}
