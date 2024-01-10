using AppBayTask.Business.Services.Interfaces;
using AppBayTask.Business.ViewModels;
using AppBayTask.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppBayTask.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFeatureService _service;

        public HomeController(IFeatureService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Feature> features = await _service.FeatureGetAllAsync();

            return View(features);
        }
    }
}
