namespace Persistence.DatabaseContext.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Modelousuariomodificado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Nombre", c => c.String());
            AddColumn("dbo.AspNetUsers", "Apellido", c => c.String());
            AddColumn("dbo.AspNetUsers", "Rol", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Rol");
            DropColumn("dbo.AspNetUsers", "Apellido");
            DropColumn("dbo.AspNetUsers", "Nombre");
        }
    }
}
