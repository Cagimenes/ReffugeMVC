using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReffugeMVC.Models
{
    [Table("TermometroEmocional")]
    public class TermometroEmocional
    {
        [Column("TermometroEmocionalId")]
        [Display(Name = "Código do Termômetro Emocional")]
        public int TermometroEmocionalId { get; set; }

        [ForeignKey("TipoEmocaoId")]
        public int TipoEmocaoId { get; set; }

        public TipoEmocao? TipoEmocao { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        [Column("Data")]
        [Display(Name = "Data")]
        public DateTime Data { get; set; }
    }
}
