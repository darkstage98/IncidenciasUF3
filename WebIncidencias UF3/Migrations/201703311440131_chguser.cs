namespace WebIncidencias_UF3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chguser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Nombre", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastAcc", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "LastAcc");
            DropColumn("dbo.AspNetUsers", "Nombre");
        }
    }
}
