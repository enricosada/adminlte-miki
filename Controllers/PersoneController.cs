using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; 
using w6.Models;

namespace w6.Controllers
{
    public class PersoneController : Controller
    {
        private readonly ILogger<PersoneController> _logger;   

        public PersoneController(ILogger<PersoneController> logger)
        {
            _logger = logger; 
        }

        public ActionResult Mio()
        {
            byte[] data = System.IO.File.ReadAllBytes(@"C:\Users\Miche\Downloads\Doc1.docx");

            return File(data, "application/vnd.openxmlformats-officedocuments.wordprocessingml.document","Doc1.docx");
        }
        

        public static PersonaListaItemViewModel GetListaItem (Persona p)
        {
            var i = new PersonaListaItemViewModel();
            i.Id = p.Id;
            i.FullName = p.Nome + " " + p.Cognome;
            i.Inserimento = p.Inserimento.ToShortDateString();
            i.Documento = p.Documento;
            i.Servizi = p.Servizi;
            i.Tutore = p.Tutore;
            i.Sanitario = p.Sanitario;
            i.Stp = p.Stp;
            i.Dimissione = p.Dimissione.ToString();

            return i;
        }

        public IActionResult Index()
        {
            // prendo fuori i dati
            var persone = Database.Persone;
           
            // li trasformo in una classe comoda per la view
            var info = new PersonaListaViewModel
            {
                Persone = persone.Select(x => GetListaItem(x)).ToArray()
            };
 
            // ritorno la view in base alle info
            return View(info);
        }

        public IActionResult Info(int id)
        {
            var persona = Database.Persone.Where(x => x.Id == id).First();

            var info = new PersonaInfoViewModel
            {
                Id = id,
                Fullname = persona.Nome + " " + persona.Cognome,
                Inserimento = persona.Inserimento.ToShortDateString(),
                Documento = persona.Documento,
                Servizi = persona.Servizi,
                Tutore = persona.Tutore,
                Sanitario = persona.Sanitario,
                Stp = persona.Stp,
                Dimissione = persona.Dimissione.ToString(),
            };

            return View(info);
        }

        public IActionResult Edit(int id) 
        {
            var persona = Database.Persone.Where(x => x.Id == id).First();

            var editpersona = new PersonaEditViewModel
            {
                Id = persona.Id,
                Nome = persona.Nome,
                Cognome = persona.Cognome,
                Inserimento = persona.Inserimento.ToShortDateString(),
                Documento = persona.Documento,
                Servizi = persona.Servizi,
                Tutore = persona.Tutore,
                Sanitario = persona.Sanitario,
                Stp = persona.Stp,
                Dimissione = persona.Dimissione,
                Salvato = false,
            };

            return View(editpersona);
        }

       
        [HttpPost]
        public IActionResult Edit(int id,string nome, string cognome, DateTime inserimento, string documento, string servizi, string tutore, string sanitario, string stp, bool dimissione) 
        {
            var persona = Database.Persone.Where(x => x.Id == id).First();

            persona.Nome = nome; 
            persona.Cognome = cognome;
            persona.Inserimento = inserimento;
            persona.Documento = documento;
            persona.Servizi = servizi;
            persona.Tutore = tutore;
            persona.Sanitario = sanitario;
            persona.Stp = stp;
            persona.Dimissione = dimissione;



            var editpersona = new PersonaEditViewModel
            {
                Id = persona.Id,
                Nome = persona.Nome,
                Cognome = persona.Cognome,
                Inserimento = persona.Inserimento.ToShortDateString(), 
                Documento = persona.Documento,
                Servizi = persona.Servizi,
                Tutore = persona.Tutore,
                Sanitario = persona.Sanitario,
                Stp = persona.Stp,
                Dimissione = persona.Dimissione,
                Salvato = true
            };

            return View(editpersona);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
