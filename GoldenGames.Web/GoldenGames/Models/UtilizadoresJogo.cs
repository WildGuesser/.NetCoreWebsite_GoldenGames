using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoldenGames.Models
{
    [Table("Utilizadores_Jogos")]
    public partial class UtilizadoresJogo
    {
        [Key]
        public int Id { get; set; }
        [Column("Id_Utilizador")]
        public string? IdUtilizador { get; set; }
        [Column("Id_Jogos")]
        public int? IdJogos { get; set; }

        [ForeignKey("IdJogos")]
        [InverseProperty("UtilizadoresJogos")]
        public virtual Jogo? IdJogosNavigation { get; set; }

        [ForeignKey("IdUtilizador")]
        [InverseProperty("UtilizadoresJogos")]
        public virtual Utilizador? IdUtilizadorNavigation { get; set; }
    }
}
