using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoldenGames.Models
{
    public partial class Jogo
    {
        public Jogo()
        {
            JogosCompras = new HashSet<JogosCompra>();
            RegistoJogos = new HashSet<RegistoJogo>();
            UtilizadoresJogos = new HashSet<UtilizadoresJogo>();
            Reviews = new HashSet<Review>();

        }

        [Key]
        public int Id { get; set; }
        [Column("Id_Categoria")]
        public int? IdCategoria { get; set; }

        [Column("Id_Consola")]
        public int? IdConsola { get; set; }

        [Column(TypeName = "decimal(4, 2)")]
        public decimal? Preco { get; set; }

        [StringLength(60)]
        public string Nome { get; set; } = null!;

        [StringLength(500)]
        public string Descricao { get; set; } = null!;

        [StringLength(60)]
        public string Produtora { get; set; } = null!;

        public byte[] Imagem { get; set; } = null!;

        [ForeignKey("IdCategoria")]
        [InverseProperty("Jogos")]
        public virtual Categorium? IdCategoriaNavigation { get; set; }

        [ForeignKey("IdConsola")]
        [InverseProperty("Jogos")]
        public virtual Consola? IdConsolaNavigation { get; set; }


        [InverseProperty("IdJogoNavigation")]
        public virtual ICollection<JogosCompra> JogosCompras { get; set; }


        [InverseProperty("IdJogoNavigation")]
        public virtual ICollection<RegistoJogo> RegistoJogos { get; set; }


        [InverseProperty("IdJogosNavigation")]
        public virtual ICollection<UtilizadoresJogo> UtilizadoresJogos { get; set; }

        [InverseProperty("IdJogoNavigation")]
        public virtual ICollection<Review> Reviews { get; set; }

    }
}
