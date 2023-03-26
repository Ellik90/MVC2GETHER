using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC2GETHER.Models;

namespace MVC2GETHER.Controllers;

public class MatchesController : Controller
{
    private readonly MatchService _matchService;

    public MatchesController(MatchService matchService)
    {
        _matchService = matchService;
    }

    public IActionResult MyMatche()
    {
        return View();
    }

    [HttpGet]
    public IActionResult MyMatches()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        var matches = _matchService.GetMatches(userId.Value);

        return View(matches);
    }

    // [HttpGet]
    // public IActionResult MyMatches()
    // {
    //     List<MVC2GETHER.Models.User> matches = // hämta matchinformationen från databasen
    // return View(matches);
    // }


    //     public IActionResult MyMatches()
    // {
    //     var userId = HttpContext.Session.GetInt32("UserId");
    //     var user = new User { Id = userId };
    //     var matches = _matchService.GetMatches(user);

    //     return View(matches);
    // }
}