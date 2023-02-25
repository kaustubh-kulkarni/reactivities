using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class DataContext : DbContext
    {
        //Need to pass options, here the connection string
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        //A prop of type DbSet<Model name> and name of the table that needs to be created in DB
        public DbSet<Activity> Activities { get; set; }
    }
}