using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReffugeMVC.Models
{
    [Table("Conteudo")]
    public class Conteudo
    {
        [Column("ConteudoId")]
        [Display(Name = "Código do Conteúdo")]
        public int ConteudoId { get; set; }

        [Column("NomeConteudo")]
        [Display(Name = "Nome do Conteúdo")]
        public string NomeConteudo { get; set; } = string.Empty;

        [ForeignKey("TipoConteudoId")]
        public int TipoConteudoId { get; set; }

        public TipoConteudo? TipoConteudo { get; set; }
    }
}
