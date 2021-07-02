using Common.Models;
using Common.Utils.Constant;
using Common.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebAppMVC.Controllers
{
    public class ColorController : Controller
    {
        public IActionResult Index()
        {
            //https://localhost:44329/
            IEnumerable<ColorViewModel> colors = null;

            var client = new HttpClient();
            client.BaseAddress = new Uri(Constant.URLBASE);

            var responseTask = client.GetAsync("color");
            responseTask.Wait();

            var result = responseTask.Result;
            if(result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IEnumerable<ColorViewModel>>();
                readTask.Wait();

                colors = readTask.Result;
            }
            else
            {
                colors = Enumerable.Empty<ColorViewModel>();

                ModelState.AddModelError(string.Empty, "Error!");
            }

            return View(colors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Color color)
        {
            if(ModelState.IsValid)
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(Constant.URLBASE);

                var postTask = client.PostAsJsonAsync<Color>("color", color);
                postTask.Wait();

                var result = postTask.Result;
                int statusCodeResult = (int)result.StatusCode;
                if (statusCodeResult==201)
                {
                    return RedirectToAction("Index");
                }
                else if(statusCodeResult==204)
                {
                    ModelState.AddModelError(string.Empty, "Name is exists");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error!");
                }

            }
            return View(color);
        }

        private Color GetColor(int id)
        {
            Color color = null;

            var client = new HttpClient();
            client.BaseAddress = new Uri(Constant.URLBASE);

            var responseTask = client.GetAsync("color/" + id);
            responseTask.Wait();

            var result = responseTask.Result;
            if(result.IsSuccessStatusCode)
            {
                color = result.Content.ReadAsAsync<Color>();
                responseTask.Wait();
            }
            else
            {

            }

            return
        }
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            return View();
        }

    }
}
