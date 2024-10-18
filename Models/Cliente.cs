using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReffugeMVC.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Column("ClienteId")]
        [Display(Name = "Código do Cliente")]
        public int ClienteId { get; set; }

        [Column("NomeCliente")]
        [Display(Name = "Nome")]
        public string NomeCliente { get; set; } = string.Empty;

        [Column("CpfCliente")]
        [Display(Name = "CPF")]
        public string CpfCliente { get; set; } = string.Empty;

        [Column("TelefoneCliente")]
        [Display(Name = "Telefone")]
        public string TelefoneCliente { get; set; } = string.Empty;

        [Column("EmailCliente")]
        [Display(Name = "Email")]
        public string ClienteEmail { get; set; } = string.Empty;

        [Column("SenhaCliente")]
        [Display(Name = "Senha")]
        public string SenhaCliente { get; set; } = string.Empty;

        [ForeignKey("PlanosId")]
        public int PlanosId { get; set; }

        public Planos? Planos { get; set; }
    }
}
