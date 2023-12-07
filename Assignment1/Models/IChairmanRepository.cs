namespace Assignment1.Models
{
    public interface IChairmanRepository
    {
        Chairman GetbyId(int id);
        IEnumerable<Chairman> AllChairman();
        Chairman Add(Chairman product);
        Chairman Update(Chairman product);
        Chairman Delete(int id);
    }
}
