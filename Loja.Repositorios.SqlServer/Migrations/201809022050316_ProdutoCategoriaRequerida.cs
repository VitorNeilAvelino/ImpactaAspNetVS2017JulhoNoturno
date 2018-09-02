namespace Loja.Repositorios.SqlServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProdutoCategoriaRequerida : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produto", "Categoria_Id", "dbo.Categoria");
            DropIndex("dbo.Produto", new[] { "Categoria_Id" });
            AlterColumn("dbo.Produto", "Categoria_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Produto", "Categoria_Id");
            AddForeignKey("dbo.Produto", "Categoria_Id", "dbo.Categoria", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "Categoria_Id", "dbo.Categoria");
            DropIndex("dbo.Produto", new[] { "Categoria_Id" });
            AlterColumn("dbo.Produto", "Categoria_Id", c => c.Int());
            CreateIndex("dbo.Produto", "Categoria_Id");
            AddForeignKey("dbo.Produto", "Categoria_Id", "dbo.Categoria", "Id");
        }
    }
}
