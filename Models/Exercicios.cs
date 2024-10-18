using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReffugeMVC.Models
{
    [Table("Exercicios")]
    public class Exercicios
    {
        [Column("ExerciciosId")]
        [Display(Name = "Código dos Exercícios")]
        public int ExerciciosId { get; set; }

        [Column("NomeExercicios")]
        [Display(Name = "Nome dos Exercícios")]
        public string NomeExercicios { get; set; } = string.Empty;

        [ForeignKey("TipoExerciciosId")]
        public int TipoExerciciosId { get; set; }

        public TipoExercicios? TipoExercicios { get; set; }
    }
}
