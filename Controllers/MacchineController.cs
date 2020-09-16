using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using w6.Data;
using w6.Models;

namespace w6.Controllers
{
    public class MacchineController : Controller
    {
        private readonly ILogger<MacchineController> _logger; 

        public MacchineController(ILogger<MacchineController> logger)
        {
            _logger = logger; 
        }
    
        public IActionResult Index()
        {
            // 3 prendo i dati
            var macchine = Repository.GetMacchine();

            // 2 creo viewmodel prima con dati schiantati, poi dopo essere sicuri del funzionamento con dati database
            // vedi macchine = new
            var vm = new MacchineListaViewModel
            {
                Macchine = macchine.Select(x => GetListaItem(x)).ToArray()
                // Macchine = new [] { new MacchineListaItemViewModel { Id  = 3, Nome = "LANCIA", UserID = "8"}}
            };

            // 1 ritorno la view e il viewmodel
            return View(vm);
        }

        private MacchineListaItemViewModel GetListaItem(Macchina m)
        {
            var item = new MacchineListaItemViewModel();
            item.Id = m.Id;
            item.Nome = m.Name;
            item.UserID = m.UserId.ToString();
            return item;
        }
    }

}




      