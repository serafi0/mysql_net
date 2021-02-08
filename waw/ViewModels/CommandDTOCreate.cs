using System;
using System.ComponentModel.DataAnnotations;

namespace waw.ViewModels
{
    public class CommandDTOCreate
    {
        //public int Id { get; set; } we don't need an id in the  Create model View
        [Required]
        public string Howto { get; set; }
        [Required]
        public string Commandline { get; set; }
        [Required]
        public string Platform { get; set; }


    }
}
