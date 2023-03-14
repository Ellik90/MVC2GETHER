using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC2GETHER.Models;

namespace MVC2GETHER.Controllers;

public class AccountController : Controller
{
    private readonly UserService _userService;
    private readonly LoginService _loginService;

    public AccountController(LoginService loginService, UserService userService)
    {
        _loginService = loginService;
        _userService = userService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult LogIn()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string email, string passWord)
    {
        try
        {
            int userId = _loginService.UserLoginIsValid(email, passWord);
            if (userId == 0)
            {
                return RedirectToAction("LogIn", "Account");
            }
            HttpContext.Session.SetInt32("UserId", userId);
            User user = _userService.GetUser(userId);
            return RedirectToAction("MyProfilePage", "Account", user);
        }
        catch (InvalidOperationException)
        {
            return RedirectToAction("LogIn", "Account");
        }
    }

    public IActionResult MyProfilePage(User user)
    {
        return View(user);
    }

    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SignUp(User user)
    {
        int id = _userService.CreateUser(user);
        user = _userService.GetUser(id);
        return RedirectToAction("myProfilePage", user);
    }

    public IActionResult LogOut()
    {
       return View();
    }

    [HttpPost]
    public IActionResult LogOut(User user)
    {
        HttpContext.Session.Clear();
         return RedirectToAction("LogIn", "Account");
    }



}


