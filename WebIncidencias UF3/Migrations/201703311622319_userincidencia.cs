namespace WebIncidencias_UF3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userincidencia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incidencias", "UsuarioId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Incidencias", "UsuarioId");
            AddForeignKey("dbo.Incidencias", "UsuarioId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incidencias", "UsuarioId", "dbo.AspNetUsers");
            DropIndex("dbo.Incidencias", new[] { "UsuarioId" });
            DropColumn("dbo.Incidencias", "UsuarioId");
        }
    }
}
