using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestTask.UI.Models;
using TestTask.UI.Services;

namespace TestTask.UI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfigurationService _service;

    public HomeController(ILogger<HomeController> logger, IConfigurationService service)
    {
        _logger = logger;
        _service = service;
    }

    public IActionResult Index()
    {
        ViewData.Add("cfg", "somObj");
        return View();
    }

    public IActionResult AddConfiguration([FromQuery] string cfg)
    {
        var savedCfg = _service.AddConfiguration(cfg);
        var formattedCfg = JsonConvert.SerializeObject(savedCfg, Formatting.Indented); 
        ViewData.Add("cfg", formattedCfg);
        return View("Index");
    }

    public IActionResult ShowConfiguration(int configuraionId)
    {
        throw new Exception();
    }
}