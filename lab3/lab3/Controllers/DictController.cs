using lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab3.Controllers;

public class DictController : Controller
{
    private DictViewModel model = new DictViewModel();
    
    [HttpGet]
    public IActionResult Index()
    {
        return View(model);
    }

    [HttpPost]
    public IActionResult AddSave(string name, string number)
    {
        model.Add(name, number);
        return View(model);
       
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Update(int? id, string name, string number)
    {
        if (id is null) return View();
        ViewBag.Id = id;
        ViewBag.Name = name;
        ViewBag.Number = number;
        return View();
    }

    [HttpPost]
    public IActionResult UpdateSave(int? id, string? name, string? number)
    {
        if (id is null || name is null || number is null)
        {
            ViewBag.resText = "Запись не найдена";
            return View();
        }
        model.Update((int)id, name, number);
        ViewBag.resText = "Запись успешно обновлена";
        return View();
    }

    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id is null) return View();
        ViewData["id"] = id;
        return View();
    }

    [HttpPost]
    public IActionResult DeleteSave(int id)
    {
        model.Remove(id);
        return View();
    }
    
}