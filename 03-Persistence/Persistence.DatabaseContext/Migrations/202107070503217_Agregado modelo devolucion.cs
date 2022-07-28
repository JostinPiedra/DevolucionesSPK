namespace Persistence.DatabaseContext.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Agregadomodelodevolucion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
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
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Devoluciones");
        }
    }
}
