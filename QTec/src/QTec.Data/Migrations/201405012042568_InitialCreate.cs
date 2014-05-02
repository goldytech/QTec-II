namespace QTec.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeLanguages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        Fluency = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        DesignationId = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Salary = c.Double(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DesignationId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.LanguageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeLanguages", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.EmployeeLanguages", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            DropIndex("dbo.EmployeeLanguages", new[] { "LanguageId" });
            DropIndex("dbo.EmployeeLanguages", new[] { "EmployeeId" });
            DropTable("dbo.Languages");
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeLanguages");
            DropTable("dbo.Designations");
        }
    }
}
