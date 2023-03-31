using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GoldenGames.Models;

namespace GoldenGames.Areas.Admin.ViewModels
{
    /*Não posso acrescentar a imagem a este modelo de dados, porque ao criar um novo 
     jogo utilizo este modelo de dados para transportar a informação.
    E o que acontece é que ao entrar na função create o parâmetro image não vem populado
    é populado posteriormente então isso lixa o meu modelstate, porque pelos vistos este é 
    pre-validado quando entras na função. E para ele ser válido todos os valores da class
    precisam de estar populados*/
    public class JogoViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(60, ErrorMessage = "Limite máximo é 60 carateres")]
        [Display(Name = "Título do Jogo")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Preço do Jogo")]
        public decimal? Preco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(500)]
        [Display(Name = "Descrição do Jogo")]
        public string? Descricao { get; set; }

        [Display(Name = "Categoria")]
        public int? IdCategoria { get; set; }

        [Display(Name = "Consola")]
        public int? IdConsola { get; set; }


        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(60, ErrorMessage = "Limite máximo é 60 carateres")]
        [Display(Name = "Produtora")]
        public string? Produtora { get; set; }
    }
}
