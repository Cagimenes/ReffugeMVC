using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReffugeMVC.Models
{
    [Table("Planos")]
    public class Planos
    {
        [Column("PlanosId")]
        [Display(Name = "Código dos Planos")]
        public int PlanosId { get; set; }

        [Column("NomePlanos")]
        [Display(Name = "Nome dos Planos")]
        public string NomePlanos { get; set; } = string.Empty;


        [Column("PrecoPlanos")]
        [Display(Name = "Preço dos Planos")]
        public decimal PrecoPlanos { get; set; }

        [Column("DescricaoPlanos")]
        [Display(Name = "Descricao dos Planos")]
        public string DescricaoPlanos { get; set; } = string.Empty;

        [Column("DuracaoPlanos")]
        [Display(Name = "Duracao dos Planos")]
        public string DuracaoPlanos { get; set; } = string.Empty;

    }
}
