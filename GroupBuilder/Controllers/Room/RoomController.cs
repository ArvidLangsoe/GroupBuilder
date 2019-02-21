using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupBuilderApplication.Commands.CreateRoom;
using GroupBuilderApplication.Queries.GetRoomDetails;
using GroupBuilderApplication.Queries.GetRoomList;
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

        public RoomController(ICreateRoomCommand createRoomCommand, IGetRoomListQuery getRoomListQuery, IGetRoomDetailsQuery getRoomDetailsQuery) {
            _createRoomCommand = createRoomCommand;
            _getRoomListQuery = getRoomListQuery;
            _getRoomDetailsQuery = getRoomDetailsQuery;
        }

        // GET: api/Room
        [HttpGet]
        public IActionResult Get()
        {
            if (ModelState.IsValid)
            {
                return Ok(_getRoomListQuery.Execute());
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
                return Ok(_getRoomDetailsQuery.Execute(id));
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
                _createRoomCommand.Execute(newRoom);
                return Ok();
            }
            else {
                return BadRequest("Something went wrong");
            }
        }

        // PUT: api/Room/5
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
