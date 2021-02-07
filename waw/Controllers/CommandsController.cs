using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using waw.Models;
using waw.ViewModels;

namespace waw.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {

        private readonly CommandContext _context;
        private readonly IMapper _mapper;

        public CommandsController(CommandContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }


        [HttpGet]
        public ActionResult<IEnumerable<CommandDTO>> GetCommandItems()
        {


            //return _context.CommandItems;
            //return _context.CommandItems.ProjectTo<CommandDTO,Command>;
            //var firstNameQuery = db.People
            //    .Where(p => p.FirstName == "Joe")
            //    .ProjectTo<PersonDetail>(mapperConfig);
            //var ageQuery = db.People
            //    .Where(p => p.FirstName == "Joe")
            //    .ProjectTo<PersonDetail>(mapperConfig);
            //var results = firstNameQuery.Union(ageQuery).ToList();
            //return _context.CommandItems;
            return Ok(_mapper.Map<IEnumerable<CommandDTO>>(_context.CommandItems));






        }

        private ActionResult<IEnumerable<Command>> View(List<CommandDTO> dtos)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public ActionResult<CommandDTO> GetCommandItem(int id)
        {
            var commandItem = _context.CommandItems.Find(id);

            if (commandItem == null)
            {
                return NotFound();
            }
            return _mapper.Map<CommandDTO>(commandItem);
        }
        //[HttpGet("{id}")]
        //public Command Get(int id) => _context.CommandItems.Find(id);


        [HttpPost]
        public ActionResult<Command> PostCommandItem(Command command)
        {
            _context.CommandItems.Add(command);
            _context.SaveChanges();

            return CreatedAtAction("GetCommandItem", new Command { Id = command.Id }, command);
        }

        [HttpPut("{id}")]
        public ActionResult PutCommandItem(int id, Command command)
        {
            if (id != command.Id)
            {
                return BadRequest();

            }
            _context.Entry(command).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();



        }

        [HttpDelete("{id}")]
        public ActionResult<Command> DeleteCommandItem(int id)
        {
            var commandItem = _context.CommandItems.Find(id);
            if(commandItem == null)
            {
                return NotFound();

            }
            _context.CommandItems.Remove(commandItem);
            _context.SaveChanges();

            return commandItem;
        }
    }
}

