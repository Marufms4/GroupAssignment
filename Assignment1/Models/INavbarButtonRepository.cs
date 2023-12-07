namespace Assignment1.Models
{
    public interface INavbarButtonRepository
    {
        NavbarButton GetbyId(int id);
        IEnumerable<NavbarButton> AllButton();
        NavbarButton Add(NavbarButton button);
        NavbarButton Update(NavbarButton button);
        NavbarButton Delete(int id);
    }
}
