using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReffugeMVC.Models
{
    [Table("TipoSentimentoSono")]
    public class TipoSentimentoSono
    {
        [Column("TipoSentimentoSonoId")]
        [Display(Name = "Código do Tipo do Sentimento do Sono")]
        public int TipoSentimentoSonoId { get; set; }

        [Column("NomeTipoSentimentoSono")]
        [Display(Name = "Sentimento do Sono")]
        public string NomeTipoSentimentoSono { get; set; } = string.Empty;
    }
}
