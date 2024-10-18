using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReffugeMVC.Models
{
    [Table("TipoConteudo")]
    public class TipoConteudo
    {
        [Column("TipoConteudoId")]
        [Display(Name = "Código do Tipo do Produto")]
        public int TipoConteudoId { get; set; }

        [Column("NomeTipoConteudo")]
        [Display(Name = "Tipo de Conteúdo")]
        public string NomeTipoConteudo { get; set; } = string.Empty;
    }
}
