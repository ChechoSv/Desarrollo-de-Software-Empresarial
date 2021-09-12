namespace MVC_Biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracionLibro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.libro",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        titulo = c.String(maxLength: 100),
                        autor = c.String(maxLength: 100),
                        isbn = c.Int(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        ejemplares = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.libro");
        }
    }
}
