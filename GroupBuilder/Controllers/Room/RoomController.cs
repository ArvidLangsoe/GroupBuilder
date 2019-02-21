﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupBuilderApplication.Commands.CreateRoom;
using GroupBuilderApplication.Queries.GetRoomDetails;
using GroupBuilderApplication.Queries.GetRoomList;
using GroupBuilderApplication.Commands.RemoveRoom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        public RoomController(ICreateRoomCommand createRoomCommand, IRemoveRoomCommand removeRoomCommand, IGetRoomListQuery getRoomListQuery, IGetRoomDetailsQuery getRoomDetailsQuery) {
            _createRoomCommand = createRoomCommand;
            _getRoomListQuery = getRoomListQuery;
            _getRoomDetailsQuery = getRoomDetailsQuery;
            _removeRoomCommand = removeRoomCommand;
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
            else {
                return BadRequest("Error");
            }
        }

        // GET: api/Room/5
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
        [HttpPost]
        public IActionResult Post([FromBody] CreateRoomModel newRoom)
        {
            if (ModelState.IsValid)
            {
                var storedRoom = _createRoomCommand.Execute(newRoom);
                return Created(Request.Path.Value+"/"+storedRoom.Id, storedRoom);
            }
            else {
                return BadRequest("Something went wrong");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _removeRoomCommand.Exceute(id);
                return Ok();
            }
            else {
                return BadRequest("Error");
            }
        }
    }
}
