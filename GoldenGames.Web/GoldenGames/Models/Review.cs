using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoldenGames.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? UserId { get; set; }

        public string? UserName { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "O {0} tem de ser entre {1} e {2} ")]
        public int Rating { get; set; }

        public string? Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("UserId")]
        [InverseProperty("Reviews")]
        public virtual Utilizador? IdUtilizadorNavigation { get; set; }

        [ForeignKey("GameId")]
        [InverseProperty("Reviews")]
        public virtual Jogo? IdJogoNavigation { get; set; }
    }
}