namespace Persistence.DatabaseContext.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Agregadomodeloclientes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nombre = c.String(),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Clientes");
        }
    }
}
