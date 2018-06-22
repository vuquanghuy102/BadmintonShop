namespace Badminton_Sport.Models
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BILL_DETAIL",
                c => new
                    {
                        BILL_ID = c.String(nullable: false, maxLength: 10, unicode: false),
                        PRODUCT_ID = c.String(nullable: false, maxLength: 10, unicode: false),
                        QUANTITY = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BILL_ID, t.PRODUCT_ID })
                .ForeignKey("dbo.BILL", t => t.BILL_ID)
                .ForeignKey("dbo.PRODUCT", t => t.PRODUCT_ID)
                .Index(t => t.BILL_ID)
                .Index(t => t.PRODUCT_ID);
            
            CreateTable(
                "dbo.BILL",
                c => new
                    {
                        BILL_ID = c.String(nullable: false, maxLength: 10, unicode: false),
                        USER_ID = c.String(maxLength: 10, unicode: false),
                        DATE_BUY = c.DateTime(nullable: false, storeType: "date"),
                        APPROVAL_ADMIN = c.String(maxLength: 10, unicode: false),
                        TOTAL = c.Double(nullable: false),
                        STT = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BILL_ID)
                .ForeignKey("dbo.USERS", t => t.APPROVAL_ADMIN)
                .ForeignKey("dbo.USERS", t => t.USER_ID)
                .Index(t => t.USER_ID)
                .Index(t => t.APPROVAL_ADMIN);
            
            CreateTable(
                "dbo.USERS",
                c => new
                    {
                        USER_ID = c.String(nullable: false, maxLength: 10, unicode: false),
                        USERNAME = c.String(nullable: false, maxLength: 50),
                        FULLNAME = c.String(nullable: false, maxLength: 50),
                        PASSWORD = c.String(nullable: false, maxLength: 5, unicode: false),
                        EMAIL = c.String(nullable: false, maxLength: 50, unicode: false),
                        AVARTA = c.String(maxLength: 257),
                        ISADMIN = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.USER_ID);
            
            CreateTable(
                "dbo.CATEGORY",
                c => new
                    {
                        CATEGORY_ID = c.String(nullable: false, maxLength: 10, unicode: false),
                        CATEGORY_NAME = c.String(nullable: false, maxLength: 50),
                        USER_ID = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.CATEGORY_ID)
                .ForeignKey("dbo.USERS", t => t.USER_ID)
                .Index(t => t.USER_ID);
            
            CreateTable(
                "dbo.PRODUCE",
                c => new
                    {
                        PRODUCE_ID = c.String(nullable: false, maxLength: 10, unicode: false),
                        PRODUCE_NAME = c.String(nullable: false, maxLength: 50),
                        DESCRIPTIONS = c.String(maxLength: 300),
                        USER_ID = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.PRODUCE_ID)
                .ForeignKey("dbo.USERS", t => t.USER_ID)
                .Index(t => t.USER_ID);
            
            CreateTable(
                "dbo.PRODUCT",
                c => new
                    {
                        PRODUCT_ID = c.String(nullable: false, maxLength: 10, unicode: false),
                        PRODUCT_NAME = c.String(nullable: false, maxLength: 50),
                        SIZE = c.Int(),
                        PRICE = c.Double(nullable: false),
                        NUMBERSOLD = c.Int(),
                        EXISTENCE = c.Int(),
                        IMAGES = c.String(maxLength: 257, unicode: false),
                        DESCRIPSION = c.String(maxLength: 500),
                        VISIABLE = c.Boolean(),
                        ISNEW = c.Boolean(),
                        SALEID = c.String(maxLength: 10, unicode: false),
                        PRODUCE_ID = c.String(maxLength: 10, unicode: false),
                        CATEGORY_ID = c.String(maxLength: 10, unicode: false),
                        USER_ID = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.PRODUCT_ID)
                .ForeignKey("dbo.CATEGORY", t => t.CATEGORY_ID)
                .ForeignKey("dbo.PRODUCE", t => t.PRODUCE_ID)
                .ForeignKey("dbo.SALE", t => t.SALEID)
                .ForeignKey("dbo.USERS", t => t.USER_ID)
                .Index(t => t.SALEID)
                .Index(t => t.PRODUCE_ID)
                .Index(t => t.CATEGORY_ID)
                .Index(t => t.USER_ID);
            
            CreateTable(
                "dbo.FEEDBACK",
                c => new
                    {
                        USER_ID = c.String(nullable: false, maxLength: 10, unicode: false),
                        PRODUCT_ID = c.String(nullable: false, maxLength: 10, unicode: false),
                        NUMBER_STAR = c.Int(nullable: false),
                        COMMENT = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => new { t.USER_ID, t.PRODUCT_ID })
                .ForeignKey("dbo.PRODUCT", t => t.PRODUCT_ID)
                .ForeignKey("dbo.USERS", t => t.USER_ID)
                .Index(t => t.USER_ID)
                .Index(t => t.PRODUCT_ID);
            
            CreateTable(
                "dbo.SALE",
                c => new
                    {
                        SALE_ID = c.String(nullable: false, maxLength: 10, unicode: false),
                        SALE_NAME = c.String(nullable: false, maxLength: 50),
                        DESCRIPSION = c.String(maxLength: 500),
                        SALE_PRICENT = c.Int(),
                        USER_ID = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.SALE_ID)
                .ForeignKey("dbo.USERS", t => t.USER_ID)
                .Index(t => t.USER_ID);
            
            CreateTable(
                "dbo.BUSINESS",
                c => new
                    {
                        BUSINESS_ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        BUSINESS_NAME = c.String(nullable: false, maxLength: 80),
                        DESCRIPTIONS = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.BUSINESS_ID);
            
            CreateTable(
                "dbo.PERMISSION",
                c => new
                    {
                        PERMISSION_ID = c.String(nullable: false, maxLength: 10, unicode: false),
                        PERMISSION_NAME = c.String(nullable: false, maxLength: 50),
                        DESCRIPTIONS = c.String(maxLength: 300),
                        BUSINESS_ID = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.PERMISSION_ID)
                .ForeignKey("dbo.BUSINESS", t => t.BUSINESS_ID)
                .Index(t => t.BUSINESS_ID);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.CATEGORY_PRODUCE",
                c => new
                    {
                        CATEGORY_ID = c.String(nullable: false, maxLength: 10, unicode: false),
                        PRODUCE_ID = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => new { t.CATEGORY_ID, t.PRODUCE_ID })
                .ForeignKey("dbo.CATEGORY", t => t.CATEGORY_ID, cascadeDelete: true)
                .ForeignKey("dbo.PRODUCE", t => t.PRODUCE_ID, cascadeDelete: true)
                .Index(t => t.CATEGORY_ID)
                .Index(t => t.PRODUCE_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PERMISSION", "BUSINESS_ID", "dbo.BUSINESS");
            DropForeignKey("dbo.FEEDBACK", "USER_ID", "dbo.USERS");
            DropForeignKey("dbo.CATEGORY", "USER_ID", "dbo.USERS");
            DropForeignKey("dbo.CATEGORY_PRODUCE", "PRODUCE_ID", "dbo.PRODUCE");
            DropForeignKey("dbo.CATEGORY_PRODUCE", "CATEGORY_ID", "dbo.CATEGORY");
            DropForeignKey("dbo.PRODUCE", "USER_ID", "dbo.USERS");
            DropForeignKey("dbo.PRODUCT", "USER_ID", "dbo.USERS");
            DropForeignKey("dbo.SALE", "USER_ID", "dbo.USERS");
            DropForeignKey("dbo.PRODUCT", "SALEID", "dbo.SALE");
            DropForeignKey("dbo.PRODUCT", "PRODUCE_ID", "dbo.PRODUCE");
            DropForeignKey("dbo.FEEDBACK", "PRODUCT_ID", "dbo.PRODUCT");
            DropForeignKey("dbo.PRODUCT", "CATEGORY_ID", "dbo.CATEGORY");
            DropForeignKey("dbo.BILL_DETAIL", "PRODUCT_ID", "dbo.PRODUCT");
            DropForeignKey("dbo.BILL", "USER_ID", "dbo.USERS");
            DropForeignKey("dbo.BILL", "APPROVAL_ADMIN", "dbo.USERS");
            DropForeignKey("dbo.BILL_DETAIL", "BILL_ID", "dbo.BILL");
            DropIndex("dbo.CATEGORY_PRODUCE", new[] { "PRODUCE_ID" });
            DropIndex("dbo.CATEGORY_PRODUCE", new[] { "CATEGORY_ID" });
            DropIndex("dbo.PERMISSION", new[] { "BUSINESS_ID" });
            DropIndex("dbo.SALE", new[] { "USER_ID" });
            DropIndex("dbo.FEEDBACK", new[] { "PRODUCT_ID" });
            DropIndex("dbo.FEEDBACK", new[] { "USER_ID" });
            DropIndex("dbo.PRODUCT", new[] { "USER_ID" });
            DropIndex("dbo.PRODUCT", new[] { "CATEGORY_ID" });
            DropIndex("dbo.PRODUCT", new[] { "PRODUCE_ID" });
            DropIndex("dbo.PRODUCT", new[] { "SALEID" });
            DropIndex("dbo.PRODUCE", new[] { "USER_ID" });
            DropIndex("dbo.CATEGORY", new[] { "USER_ID" });
            DropIndex("dbo.BILL", new[] { "APPROVAL_ADMIN" });
            DropIndex("dbo.BILL", new[] { "USER_ID" });
            DropIndex("dbo.BILL_DETAIL", new[] { "PRODUCT_ID" });
            DropIndex("dbo.BILL_DETAIL", new[] { "BILL_ID" });
            DropTable("dbo.CATEGORY_PRODUCE");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.PERMISSION");
            DropTable("dbo.BUSINESS");
            DropTable("dbo.SALE");
            DropTable("dbo.FEEDBACK");
            DropTable("dbo.PRODUCT");
            DropTable("dbo.PRODUCE");
            DropTable("dbo.CATEGORY");
            DropTable("dbo.USERS");
            DropTable("dbo.BILL");
            DropTable("dbo.BILL_DETAIL");
        }
    }
}
