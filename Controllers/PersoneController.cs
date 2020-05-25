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

        public static PersonaListaItemViewModel GetListaItem (Persona p)
        {
            var i = new PersonaListaItemViewModel();
            i.Id = p.Id;
            i.FullName = p.Nome + " " + p.Cognome;

            return i;
        }

        public IActionResult Index()
        {
            var persone = Database.Persone.Select(x => GetListaItem(x)).ToArray();
           
            var info = new PersonaListaViewModel
            {
                Persone = persone
            };
 
            return View(info);
        }

        public IActionResult Info(int id)
        {
            var persona = Database.Persone.Where(x => x.Id == id).First();

            var info = new PersonaInfoViewModel
            {
                Id = id,
                Fullname = persona.Nome + " " + persona.Cognome
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
                Salvato = false,
            };

            return View(editpersona);
        }

       
        [HttpPost]
        public IActionResult Edit(int id, string nome, string cognome) 
        {
            var persona = Database.Persone.Where(x => x.Id == id).First();

            persona.Nome = nome;
            persona.Cognome = cognome;


            var editpersona = new PersonaEditViewModel
            {
                Id = persona.Id,
                Nome = persona.Nome,
                Cognome = persona.Cognome,
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
