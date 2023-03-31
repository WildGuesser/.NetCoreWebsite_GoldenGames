using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoldenGames.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Jogos = new HashSet<Jogo>();
            CategoriasFavoritas = new HashSet<FavCategories>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Nome { get; set; } = null!;


        [InverseProperty("IdCategoriaNavigation")]
        public virtual ICollection<FavCategories> CategoriasFavoritas { get; set; }

        [InverseProperty("IdCategoriaNavigation")]
        public virtual ICollection<Jogo> Jogos { get; set; }

    }
}
