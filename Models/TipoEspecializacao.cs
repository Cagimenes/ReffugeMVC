using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReffugeMVC.Models
{
    [Table("TipoEspecializacao")]
    public class TipoEspecializacao
    {
        [Column("TipoEspecializacaoId")]
        [Display(Name = "Código do Tipo de Especialização")]
        public int TipoEspecializacaoId { get; set; }

        [Column("NomeTipoEspecializacao")]
        [Display(Name = "Tipo de Especialização")]
        public string NomeTipoEspecializacao { get; set; } = string.Empty;
    }
}
