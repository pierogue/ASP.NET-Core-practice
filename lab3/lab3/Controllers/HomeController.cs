using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using lab3.Models;

namespace lab3.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    

    // public string Index (Dictionary<string,string> items)
    // {
    //     string result = "";
    //     foreach (var item in items)
    //     {
    //         result = $"{result} {item.Key} - {item.Value}; ";
    //     }
    //     return result ;
    // }
    
    public IActionResult Index()
    {
        return View();
    }

   
    protected internal string Hello() => "hello asp net";
    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}