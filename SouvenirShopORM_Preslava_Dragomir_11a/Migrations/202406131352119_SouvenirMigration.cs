namespace SouvenirShopORM_Preslava_Dragomir_11a.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SouvenirMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Souvenirs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        SouvenirTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SouvenirTypes", t => t.SouvenirTypeId, cascadeDelete: true)
                .Index(t => t.SouvenirTypeId);
            
            CreateTable(
                "dbo.SouvenirTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Souvenirs", "SouvenirTypeId", "dbo.SouvenirTypes");
            DropIndex("dbo.Souvenirs", new[] { "SouvenirTypeId" });
            DropTable("dbo.SouvenirTypes");
            DropTable("dbo.Souvenirs");
        }
    }
}
