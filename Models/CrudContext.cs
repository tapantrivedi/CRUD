
using Microsoft.EntityFrameworkCore;

namespace CRUD.Models
{
    public class CrudContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public DbSet<Dish> Dish{ get; set; }
        public CrudContext(DbContextOptions<CrudContext> options) : base(options) { }
    }
}