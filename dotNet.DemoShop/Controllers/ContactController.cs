using System;
using Microsoft.AspNetCore.Mvc;

namespace dotNet.DemoShop.Controllers
{
    
    public class ContactController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
    
}
