using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReffugeMVC.Models
{
    [Table("Diario")]
    public class Diario
    {
        [Column("DiarioId")]
        [Display(Name = "Código do Diário")]
        public int DiarioId { get; set; }

        [Column("DataHorario")]
        [Display(Name = "Data e Horário")]
        public DateTime DataHorario { get; set; } 

        [Column("ConteudoDiario")]
        [Display(Name = "Conteúdo do Diário")]
        public string ConteudoDiario { get; set; } = string.Empty;

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }
    }
}
