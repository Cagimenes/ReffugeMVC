using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReffugeMVC.Models
{
    [Table("TipoExercicios")]
    public class TipoExercicios
    {
        [Column("TipoExerciciosId")]
        [Display(Name = "Código dos Tipos de Exercicios")]
        public int TipoExerciciosId { get; set; }

        [Column("NomeTipoExercicios")]
        [Display(Name = "Tipo dos Exercícios")]
        public string NomeTipoExercicios { get; set; } = string.Empty;

    }
}
