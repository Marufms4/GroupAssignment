namespace Assignment1.Models
{
    public class SQLLoginButtonPosition : ILoginButtonPosition
    {
        private readonly AppDbContext appDbContext;

        public SQLLoginButtonPosition(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public LoginButtonPosition GetbyId(int id)
        {
            return appDbContext.loginButtonPosition.Find(id);
        }

        public LoginButtonPosition Update(LoginButtonPosition button)
        {
            var btn = appDbContext.loginButtonPosition.Attach(button);
            btn.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            appDbContext.SaveChanges();
            return button;
        }
    }
}
