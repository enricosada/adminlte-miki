using System.Collections.Generic;
using w6.Models;

namespace w6
{
    public class Database 
    {
        public static List<Persona> Persone = new List<Persona>()
                                                {
                                                        new Persona { Id = 1, Nome = "Enrico", Cognome = "Sada", Inserimento = "12/11/2016",Documento = "Carta Identita AX465684",Servizi = "Comune di Ancona", Tutore = "Paolo Bori", Sanitario = "Tessera sanitaria", Dimissione = "No", },
                                                        new Persona { Id = 2, Nome = "Luca", Cognome = "Rossi", Inserimento = "05/06/2019",Documento = "Carta Identita AL458975",Servizi = "Comune di Falconara", Tutore = "Andrea Gissi", Sanitario = "Tessera sanitaria", Dimissione = "No",},
                                                };
    
    }
}