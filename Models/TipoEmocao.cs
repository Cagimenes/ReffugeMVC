using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReffugeMVC.Models
{
    [Table("TipoEmocao")]
    public class TipoEmocao
    {
        [Column("TipoEmocaoId")]
        [Display(Name = "Código do Tipo de Emoção")]
        public int TipoEmocaoId { get; set; }

        [Column("NomeTipoEmocao")]
        [Display(Name = "Tipo de Emoção")]
        public string NomeTipoEmocao { get; set; } = string.Empty;
    }
}
