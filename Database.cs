using System.Collections.Generic;
using w6.Models;

namespace w6
{
    public class Database 
    {
        public static List<Persona> Persone = new List<Persona>()
                                                {
                                                        new Persona { Id = 1, Nome = "Enrico", Cognome = "Sada", Inserimento = new System.DateTime(2016,11,12), Documento = "Carta Identita AX465684",Servizi = "Comune di Ancona", Tutore = "Paolo Bori", Sanitario = "Tessera sanitaria", Dimissione = false, },
                                                        new Persona { Id = 2, Nome = "Luca", Cognome = "Rossi", Inserimento = new System.DateTime(2019,05,06), Documento = "Carta Identita AL458975",Servizi = "Comune di Falconara", Tutore = "Andrea Gissi", Sanitario = "Tessera sanitaria", Dimissione = false,},
                                                };
    
    }
}