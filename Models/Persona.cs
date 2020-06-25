using System;

namespace w6.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime Inserimento{ get; set; }
        public string Documento{ get; set; }
        public string Servizi{ get; set; }
        public string Tutore{ get; set; }
        public string Sanitario{ get; set; }
        public string Stp { get; set; }
        public bool Dimissione{ get; set; }
    }

    public class PersonaInfoViewModel
    {
        public int Id { get; set; }

        public string Fullname { get; set;}
        public string Inserimento{ get; set; }
        public string Documento{ get; set; }
        public string Servizi{ get; set; }
        public string Tutore{ get; set; }
        public string Sanitario{ get; set; }
        public string Stp { get; set; }
        public string Dimissione{ get; set; }

    }
    public class PersonaListaViewModel
    {
        public PersonaListaItemViewModel[] Persone { get; set; }
    }

    public class PersonaListaItemViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Inserimento{ get; set; }
        public string Documento{ get; set; }
        public string Servizi{ get; set; }
        public string Tutore{ get; set; }
        public string Sanitario{ get; set; }
        public string Stp { get; set; }
        public string Dimissione{ get; set; }
    }  

    public class PersonaEditViewModel
    {
        public int Id { get; set; }
        public string Nome{ get; set; }
        public string Cognome{ get; set; }
        public string Inserimento{ get; set; }
        public string Documento{ get; set; }
        public string Servizi{ get; set; }
        public string Tutore{ get; set; }
        public string Sanitario{ get; set; }
        public string Stp { get; set; }
        public string Dimissione{ get; set; }
        public bool Salvato { get; set; }

    }  

    
}
