namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AggEntidadCRUDalmodeloDevolucion : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
                "dbo.Devoluciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaIngreso = c.DateTime(),
                        Cantidad = c.String(),
                        Producto = c.String(),
                        MotivoDevolucion = c.String(),
                        Factura = c.String(),
                        FechaFactura = c.DateTime(),
                        ResponsableRecepcion = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Devoluciones_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AddColumn("dbo.Devoluciones", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Devoluciones", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Devoluciones", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Devoluciones", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Devoluciones", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Devoluciones", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Devoluciones", "DeletedBy", c => c.String(maxLength: 128));
            CreateIndex("dbo.Devoluciones", "CreatedBy");
            CreateIndex("dbo.Devoluciones", "UpdatedBy");
            CreateIndex("dbo.Devoluciones", "DeletedBy");
            AddForeignKey("dbo.Devoluciones", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Devoluciones", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Devoluciones", "UpdatedBy", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Devoluciones", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Devoluciones", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Devoluciones", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Devoluciones", new[] { "DeletedBy" });
            DropIndex("dbo.Devoluciones", new[] { "UpdatedBy" });
            DropIndex("dbo.Devoluciones", new[] { "CreatedBy" });
            DropColumn("dbo.Devoluciones", "DeletedBy");
            DropColumn("dbo.Devoluciones", "DeletedAt");
            DropColumn("dbo.Devoluciones", "UpdatedBy");
            DropColumn("dbo.Devoluciones", "UpdatedAt");
            DropColumn("dbo.Devoluciones", "CreatedBy");
            DropColumn("dbo.Devoluciones", "CreatedAt");
            DropColumn("dbo.Devoluciones", "Deleted");
            AlterTableAnnotations(
                "dbo.Devoluciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaIngreso = c.DateTime(),
                        Cantidad = c.String(),
                        Producto = c.String(),
                        MotivoDevolucion = c.String(),
                        Factura = c.String(),
                        FechaFactura = c.DateTime(),
                        ResponsableRecepcion = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Devoluciones_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
        }
    }
}
