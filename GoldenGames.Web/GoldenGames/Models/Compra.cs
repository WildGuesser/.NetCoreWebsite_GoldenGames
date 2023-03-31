using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoldenGames.Models
{
    [Table("Compra")]
    public partial class Compra
    {
        public Compra()
        {
            JogosCompras = new HashSet<JogosCompra>();
        }

        [Key]
        public int Id { get; set; }
        public string? UserId { get; set; }

        public string? UserName { get; set; }

        [Column(TypeName = "decimal(4, 2)")]
        public decimal? Total_Preco { get; set; }

        [InverseProperty("IdCompraNavigation")]
        public virtual ICollection<JogosCompra> JogosCompras { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Compras")]
        public virtual Utilizador IdUtilizadorNavigation { get; set; }
    }
}
