using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using waw.Models;

namespace waw.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {

        private readonly CommandContext _context;

        public CommandsController(CommandContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetCommandItems()
        {
            return _context.CommandItems;
        }

    }
}

