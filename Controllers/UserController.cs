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
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public UserController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var utente = Users.CurrentUser;

            var userInfo = new UserInfoViewModel
            {
                Nome = utente.Nome,
                Location = utente.Location
            };

            return View("Info", userInfo);
        }

        public IActionResult Edit()
        {
            var utente = Users.CurrentUser;

            var model = new UserEditViewModel
            {
                Nome = utente.Nome,
                Eta = utente.Eta,
                Sportiva = utente.Sportiva
            };

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(UserEditFormData data)
        {
            this._logger.LogInformation("nome: " + data.Nome);
            this._logger.LogInformation("eta': " + data.Eta);
            this._logger.LogInformation("sportiva: " + data.Sportiva);

            Users.CurrentUser.Nome = data.Nome;
            Users.CurrentUser.Eta = data.Eta;
            Users.CurrentUser.Sportiva = data.Sportiva;

            var utente = Users.CurrentUser;

            var model = new UserEditViewModel
            {
                Nome = utente.Nome,
                Eta = utente.Eta,
                Sportiva = utente.Sportiva,
                Salvato = true
            };

            return View("Edit", model);
        }
    }
}
