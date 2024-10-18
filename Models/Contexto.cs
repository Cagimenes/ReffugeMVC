using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace ReffugeMVC.Models
{
    public class Contexto : DbContext

    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }


        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<Conteudo> Conteudo { get; set; }
        public DbSet<Diario> Diario { get; set; }
        public DbSet<Exercicios> Exercicios { get; set; }
        public DbSet<Planos> Planos { get; set; }
        public DbSet<Profissional> Profissional { get; set; }
        public DbSet<TermometroEmocional> TermometroEmocional { get; set; }
        public DbSet<TermometroNoturno> TermometroNoturno { get; set; }
        public DbSet<TipoConteudo> TipoConteudo { get; set; }
        public DbSet<TipoEspecializacao> TipoEspecializacao { get; set; }
        public DbSet<TipoExercicios> TipoExercicios { get; set; }
        public DbSet<TipoSentimentoSono> TipoSentimentoSono { get; set; }
        public DbSet<DuracaoSono> DuracaoSono { get; set; }
        public DbSet<TipoEmocao> TipoEmocao { get; set; }
    }
}
