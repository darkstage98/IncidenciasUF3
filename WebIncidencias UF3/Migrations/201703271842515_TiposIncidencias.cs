namespace WebIncidencias_UF3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TiposIncidencias : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TiposIncidencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TiposIncidencias");
        }
    }
}
