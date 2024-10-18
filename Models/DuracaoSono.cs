using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReffugeMVC.Models
{
    [Table("DuracaoSono")]
    public class DuracaoSono
    {
        [Column("DuracaoSonoId")]
        [Display(Name = "Código da Duração do Sono")]
        public int DuracaoSonoId { get; set; }

        [Column("NomeDuracaoSono")]
        [Display(Name = "Duração do Sono")]
        public string NomeDuracaoSono { get; set; } = string.Empty;
    }
}
