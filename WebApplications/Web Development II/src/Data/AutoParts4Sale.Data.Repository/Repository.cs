namespace AutoParts4Sale.Data.Repositories
{
    public class Repository
    {
        internal ApplicationDbContext dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        public void SaveChangesAsync()
        {
            this.dbContext.SaveChangesAsync();
        }
    }
}
