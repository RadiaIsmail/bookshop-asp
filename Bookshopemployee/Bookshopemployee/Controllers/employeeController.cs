using Bookshopemployee.Models;
using Bookshopemployee.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bookshopemployee.Controllers
{
    public class employeeController : Controller
    {
        public IActionResult Index()
        {
            var repo = new employeeRepos();
            var data = repo.getAll();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(employee model)
        {
            var repo = new employeeRepos();
            repo.create(model.FirstName);
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            var repo = new employeeRepos();
            employee found = repo.get_by_id(id);
            return View(found);

        }

        [HttpPost]
        public IActionResult Edit(employee model)
        {
            var repo = new employeeRepos();
            repo.update(model.Id, model.FirstName);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var repo = new employeeRepos();
            employee found = repo.get_by_id(id);
            return View(found);

        }

        [HttpPost]
        public IActionResult Delete(employee model)
        {
            var repo = new employeeRepos();
            repo.delete(model.Id);
            return RedirectToAction("Index");
        }
    }
}
