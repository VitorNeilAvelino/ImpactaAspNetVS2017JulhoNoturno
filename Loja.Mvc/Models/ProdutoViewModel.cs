﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loja.Mvc.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int? CategoriaId { get; set; }
        //public Nullable<int> CategoriaId { get; set; }

        [Display(Name = "Categoria")]
        public string CategoriaNome { get; set; }

        public List<SelectListItem> Categorias { get; set; } = new List<SelectListItem>();

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public int Estoque { get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}