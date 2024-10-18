using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReffugeMVC.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DuracaoSono",
                columns: table => new
                {
                    DuracaoSonoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDuracaoSono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuracaoSono", x => x.DuracaoSonoId);
                });

            migrationBuilder.CreateTable(
                name: "Planos",
                columns: table => new
                {
                    PlanosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePlanos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoPlanos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DescricaoPlanos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuracaoPlanos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos", x => x.PlanosId);
                });

            migrationBuilder.CreateTable(
                name: "TipoConteudo",
                columns: table => new
                {
                    TipoConteudoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoConteudo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoConteudo", x => x.TipoConteudoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoEmocao",
                columns: table => new
                {
                    TipoEmocaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoEmocao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEmocao", x => x.TipoEmocaoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoEspecializacao",
                columns: table => new
                {
                    TipoEspecializacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoEspecializacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEspecializacao", x => x.TipoEspecializacaoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoExercicios",
                columns: table => new
                {
                    TipoExerciciosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoExercicios = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoExercicios", x => x.TipoExerciciosId);
                });

            migrationBuilder.CreateTable(
                name: "TipoSentimentoSono",
                columns: table => new
                {
                    TipoSentimentoSonoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoSentimentoSono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSentimentoSono", x => x.TipoSentimentoSonoId);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CpfCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefoneCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenhaCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Cliente_Planos_PlanosId",
                        column: x => x.PlanosId,
                        principalTable: "Planos",
                        principalColumn: "PlanosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conteudo",
                columns: table => new
                {
                    ConteudoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeConteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoConteudoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conteudo", x => x.ConteudoId);
                    table.ForeignKey(
                        name: "FK_Conteudo_TipoConteudo_TipoConteudoId",
                        column: x => x.TipoConteudoId,
                        principalTable: "TipoConteudo",
                        principalColumn: "TipoConteudoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profissional",
                columns: table => new
                {
                    ProfissionalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProfissional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoEspecializacaoId = table.Column<int>(type: "int", nullable: false),
                    DescricaoProfissional = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissional", x => x.ProfissionalId);
                    table.ForeignKey(
                        name: "FK_Profissional_TipoEspecializacao_TipoEspecializacaoId",
                        column: x => x.TipoEspecializacaoId,
                        principalTable: "TipoEspecializacao",
                        principalColumn: "TipoEspecializacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercicios",
                columns: table => new
                {
                    ExerciciosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeExercicios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoExerciciosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicios", x => x.ExerciciosId);
                    table.ForeignKey(
                        name: "FK_Exercicios_TipoExercicios_TipoExerciciosId",
                        column: x => x.TipoExerciciosId,
                        principalTable: "TipoExercicios",
                        principalColumn: "TipoExerciciosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diario",
                columns: table => new
                {
                    DiarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHorario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConteudoDiario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diario", x => x.DiarioId);
                    table.ForeignKey(
                        name: "FK_Diario_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TermometroEmocional",
                columns: table => new
                {
                    TermometroEmocionalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoEmocaoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermometroEmocional", x => x.TermometroEmocionalId);
                    table.ForeignKey(
                        name: "FK_TermometroEmocional_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TermometroEmocional_TipoEmocao_TipoEmocaoId",
                        column: x => x.TipoEmocaoId,
                        principalTable: "TipoEmocao",
                        principalColumn: "TipoEmocaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TermometroNoturno",
                columns: table => new
                {
                    TermometroNoturnoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuracaoSonoId = table.Column<int>(type: "int", nullable: false),
                    VezesAcordou = table.Column<int>(type: "int", nullable: false),
                    TipoSentimentoSonoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermometroNoturno", x => x.TermometroNoturnoId);
                    table.ForeignKey(
                        name: "FK_TermometroNoturno_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TermometroNoturno_DuracaoSono_DuracaoSonoId",
                        column: x => x.DuracaoSonoId,
                        principalTable: "DuracaoSono",
                        principalColumn: "DuracaoSonoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TermometroNoturno_TipoSentimentoSono_TipoSentimentoSonoId",
                        column: x => x.TipoSentimentoSonoId,
                        principalTable: "TipoSentimentoSono",
                        principalColumn: "TipoSentimentoSonoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    AgendamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfissionalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.AgendamentoId);
                    table.ForeignKey(
                        name: "FK_Agendamento_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamento_Profissional_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissional",
                        principalColumn: "ProfissionalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_ClienteId",
                table: "Agendamento",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_ProfissionalId",
                table: "Agendamento",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_PlanosId",
                table: "Cliente",
                column: "PlanosId");

            migrationBuilder.CreateIndex(
                name: "IX_Conteudo_TipoConteudoId",
                table: "Conteudo",
                column: "TipoConteudoId");

            migrationBuilder.CreateIndex(
                name: "IX_Diario_ClienteId",
                table: "Diario",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicios_TipoExerciciosId",
                table: "Exercicios",
                column: "TipoExerciciosId");

            migrationBuilder.CreateIndex(
                name: "IX_Profissional_TipoEspecializacaoId",
                table: "Profissional",
                column: "TipoEspecializacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TermometroEmocional_ClienteId",
                table: "TermometroEmocional",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TermometroEmocional_TipoEmocaoId",
                table: "TermometroEmocional",
                column: "TipoEmocaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TermometroNoturno_ClienteId",
                table: "TermometroNoturno",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TermometroNoturno_DuracaoSonoId",
                table: "TermometroNoturno",
                column: "DuracaoSonoId");

            migrationBuilder.CreateIndex(
                name: "IX_TermometroNoturno_TipoSentimentoSonoId",
                table: "TermometroNoturno",
                column: "TipoSentimentoSonoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamento");

            migrationBuilder.DropTable(
                name: "Conteudo");

            migrationBuilder.DropTable(
                name: "Diario");

            migrationBuilder.DropTable(
                name: "Exercicios");

            migrationBuilder.DropTable(
                name: "TermometroEmocional");

            migrationBuilder.DropTable(
                name: "TermometroNoturno");

            migrationBuilder.DropTable(
                name: "Profissional");

            migrationBuilder.DropTable(
                name: "TipoConteudo");

            migrationBuilder.DropTable(
                name: "TipoExercicios");

            migrationBuilder.DropTable(
                name: "TipoEmocao");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "DuracaoSono");

            migrationBuilder.DropTable(
                name: "TipoSentimentoSono");

            migrationBuilder.DropTable(
                name: "TipoEspecializacao");

            migrationBuilder.DropTable(
                name: "Planos");
        }
    }
}
