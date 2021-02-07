using System;
namespace waw.ViewModels
{
    public class CommandDTOCreate
    {
        //public int Id { get; set; } we don't need an id in the  Create model View
        public string Howto { get; set; }
        public string Commandline { get; set; }
        public string Platform { get; set; }


    }
}
