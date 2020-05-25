using System.Collections.Generic;
using w6.Models;

namespace w6
{
    public class Database 
    {
        public static List<Persona> Persone = new List<Persona>()
                                                {
                                                        new Persona { Id = 1, Nome = "Enrico", Cognome = "Sada" },
                                                        new Persona { Id = 2, Nome = "Lica", Cognome = "Rossi" },
                                                };
    
    }
}