
namespace Assignment1.Models
{
    public class SQLNavbarButton : INavbarButtonRepository
    {
        private readonly AppDbContext appDbContext;

        public SQLNavbarButton(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public NavbarButton Add(NavbarButton button)
        {
            appDbContext.navbarButton.Add(button);
            appDbContext.SaveChanges();
            return button;
        }

        public IEnumerable<NavbarButton> AllButton()
        {
            return appDbContext.navbarButton;
        }

        public NavbarButton Delete(int id)
        {
            NavbarButton button = appDbContext.navbarButton.Find(id);
            if (button != null)
            {
                appDbContext.navbarButton.Remove(button);
                appDbContext.SaveChanges();
            }
            return button;
        }

        public NavbarButton GetbyId(int id)
        {
            return appDbContext.navbarButton.Find(id);
            
        }

        public NavbarButton Update(NavbarButton button)
        {
            var Button = appDbContext.navbarButton.Attach(button);
            Button.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            appDbContext.SaveChanges();
            return button;
        }
    }
}
