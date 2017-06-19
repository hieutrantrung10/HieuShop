namespace HieuShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Footers",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MenuGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        URL = c.String(nullable: false),
                        DisplayOrder = c.Int(),
                        GroupID = c.Int(nullable: false),
                        Target = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MenuGroups", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderID, t.ProductID })
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 256),
                        CustomerAddress = c.String(nullable: false, maxLength: 256),
                        CustomerEmail = c.String(nullable: false, maxLength: 256),
                        CustomerMobile = c.String(nullable: false, maxLength: 50),
                        CustomerMessage = c.String(maxLength: 256),
                        PaymentMethod = c.String(nullable: false, maxLength: 256),
                        PaymentStatus = c.String(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        MetaDescription = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256, unicode: false),
                        CategoryID = c.Int(nullable: false),
                        Image = c.String(maxLength: 256),
                        MoreImages = c.String(storeType: "xml"),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PromotionPrice = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Warranty = c.Int(),
                        Description = c.String(),
                        Content = c.String(),
                        HomeFlag = c.Boolean(),
                        HotFlag = c.Boolean(),
                        ViewCount = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        MetaDescription = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductCategories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Alias = c.String(nullable: false),
                        Description = c.String(),
                        ParentID = c.Int(),
                        DisplayOrder = c.Int(),
                        Image = c.String(),
                        HomeFlag = c.Boolean(),
                        CreatedBy = c.String(maxLength: 256),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        MetaDescription = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                        Alias = c.String(maxLength: 256, unicode: false),
                        Content = c.String(),
                        CreatedBy = c.String(maxLength: 256),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        MetaDescription = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PostCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                        Alias = c.String(),
                        ParentID = c.Int(),
                        DisplayOrder = c.Int(),
                        Image = c.String(),
                        HomeFlag = c.Boolean(),
                        CreatedBy = c.String(maxLength: 256),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        MetaDescription = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                        Alias = c.String(maxLength: 256, unicode: false),
                        PostCategoryID = c.Int(nullable: false),
                        HomeFlag = c.Boolean(),
                        HotFlag = c.Boolean(),
                        ViewCount = c.Int(nullable: false),
                        Description = c.String(),
                        Content = c.String(),
                        CreatedBy = c.String(maxLength: 256),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        MetaDescription = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PostCategories", t => t.PostCategoryID, cascadeDelete: true)
                .Index(t => t.PostCategoryID);
            
            CreateTable(
                "dbo.PostTags",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ProductID, t.TagID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductTags",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ProductID, t.TagID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.Slides",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                        Image = c.String(),
                        URL = c.String(),
                        DisplayOrder = c.Int(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SupportOnlines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContactFacebook = c.String(),
                        ContactSkype = c.String(),
                        ContactEmail = c.String(),
                        ContactMobile = c.String(),
                        Status = c.Boolean(nullable: false),
                        Department = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SystemConfigs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        ValueString = c.String(),
                        ValueInt = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VisitorStatistics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VisitedDate = c.DateTime(nullable: false),
                        IPAddress = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.ProductTags", "ProductID", "dbo.Products");
            DropForeignKey("dbo.PostTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.PostTags", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Posts", "PostCategoryID", "dbo.PostCategories");
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.ProductCategories");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Menus", "GroupID", "dbo.MenuGroups");
            DropIndex("dbo.ProductTags", new[] { "TagID" });
            DropIndex("dbo.ProductTags", new[] { "ProductID" });
            DropIndex("dbo.PostTags", new[] { "TagID" });
            DropIndex("dbo.PostTags", new[] { "ProductID" });
            DropIndex("dbo.Posts", new[] { "PostCategoryID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Menus", new[] { "GroupID" });
            DropTable("dbo.VisitorStatistics");
            DropTable("dbo.SystemConfigs");
            DropTable("dbo.SupportOnlines");
            DropTable("dbo.Slides");
            DropTable("dbo.ProductTags");
            DropTable("dbo.Tags");
            DropTable("dbo.PostTags");
            DropTable("dbo.Posts");
            DropTable("dbo.PostCategories");
            DropTable("dbo.Pages");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Menus");
            DropTable("dbo.MenuGroups");
            DropTable("dbo.Footers");
        }
    }
}
