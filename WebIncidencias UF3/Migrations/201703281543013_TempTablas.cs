namespace WebIncidencias_UF3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TempTablas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dispositivos",
                c => new
                    {
                        MAC = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                        DistribuidorId = c.Int(nullable: false),
                        FechaAdquisicion = c.DateTime(nullable: false),
                        Garantia = c.DateTime(nullable: false),
                        Averias = c.String(),
                        Reparacion = c.String(),
                    })
                .PrimaryKey(t => t.MAC)
                .ForeignKey("dbo.Distribuidores", t => t.DistribuidorId, cascadeDelete: true)
                .Index(t => t.DistribuidorId);
            
            CreateTable(
                "dbo.Distribuidores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Telefono = c.String(),
                        Direccion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Incidencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DispositivoId = c.String(maxLength: 128),
                        TipoIncidenciaId = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaCierre = c.DateTime(nullable: false),
                        Descripion = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dispositivos", t => t.DispositivoId)
                .ForeignKey("dbo.TiposIncidencias", t => t.TipoIncidenciaId, cascadeDelete: true)
                .Index(t => t.DispositivoId)
                .Index(t => t.TipoIncidenciaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incidencias", "TipoIncidenciaId", "dbo.TiposIncidencias");
            DropForeignKey("dbo.Incidencias", "DispositivoId", "dbo.Dispositivos");
            DropForeignKey("dbo.Dispositivos", "DistribuidorId", "dbo.Distribuidores");
            DropIndex("dbo.Incidencias", new[] { "TipoIncidenciaId" });
            DropIndex("dbo.Incidencias", new[] { "DispositivoId" });
            DropIndex("dbo.Dispositivos", new[] { "DistribuidorId" });
            DropTable("dbo.Incidencias");
            DropTable("dbo.Distribuidores");
            DropTable("dbo.Dispositivos");
        }
    }
}
