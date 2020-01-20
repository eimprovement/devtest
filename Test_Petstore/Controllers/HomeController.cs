using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Test_Petstore.Models;

namespace Test_Petstore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration config;

        public Petstore.BL.PetBL petBL;

        public HomeController(IConfiguration config)
        {
            this.config = config;

            petBL = new Petstore.BL.PetBL();
        }

        public IActionResult Index(string status = "available")
        {
            return View(petBL.findByStatus(config["PetStoreApi:UrlServiceBase"] + string.Format(config["PetStoreApi:FindByStatus"], status)));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create(long id)
        {
            return View("_Create");
        }

        public IActionResult Delete(long id)
        {
            Dictionary<string, string> apiKey = new Dictionary<string, string>();

            apiKey.Add("api_key", config["PetStoreApi:ApiKey"]);

            petBL.delete(config["PetStoreApi:UrlServiceBase"] + string.Format(config["PetStoreApi:FindById"], id), apiKey);

            return Json("Deleted!");
        }

        public IActionResult AddNewPet(Petstore.ET.PetET petET)
        {
            var newPetET = petBL.addNew(config["PetStoreApi:UrlServiceBase"] + config["PetStoreApi:AddNew"], petET);

            ViewBag.newId = newPetET.id;

            TempData["newId"] = newPetET.id;

            return Json(newPetET);
        }

        public IActionResult Edit(long id)
        {
            var currentId = TempData["newId"];

            if (id != 0)
            {
                currentId = id;
            }

            return View(petBL.findById(config["PetStoreApi:UrlServiceBase"] + string.Format(config["PetStoreApi:FindById"], currentId )));                 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SavePetStatus(Petstore.ET.PetET petET)
        {
            try
            {
                var currentPetETData = petBL.findById(config["PetStoreApi:UrlServiceBase"] + string.Format(config["PetStoreApi:FindById"], petET.id));

                currentPetETData.status = petET.status;

                Dictionary<string, string> apiKey = new Dictionary<string, string>();

                apiKey.Add("api_key", config["PetStoreApi:ApiKey"]);

                petBL.update(config["PetStoreApi:UrlServiceBase"] + string.Format(config["PetStoreApi:Update"], petET.id), currentPetETData, apiKey);

                return Json("Saved!");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
         
        }
 
    }
}
