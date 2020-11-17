using AspNetMvc_Fileupload_DropzoneJs.Models;
using System.Data.Entity;

namespace AspNetMvc_Fileupload_DropzoneJs.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DatabaseContext()
        {
            //Database.SetInitializer(new DatabaseInitializer());
        }
    }
}
