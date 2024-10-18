using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReffugeMVC.Models
{
    [Table("Agendamento")]
    public class Agendamento
    {
        [Column("AgendamentoId")]
        [Display(Name = "Código do Agendamento")]
        public int AgendamentoId { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        [Column("DataHora")]
        [Display(Name = "Data e Hora")]
        public DateTime DataHora { get; set; }

        [ForeignKey("ProfissionalId")]
        public int ProfissionalId { get; set; }

        public Profissional? Profissional { get; set; }
    }
}
