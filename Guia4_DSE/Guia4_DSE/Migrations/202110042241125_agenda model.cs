namespace Guia4_DSE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agendamodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.contactoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        apellido = c.String(),
                        celular = c.Int(nullable: false),
                        telefono = c.Int(nullable: false),
                        correo = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.contactoes");
        }
    }
}
