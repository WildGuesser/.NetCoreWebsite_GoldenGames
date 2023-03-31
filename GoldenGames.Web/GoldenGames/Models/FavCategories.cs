using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoldenGames.Models
{
    public class FavCategories
    {
        [Key]
        public int FavCategoriesId { get; set; }
        [Column("Id_User")]
        public string? UserId { get; set; }
        [Column("Id_Categoria")]
        public int IdCategoria { get; set; }


        [ForeignKey("UserId")]
        [InverseProperty("CategoriasFavoritas")]
        public virtual Utilizador? IdUtilizadorNavigation { get; set; }

        [ForeignKey("IdCategoria")]
        [InverseProperty("CategoriasFavoritas")]
        public virtual Categorium? IdCategoriaNavigation { get; set; }
    }
}