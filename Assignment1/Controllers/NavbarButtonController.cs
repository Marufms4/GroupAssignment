using Assignment1.Models;
using Assignment1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    public class NavbarButtonController : Controller
    {
        private readonly INavbarButtonRepository navbarButtonRepository;
        private readonly AppDbContext appDbContext;
        private readonly ILoginButtonPosition loginButtonPosition;

        public NavbarButtonController(INavbarButtonRepository navbarButtonRepository, AppDbContext appDbContext, ILoginButtonPosition loginButtonPosition)
        {
            this.navbarButtonRepository = navbarButtonRepository;
            this.appDbContext = appDbContext;
            this.loginButtonPosition = loginButtonPosition;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateNavbarButtonViewModel model)
        {
            if (ModelState.IsValid)
            {
                NavbarButton button = new NavbarButton()
                {
                    ButtonName = model.ButtonName,
                    Url = model.Url,
                    IsSelected = false
                };
                navbarButtonRepository.Add(button);
                return RedirectToAction("EditNavbar");
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditButton(int id)
        {
            var button = navbarButtonRepository.GetbyId(id);
            var model = new EditNavButtonViewModel();
            if (button != null)
            {
                model.Id = button.Id;
                model.ButtonName = button.ButtonName;
                model.Url = button.Url;
            }
            return View(model); 
        }

        [HttpPost]
        public IActionResult EditButton(EditNavButtonViewModel model)
        {
            var button = navbarButtonRepository.GetbyId(model.Id);
            button.ButtonName = model.ButtonName;
            button.Url = model.Url;
            navbarButtonRepository.Update(button);
            return RedirectToAction("EditNavbar");
        }

        public IActionResult DeleteButton(int id)
        {
            navbarButtonRepository.Delete(id);
            return RedirectToAction("EditNavbar");
        }

        [HttpGet]
        public IActionResult EditNavbar()
        {
            var model = new List<EditNavbarViewModel>();
            foreach(var button in navbarButtonRepository.AllButton())
            {
                var editNavbarViewModel = new EditNavbarViewModel()
                {
                    id = button.Id,
                    buton = button.ButtonName,
                    IsSelected = button.IsSelected,
                };
                model.Add(editNavbarViewModel);
            }
            return View(model);
            //var button = navbarButtonRepository.AllButton();
            //return View(button);
        }

        [HttpPost]
        public IActionResult EditNavbar(List<EditNavbarViewModel> models)
        {
            if (ModelState.IsValid)
            {
                foreach(var button in models)
                {
                    var btn = navbarButtonRepository.GetbyId(button.id);
                    if (btn != null)
                    {
                        btn.ButtonName = button.buton.ToString();
                        btn.IsSelected = button.IsSelected;
                    }
                    navbarButtonRepository.Update(btn);
                }
                return RedirectToAction("Index", "Home");
            }
            return View(models);
        }

        [HttpGet]
        public IActionResult UpdateButtonOrder()
        {
            var Buttons = navbarButtonRepository.AllButton();
            var editButtonOrder = new List<EditButtonOrder>();
            foreach (var button in Buttons.OrderBy(c=> c.Order))
            {
                var btn = new EditButtonOrder()
                {
                    Id = button.Id,
                    ButtonName = button.ButtonName,
                    Order = button.Order
                };
                editButtonOrder.Add(btn);
            }
            return View(editButtonOrder);
        }

        [HttpPost]
        public IActionResult UpdateButtonOrder(List<EditButtonOrder> navbarButton)
        {
            
                foreach(var button in navbarButton)
                {
                    var btn = navbarButtonRepository.GetbyId(button.Id);
                    if (btn != null)
                    {
                        btn.Order = button.Order;
                    }
                    navbarButtonRepository.Update(btn);
                    
                }
                return RedirectToAction("Index", "Home");
            
        }

        [HttpGet]
        public IActionResult CreateNavbarButtonPosition()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNavbarButtonPosition(LoginButtonPosition button)
        {
            LoginButtonPosition btn = new LoginButtonPosition()
            {
                Id = button.Id
            };
            if(button.Position == "Right")
            {
                btn.Position = "ml-auto";
            }
            btn.Position = "";
            appDbContext.loginButtonPosition.Add(btn);
            appDbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult EditNavbarButtonPosition(int Id)
        {
            var btn = loginButtonPosition.GetbyId(Id);
            return View(btn);
        }

        [HttpPost]
        public IActionResult EditNavbarButtonPosition(LoginButtonPosition button)
        {
            var btn = loginButtonPosition.GetbyId(button.Id);
            if(button.Position == "Right")
            {
                btn.Position = "ml-auto";
            }
            else
            {
                btn.Position = null;
            }
            
            loginButtonPosition.Update(btn);
            return RedirectToAction("Index", "Home");
        }

    }
}
