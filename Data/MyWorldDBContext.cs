using webappmssql.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace webappmssql.Data
{
    public class MyWorldDBContext: DbContext
    {
        //constructure
        public MyWorldDBContext(DbContextOptions<MyWorldDBContext> options) : base(options) // desendant from Entities
        {
            
        }

        public DbSet<Gadgets> Gadgets {get; set;}
    }
}