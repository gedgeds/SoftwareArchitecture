using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SoftwareArchitecture.Data;
using SoftwareArchitecture.Models;

namespace SoftwareArchitecture.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IRepository<Employee> _repository;
        private const string URL = "http://localhost:5000";

        public EmployeesController(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);
                var response = await client.GetAsync($"/api/employeesApi");
                var result = JsonConvert.DeserializeObject<List<Employee>>(await response.Content.ReadAsStringAsync());

                return View(result);
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _repository.Get(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonId,Name,EmployeeEmail,Salary,BirthDate")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(URL);
                    var response = await client.PostAsync($"/api/employeesApi", content);
                    return RedirectToAction("Index", "Employees");
                }
            }
            return View(employee);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);
                var response = await client.GetAsync($"/api/employeesApi/{id.ToString()}");
                var result = JsonConvert.DeserializeObject<Employee>(await response.Content.ReadAsStringAsync());
                return View(result);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonId,Name,EmployeeEmail,Salary,BirthDate")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(URL);
                    var content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
                    var response = await client.PutAsync($"/api/employeesApi/{employee.Id.ToString()}", content);
                    return RedirectToAction("Index", "Employees");
                }
            }
            return View(employee);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);
                var employee = await client.GetAsync($"/api/employeesApi/{id.ToString()}");
                var result = JsonConvert.DeserializeObject<Employee>(await employee.Content.ReadAsStringAsync());
                return View(result);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);
                await client.DeleteAsync($"/api/employeesApi/{id.ToString()}");
                return RedirectToAction("Index", "Employees");
            }
        }
    }
}
