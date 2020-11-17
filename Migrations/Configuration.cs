using AspNetMvc_Fileupload_DropzoneJs.Context;
using System.Data.Entity.Migrations;

namespace AspNetMvc_Fileupload_DropzoneJs.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
         
        }

        protected override void Seed(DatabaseContext context)
        {
            DatabaseInitializer.InsertSeedData(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
