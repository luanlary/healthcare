using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace healthcare.Repositorio.Migrations
{
    public partial class StartDaBaseDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultorios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Endereco = table.Column<string>(maxLength: 150, nullable: false),
                    Telefone = table.Column<string>(maxLength: 50, nullable: false),
                    Nome = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultorios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Crm = table.Column<string>(maxLength: 50, nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(maxLength: 50, nullable: true),
                    ValorConsulta = table.Column<decimal>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsultorioMedico",
                columns: table => new
                {
                    ConsultorioId = table.Column<int>(nullable: false),
                    MedicoId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultorioMedico", x => new { x.ConsultorioId, x.MedicoId });
                    table.UniqueConstraint("AK_ConsultorioMedico_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultorioMedico_Consultorios_ConsultorioId",
                        column: x => x.ConsultorioId,
                        principalTable: "Consultorios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultorioMedico_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultorioMedico_MedicoId",
                table: "ConsultorioMedico",
                column: "MedicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultorioMedico");

            migrationBuilder.DropTable(
                name: "Consultorios");

            migrationBuilder.DropTable(
                name: "Medicos");
        }
    }
}
