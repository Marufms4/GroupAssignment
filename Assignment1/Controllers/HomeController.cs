using Assignment1.Models;
using Assignment1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assignment1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IChairmanRepository chairmanRepository;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public HomeController(ILogger<HomeController> logger,
            IChairmanRepository chairmanRepository,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            this.chairmanRepository = chairmanRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var chairmen = chairmanRepository.AllChairman();
            return View(chairmen);
        }

        [HttpGet]
        public IActionResult Edit (int Id)
        {
            Chairman chairman = chairmanRepository.GetbyId(Id);
            if (chairman == null)
            {
                return View("NotFound");
            }
            EditViewModel viewModel = new EditViewModel()
            {
                Id = Id,
                Description = chairman.Description,
                ExistingPhotoPath = chairman.PhotoPath,
                Goal = chairman.Goal,
                Mission = chairman.Mission,
                Vision = chairman.Vision,
                Values = chairman.Values,
                IsGoalSelected = chairman.IsGoalSelected,
                IsMissionSelected = chairman.IsMissionSelected,
                IsValuesSelected = chairman.IsValuesSelected,
                IsVisionSelected = chairman.IsVisionSelected,
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit (EditViewModel model)
        {
            if (ModelState.IsValid)
            {

                Chairman chairman = chairmanRepository.GetbyId(model.Id);
                chairman.Description = model.Description;
                chairman.Mission = model.Mission;
                chairman.Vision = model.Vision;
                chairman.Values = model.Values;
                chairman.Goal = model.Goal;
                chairman.IsGoalSelected = model.IsGoalSelected;
                chairman.IsMissionSelected = model.IsMissionSelected;
                chairman.IsVisionSelected = model.IsVisionSelected;
                chairman.IsValuesSelected = model.IsValuesSelected;

               

                if (model.Photo != null)
                {
                    if (chairman.PhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", chairman.PhotoPath);
                        System.IO.File.Delete(filePath);

                    }
                    chairman.PhotoPath = ProcessUploadedFile(model);
                }
                chairmanRepository.Update(chairman);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        

        private string ProcessUploadedFile(EditViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

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
}
