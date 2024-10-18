using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReffugeMVC.Models
{
    [Table("Profissional")]
    public class Profissional
    {
        [Column("ProfissionalId")]
        [Display(Name = "Código do Profissional")]
        public int ProfissionalId { get; set; }

        [Column("NomeProfissional")]
        [Display(Name = "Nome do Profissional")]
        public string NomeProfissional { get; set; } = string.Empty;


        [ForeignKey("TipoEspecializacaoId")]
        public int TipoEspecializacaoId { get; set; }

        public TipoEspecializacao? TipoEspecializacao { get; set; }

        [Column("DescricaoProfissional")]
        [Display(Name = "Descrição do Profissional")]
        public string DescricaoProfissional { get; set; } = string.Empty;
    }
}
