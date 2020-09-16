using System;

namespace w6.Models
{
    public class MacchineListaViewModel
    {
          public MacchineListaItemViewModel[] Macchine { get; set; }
    }

    public class MacchineListaItemViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UserID { get; set; }
        
    }
}
