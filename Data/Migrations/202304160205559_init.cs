namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Status = c.String(),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        theRole_Id = c.Int(),
                        theUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.theRole_Id)
                .ForeignKey("dbo.Users", t => t.theUser_Id)
                .Index(t => t.theRole_Id)
                .Index(t => t.theUser_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        UserName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "theUser_Id", "dbo.Users");
            DropForeignKey("dbo.Projects", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "theRole_Id", "dbo.Roles");
            DropForeignKey("dbo.Tasks", "Project_Id", "dbo.Projects");
            DropIndex("dbo.UserRoles", new[] { "theUser_Id" });
            DropIndex("dbo.UserRoles", new[] { "theRole_Id" });
            DropIndex("dbo.Tasks", new[] { "Project_Id" });
            DropIndex("dbo.Projects", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.Tasks");
            DropTable("dbo.Projects");
        }
    }
}
