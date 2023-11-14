using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalago.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
                "Values('Coca-Cola Diet', 'Refrigerante de Cola 350 ml',5.30,'cocacola.jpg', 50, now(),7 )");
            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
                "Values('Lanche de Atum', 'Lanche de Atum com maionese',8.50,'atum.jpg', 10, now(),8 )");
            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
                "Values('Pudim 100g', 'Pudim de leite condensado 100g',6.99,'pudim.jpg', 50, now(),9 )");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produtos");
        }
    }
}
