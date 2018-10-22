using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PostbackModelRetain.Models;

namespace PostbackModelRetain.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> Step1()
        {
            await Task.Delay(100);
            return View(new TransferViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Step1(TransferViewModel model)
        {
            await Task.Delay(100);
            model.ViewName = "Step2";
            PostData = model;
            return RedirectToRoute("postBackRoute", new { action = "InBetweenPage" });
          // return RedirectToAction("InbetweenPage", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Step2(TransferViewModel model)
        {
            await Task.Delay(50);
            model.ViewName = "Step3";
            PostData = model;
            return RedirectToRoute("postBackRoute", new { action = "InbetweenPage" });
        }

        [HttpPost]
        public async Task<IActionResult> Step3(TransferViewModel model)
        {
            await Task.Delay(50);
            return View(model);
        }

        
        public IActionResult InBetweenPage()
        {
            if(PostData==null)
                return RedirectToRoute("postBackRoute", new { action = "Step1" });
            return View(PostData.ViewName, PostData);
            // return View(PostData.ViewName, PostData);
            
        }


        public TransferViewModel PostData
        {
            get
            {
                //  return JsonConvert.DeserializeObject<TransferViewModel>((string)TempData["TransferViewModel"]);
                return TempExtensions.Get<TransferViewModel>(TempData,"TransferViewModel");
            }
            set
            {
                // TempData["TransferViewModel"] = JsonConvert.SerializeObject(value);
                TempExtensions.Save<TransferViewModel>(TempData, "TransferViewModel", value);
            }
             
        }

     }
}
