﻿namespace Loja.Dominio
{
    //[ToTable("tbProduto")]
    public class Produto
    {
        public int Id { get; set; }

        //[Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public bool Ativo { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}