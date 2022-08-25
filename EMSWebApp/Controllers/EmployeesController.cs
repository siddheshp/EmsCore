using EmsModelLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EMSWebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private string apiBaseUrl;
        public EmployeesController(IConfiguration config)
        {
            apiBaseUrl = config["ApiBaseUrl"];
        }
        // GET: EmployeesController
        public ActionResult Index()
        {
            List<Employee> employeeList = new List<Employee>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                //https://localhost:44321/api/employees
                var response = client.GetAsync("employees").Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    employeeList = JsonConvert.DeserializeObject<List<Employee>>(responseString);
                    return View(employeeList);
                }
                else
                {
                    ModelState.AddModelError("", "Error while calling API");
                }
            }
            return View(employeeList);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            //get dept list
            GetDepartmentList();
            
            return View();
        }

        private void GetDepartmentList()
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
                }
                else
                {
                    ModelState.AddModelError("", "Error while calling API");
                }
            }
            ViewBag.DepartmentList = new SelectList(deptList, "Id", "Name");
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
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

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeesController/Edit/5
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

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
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
