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
    public class PersonaleController : Controller
    {
        private readonly ILogger<PersonaleController> _logger;

        public PersonaleController(ILogger<PersonaleController> logger)
        {
            _logger = logger; 
        }
      

     public IActionResult Lista (int id)
        {
            var item1 = new PersonaleListaItemViewModel 
            {
                Id = 1,
                Nome = "Michele",
                Datahire = new DateTime(2016, 06, 29), 
            };

            var item2= new PersonaleListaItemViewModel    
            {
                Id = 2,
                Nome = "Samuele",
                Datahire = new DateTime(2018, 09, 12), 
            };

            var item3= new PersonaleListaItemViewModel    
            {
                Id = 3,
                Nome = "Giulia",
                Datahire = new DateTime(2015, 07, 12), 
            }; 

            var lista = new PersonaleListaViewModel
            {
                Persone = new[] { item1, item2, item3 }
            };

            

            return View(lista);
        }
    
    }

}