using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    //Important to connect to DB
    public class DataContext : DbContext
    {
        //Constructor
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        //Table in the DB with prop name activities
        public DbSet<Activity> Activities { get; set; }
    }
}