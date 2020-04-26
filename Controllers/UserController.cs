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
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public UserController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var utente = Database.GetUser(Users.CurrentUserId);

            var userInfo = new UserInfoViewModel
            {
                Nome = utente.Name,
                Location = utente.Location
            };

            return View("Info", userInfo);
        }

        public IActionResult Edit()
        {
            var utente = Database.GetUser(Users.CurrentUserId);

            var model = new UserEditViewModel
            {
                Nome = utente.Name,
                Eta = utente.Age,
                Sportiva = utente.Sporty
            };

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(UserEditFormData data)
        {
            this._logger.LogInformation("nome: " + data.Nome);
            this._logger.LogInformation("eta': " + data.Eta);
            this._logger.LogInformation("sportiva: " + data.Sportiva);

            var utente = Database.GetUser(Users.CurrentUserId);

            utente.Name = data.Nome;
            utente.Age = data.Eta;
            utente.Sporty = data.Sportiva;

            utente = Database.SaveUser(utente);

            var model = new UserEditViewModel
            {
                Nome = utente.Name,
                Eta = utente.Age,
                Sportiva = utente.Sporty,
                Salvato = true
            };

            return View("Edit", model);
        }
    }
}
