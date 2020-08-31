using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLLCore.Repository;
using Microsoft.AspNetCore.Mvc;
using PieShopWeb.ViewModels;

namespace PieShopWeb.Controllers
{
    public class HomeController : Controller
    {
        private IPieRepository _pieRepository;
        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }
        
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                Title = "Welcome to Suzana's Pie Shop",
                Pies = _pieRepository.GetAllPies().ToList()
            };
            return View(homeViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if(pie == null)
            {
                return NotFound();
            }
            return View(pie);
        }
    }
}
