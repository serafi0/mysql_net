using System;
using Microsoft.EntityFrameworkCore;

namespace waw.Models
{
    public class CommandContext : DbContext
    {
        public CommandContext(DbContextOptions<CommandContext> options) : base(options)
        {
        }

        public DbSet<Command> CommandItems { get; set; }
    }
}
