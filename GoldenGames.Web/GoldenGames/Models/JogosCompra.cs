using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoldenGames.Models
{
    [Table("Jogos_Compra")]
    public partial class JogosCompra
    {
        [Key]
        public int Id { get; set; }
        [Column("Id_Jogo")]
        public int? IdJogo { get; set; }
        [Column("Id_Compra")]
        public int? IdCompra { get; set; }

        [ForeignKey("IdCompra")]
        [InverseProperty("JogosCompras")]
        public virtual  Compra? IdCompraNavigation { get; set; }
        [ForeignKey("IdJogo")]
        [InverseProperty("JogosCompras")]
        public virtual Jogo? IdJogoNavigation { get; set; }
    }
}
