using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BibliotecaDAL.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accesos",
                columns: table => new
                {
                    id_acceso = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    codigo_acceso = table.Column<string>(type: "text", nullable: false),
                    descripcion_acceso = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accesos", x => x.id_acceso);
                });

            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    id_autor = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nombre_autor = table.Column<string>(type: "text", nullable: false),
                    apellidos_autor = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.id_autor);
                });

            migrationBuilder.CreateTable(
                name: "estados_prestamos",
                columns: table => new
                {
                    id_estado_prestamo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    codigo_estado_prestamo = table.Column<string>(type: "text", nullable: false),
                    descripcion_estado_prestamo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estados_prestamos", x => x.id_estado_prestamo);
                });

            migrationBuilder.CreateTable(
                name: "libros",
                columns: table => new
                {
                    id_libro = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    isbn_libro = table.Column<string>(type: "text", nullable: false),
                    titulo_libro = table.Column<string>(type: "text", nullable: false),
                    edicion_libro = table.Column<string>(type: "text", nullable: false),
                    cantidad_libro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libros", x => x.id_libro);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    dni_usuario = table.Column<int>(type: "integer", nullable: false),
                    nombre_usuario = table.Column<string>(type: "text", nullable: false),
                    apellidos_usuario = table.Column<string>(type: "text", nullable: false),
                    tlf_usuario = table.Column<string>(type: "text", nullable: false),
                    clave_usuario = table.Column<string>(type: "text", nullable: false),
                    estaBloqueado_usuario = table.Column<bool>(type: "boolean", nullable: false),
                    fch_fin_bloqueo_usuario = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fch_alta_usuario = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fch_baja_usuario = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    id_acceso = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK_usuarios_accesos_id_acceso",
                        column: x => x.id_acceso,
                        principalTable: "accesos",
                        principalColumn: "id_acceso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rel_Autores_Libros",
                columns: table => new
                {
                    listaAutoresId = table.Column<long>(type: "bigint", nullable: false),
                    listaLibrosId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rel_Autores_Libros", x => new { x.listaAutoresId, x.listaLibrosId });
                    table.ForeignKey(
                        name: "FK_Rel_Autores_Libros_Autor_listaAutoresId",
                        column: x => x.listaAutoresId,
                        principalTable: "Autor",
                        principalColumn: "id_autor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rel_Autores_Libros_libros_listaLibrosId",
                        column: x => x.listaLibrosId,
                        principalTable: "libros",
                        principalColumn: "id_libro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prestamos",
                columns: table => new
                {
                    id_prestamo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    fch_inicio_prestamo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fch_entrega_prestamo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fch_fin_prestamo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    id_estados_prestamos = table.Column<long>(type: "bigint", nullable: false),
                    id_usuario = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prestamos", x => x.id_prestamo);
                    table.ForeignKey(
                        name: "FK_prestamos_estados_prestamos_id_estados_prestamos",
                        column: x => x.id_estados_prestamos,
                        principalTable: "estados_prestamos",
                        principalColumn: "id_estado_prestamo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prestamos_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rel_Prestamos_Libros",
                columns: table => new
                {
                    listaLibrosId = table.Column<long>(type: "bigint", nullable: false),
                    listaPrestamosId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rel_Prestamos_Libros", x => new { x.listaLibrosId, x.listaPrestamosId });
                    table.ForeignKey(
                        name: "FK_Rel_Prestamos_Libros_libros_listaLibrosId",
                        column: x => x.listaLibrosId,
                        principalTable: "libros",
                        principalColumn: "id_libro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rel_Prestamos_Libros_prestamos_listaPrestamosId",
                        column: x => x.listaPrestamosId,
                        principalTable: "prestamos",
                        principalColumn: "id_prestamo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_prestamos_id_estados_prestamos",
                table: "prestamos",
                column: "id_estados_prestamos");

            migrationBuilder.CreateIndex(
                name: "IX_prestamos_id_usuario",
                table: "prestamos",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Rel_Autores_Libros_listaLibrosId",
                table: "Rel_Autores_Libros",
                column: "listaLibrosId");

            migrationBuilder.CreateIndex(
                name: "IX_Rel_Prestamos_Libros_listaPrestamosId",
                table: "Rel_Prestamos_Libros",
                column: "listaPrestamosId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_id_acceso",
                table: "usuarios",
                column: "id_acceso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rel_Autores_Libros");

            migrationBuilder.DropTable(
                name: "Rel_Prestamos_Libros");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "libros");

            migrationBuilder.DropTable(
                name: "prestamos");

            migrationBuilder.DropTable(
                name: "estados_prestamos");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "accesos");
        }
    }
}
