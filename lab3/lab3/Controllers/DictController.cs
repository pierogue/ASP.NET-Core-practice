using lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab3.Controllers;

public class DictController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(new DictViewModel());
    }

    [HttpPost]
    public IActionResult AddSave(string name, string number)
    {
        ViewBag.Name = name;
        ViewBag.Number = number;
        var model = new DictViewModel();
        model.Add(name, number);
        
        return View(model);
       
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Update()
    {
        return View();
    }

    [HttpPost]
    public IActionResult UpdateSave(string name, string number)
    {
        var dict = new DictViewModel();
        dict.Update(name, number);
        return View();
    }

    [HttpGet]
    public IActionResult Delete()
    {
        return View();
    }

    [HttpPost]
    public IActionResult DeleteSave(string name)
    {
        var dict = new DictViewModel();
        dict.Remove(name);
        return View();
    }
}