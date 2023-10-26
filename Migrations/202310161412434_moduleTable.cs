namespace wpfwdb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moduleTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        ModuleId = c.Int(nullable: false, identity: true),
                        ModuleCode = c.String(),
                        ModuleName = c.String(),
                        Credits = c.Int(nullable: false),
                        ClassHours = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Modules");
        }
    }
}
