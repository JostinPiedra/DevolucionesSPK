namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class modeloformulariosolicitud : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Solicitudes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaSolicitud = c.DateTime(),
                        Cantidad = c.String(),
                        Producto = c.String(),
                        MotivoSolicitud = c.String(),
                        Factura = c.String(),
                        FechaFactura = c.DateTime(),
                        Observacion = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Solicitudes_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Solicitudes", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Solicitudes", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Solicitudes", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Solicitudes", new[] { "DeletedBy" });
            DropIndex("dbo.Solicitudes", new[] { "UpdatedBy" });
            DropIndex("dbo.Solicitudes", new[] { "CreatedBy" });
            DropTable("dbo.Solicitudes",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Solicitudes_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
