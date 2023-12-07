
using System;

namespace Assignment1.Models
{
    public class SQLChairman : IChairmanRepository
    {
        private readonly AppDbContext appDbContext;

        public SQLChairman( AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public Chairman Add(Chairman chairman)
        {
            appDbContext.chairmen.Add(chairman);
            appDbContext.SaveChanges();
            return chairman;
        }

        public IEnumerable<Chairman> AllChairman()
        {
            return appDbContext.chairmen;
        }

        public Chairman Delete(int id)
        {
            Chairman chairman = appDbContext.chairmen.Find(id);
            if (chairman != null)
            {
                appDbContext.chairmen.Remove(chairman);
                appDbContext.SaveChanges();
            }
            return chairman;
        }

        public Chairman GetbyId(int id)
        {
            return appDbContext.chairmen.Find(id);
        }

        public Chairman Update(Chairman chairman)
        {
            var Chairman = appDbContext.chairmen.Attach(chairman);
            Chairman.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            appDbContext.SaveChanges();
            return chairman;
        }
    }
}
