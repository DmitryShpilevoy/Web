using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TheWorld.Models;
using TheWorld.Services;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {
        private readonly IConfigurationRoot _config;
        private readonly IWorldRepository _repository;
        private readonly IMailService _mailService;

        public AppController(IMailService mailService, IConfigurationRoot config, IWorldRepository repository)
        {
            _config = config;
            _repository = repository;
            _mailService = mailService;
        }

        public IActionResult Index()
        {
            var data = _repository.GetAllTrips();

            return View(data);
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
