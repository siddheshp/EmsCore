using EmsModelLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace EMSWebApp.Controllers
{
    public class DepartmentsController : Controller
    {
        string apiBaseUrl;
        public DepartmentsController(IConfiguration config)
        {
            apiBaseUrl = config["ApiBaseUrl"];
        }
        // GET: DepartmentsController
        public ActionResult Index()
        {
            List<Department> deptList = new List<Department>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                //https://localhost:44321/api/departments
                var response = client.GetAsync("departments").Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    deptList = JsonConvert.DeserializeObject<List<Department>>(responseString);
                    return View(deptList);
                }
                else
                {
                    ModelState.AddModelError("", "Error while calling API");
                }
            }
            return View(deptList);
        }

        // GET: DepartmentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartmentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartmentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
