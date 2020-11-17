namespace AspNetMvc_Fileupload_DropzoneJs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductPicture_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductPictures",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(nullable: false, maxLength: 80),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductPictures", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductPictures", new[] { "ProductId" });
            DropTable("dbo.ProductPictures");
        }
    }
}
