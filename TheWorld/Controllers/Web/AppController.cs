using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TheWorld.Models;
using TheWorld.Services;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {
        private readonly IConfigurationRoot _config;
        private readonly IWorldRepository _repository;
        private readonly ILogger<AppController> _logger;
        private readonly IMailService _mailService;

        public AppController(IMailService mailService, IConfigurationRoot config,
                        IWorldRepository repository, ILogger<AppController> logger)
        {
            _config = config;
            _repository = repository;
            _logger = logger;
            _mailService = mailService;
        }

        public IActionResult Index()
        {
            try
            {
                var data = _repository.GetAllTrips();

                return View(data);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get trips in Index page {ex.Message}");
                return Redirect("/error");
            }
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (model.Email.Contains("aol.com"))
            {
                ModelState.AddModelError("", "We don't support AOL addresses");
            }

            if (ModelState.IsValid)
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, "From The World", model.Message);
            }

            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
