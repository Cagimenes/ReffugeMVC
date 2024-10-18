using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReffugeMVC.Models
{
    [Table("TermometroNoturno")]
    public class TermometroNoturno
    {
        [Column("TermometroNoturnoId")]
        [Display(Name = "Código do Termômetro Noturno")]
        public int TermometroNoturnoId { get; set; }

        [Column("Data")]
        [Display(Name = "Data")]
        public DateTime Data { get; set; }

        [ForeignKey("DuracaoSonoId")]
        public int DuracaoSonoId { get; set; }

        public DuracaoSono? DuracaoSono { get; set; }

        [Column("VezesAcordou")]
        [Display(Name = "Vezes que Acordou")]
        public int VezesAcordou { get; set; }

        [ForeignKey("TipoSentimentoSonoId")]
        public int TipoSentimentoSonoId { get; set; }

        public TipoSentimentoSono? TipoSentimentoSono { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }
    }
}
