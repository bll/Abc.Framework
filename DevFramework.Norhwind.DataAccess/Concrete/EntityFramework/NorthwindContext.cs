using DevFramework.Norhwind.DataAccess.Concrete.EntityFramework.Mappings;
using DevFramework.Norhwind.Entities.Concrete;
using System.Data.Entity;

namespace DevFramework.Norhwind.DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
            Database.SetInitializer<NorthwindContext>(null);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());


        }
    }
}
