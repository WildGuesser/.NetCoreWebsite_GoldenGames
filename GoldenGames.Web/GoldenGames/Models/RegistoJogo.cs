using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoldenGames.Models
{
    [Table("RegistoJogo")]
    public partial class RegistoJogo
    {
        [Key]
        public int Id { get; set; }
        [Column("Id_Utilizador")]
        public string? IdUtilizador { get; set; }
        [Column("Id_Jogo")]
        public int? IdJogo { get; set; }

        [ForeignKey("IdJogo")]
        [InverseProperty("RegistoJogos")]
        public virtual Jogo? IdJogoNavigation { get; set; }

        [ForeignKey("IdUtilizador")]
        [InverseProperty("RegistoJogos")]
        public virtual Utilizador? IdUtilizadorNavigation { get; set; }
    }
}
