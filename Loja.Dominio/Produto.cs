namespace Loja.Dominio
{
    //[ToTable("tbProduto")]
    public class Produto
    {
        public int Id { get; set; }

        //[Required]
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public bool Ativo { get; set; } = true;
        public string QRCode { get; set; }

        public Categoria Categoria { get; set; }
    }
}