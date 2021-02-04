using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace waw.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class CommandsController : ControllerBase
        {
            [HttpGet]
            public ActionResult<IEnumerable<string>> GetString()
            {
                return new string[] { "this", "is", "hard", "coded" };
            }

            //private readonly DataContext _context;

            //public PetsController(DataContext context)
            //{
            //    _context = context;
            //}
        }
    }

