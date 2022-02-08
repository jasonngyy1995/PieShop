using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNet.DemoShop.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotNet.DemoShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieReopository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieReopository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List()
        {
            return View(_pieReopository.AllPies);
        }
    }
}
