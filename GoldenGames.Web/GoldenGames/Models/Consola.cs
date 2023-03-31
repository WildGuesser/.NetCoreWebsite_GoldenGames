using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenGames.Models
{
    public class Consola
    {
        public Consola()
        {
            Jogos = new HashSet<Jogo>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Nome { get; set; } = null!;


        [InverseProperty("IdConsolaNavigation")]
        public virtual ICollection<Jogo> Jogos { get; set; }
    }
}
