using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupBuilderApplication.Commands.CreateRoom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroupBuilder.Controllers.Room
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private ICreateRoomCommand _createRoomCommand;

        public RoomController(ICreateRoomCommand createRoomCommand) {
            _createRoomCommand = createRoomCommand;
        }

        // GET: api/Room
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Room/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
