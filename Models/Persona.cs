using System;

namespace w6.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
    }

    public class PersonaInfoViewModel
    {
        public int Id { get; set; }

        public string Fullname { get; set;}
        
    }
    public class PersonaListaViewModel
    {
        public PersonaListaItemViewModel[] Persone { get; set; }
    }

    public class PersonaListaItemViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }    
}
