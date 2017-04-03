namespace WebIncidencias_UF3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fechacierrenull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Incidencias", "FechaCierre", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Incidencias", "FechaCierre", c => c.DateTime(nullable: false));
        }
    }
}
