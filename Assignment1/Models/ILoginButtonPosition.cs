using Microsoft.AspNetCore.Authorization;

namespace Assignment1.Models
{
    public interface ILoginButtonPosition
    {
        LoginButtonPosition GetbyId(int id);
        LoginButtonPosition Update(LoginButtonPosition button);
    }
}
