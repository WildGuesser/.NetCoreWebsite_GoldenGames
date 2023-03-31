using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GoldenGames.Models
{
    public partial class Utilizador : IdentityUser
    {
        public Utilizador()
        {
            RegistoJogos = new HashSet<RegistoJogo>();
            UtilizadoresJogos = new HashSet<UtilizadoresJogo>();
            Compras = new HashSet<Compra>();
        }

        /*Propriedades adicionais*/

        [InverseProperty("IdUtilizadorNavigation")]
        public virtual ICollection<RegistoJogo> RegistoJogos { get; set; }

        [InverseProperty("IdUtilizadorNavigation")]
        public virtual ICollection<UtilizadoresJogo> UtilizadoresJogos { get; set; }

        [InverseProperty("IdUtilizadorNavigation")]
        public virtual ICollection<FavCategories>? CategoriasFavoritas { get; set; }

        [InverseProperty("IdUtilizadorNavigation")]
        public virtual ICollection<Review>? Reviews { get; set; }

        [InverseProperty("IdUtilizadorNavigation")]
        public virtual ICollection<Compra>? Compras { get; set; }
    }
}
