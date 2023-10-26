namespace wpfwdb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class semesterTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        SemesterId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Weeks = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SemesterId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Semesters");
        }
    }
}
