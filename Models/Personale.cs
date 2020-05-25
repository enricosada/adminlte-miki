using System;

namespace w6.Models
{
     public class PersonaleListaItemViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Datahire { get; set; }
    }

    public class PersonaleListaViewModel
    {
        public PersonaleListaItemViewModel[] Persone { get; set;}
    }


}
