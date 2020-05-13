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

        public IActionResult Index()
        {
            var persone = new[] {
                new PersonaListaItemViewModel { Id = 1, FullName = "Enrico Sada" },
                new PersonaListaItemViewModel { Id = 2, FullName = "Lica Rossi" },
            };

            var info = new PersonaListaViewModel
            {
                Persone = persone
            };

            return View(info);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
