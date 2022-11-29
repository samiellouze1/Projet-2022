﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet_2022.Data;
using Projet_2022.Data.Static;
using Projet_2022.Models.Entities;
using Projet_2022.Views.ViewModels;
using System.Collections;
using System.Security.Claims;

namespace Projet_2022.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _usermanager;
        private readonly SignInManager<User> _signinmanager;
        private readonly AppDbContext _context;
        public AccountController(UserManager<User> usermanager,
            SignInManager<User> signinmanager,
            AppDbContext context)
        {
            _usermanager = usermanager;
            _signinmanager = signinmanager;
            _context = context;
        }
        public IActionResult Login()
        {
            var response = new LoginVM();

            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginvm)
        {
            if (!ModelState.IsValid)
            {
                return (View(loginvm));
            }
            var user = await _usermanager.FindByNameAsync(loginvm.Email);
            if (user != null)
            {
                var passwordCheck = await _usermanager.CheckPasswordAsync(user, loginvm.Password);
                if (passwordCheck)
                {
                    var result = await _signinmanager.PasswordSignInAsync(user, loginvm.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            TempData["Error"] = "Wrong! Try Again";
            return View(loginvm);
        }
        public IActionResult ClientLogin()
        {
            return View();
        }
        public IActionResult Register()
        {
            var response = new RegisterVM();

            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registervm)
        {
            if (!ModelState.IsValid)
            {
                return View(registervm);
            }
            Console.WriteLine(registervm.FirstName);
            var user = await _usermanager.FindByEmailAsync(registervm.Email);
            if (user != null)
            {
                TempData["Error"] = "This Email Adress has already been taken";
                return View(registervm);
            }
            var newUser = new User()
            {
                UserName=registervm.Email,
                FirstName = registervm.FirstName,
                LastName = registervm.LastName,
                Email = registervm.Email,
                City = registervm.City,
                Zipcode = registervm.Zipcode,
                Phone= registervm.Phone,
            };
            var newUserResponse = await _usermanager.CreateAsync(newUser, registervm.Password);
            if (newUserResponse.Succeeded)
            {
                await _usermanager.AddToRoleAsync(newUser, UserRoles.Client);
                var result = await _signinmanager.PasswordSignInAsync(newUser, registervm.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(registervm);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signinmanager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> MyOrders(string Id)
        {
                var user = await _usermanager.GetUserAsync(HttpContext.User);
                return View(user.Orders);
        }

    }
}