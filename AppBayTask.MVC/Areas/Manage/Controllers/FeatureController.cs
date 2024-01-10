using AppBayTask.Business.Services.Interfaces;
using AppBayTask.Business.ViewModels;
using AppBayTask.Core.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppBayTask.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Feature> feature = await _featureService.FeatureGetAllAsync();

            return View(feature);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(FeatureCreateVm featureVm)
        {
            if (!ModelState.IsValid)
            {
                return View(featureVm);
            }

            await _featureService.CreateAsync(featureVm);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id)
        {
            Feature feature = await _featureService.FeatureGetAsync(id);
            FeatureUpdateVm featureVm = _mapper.Map<FeatureUpdateVm>(feature);

            return View(featureVm);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Update(FeatureUpdateVm featureVm)
        {
            if (!ModelState.IsValid)
            {
                return View(featureVm);
            }

            await _featureService.UpdateAsync(featureVm);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _featureService.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
