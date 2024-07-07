using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chocolates.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    idCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__A2B5777C4A3A3A3D", x => x.idCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Chocolate",
                columns: table => new
                {
                    idChocolate = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Chocolat__D3B9D1A3A3A3A3D", x => x.idChocolate);
                    table.ForeignKey(
                        name: "FK__Chocolate__idCat__3A81B327",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "idCategoria");
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "idCategoria", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Chocolates con sabor amargo", "Amargo" },
                    { 2, "Chocolate sabor semiamargo", "Semiamargo" },
                    { 3, "Chocolate oscuro", "Oscuro" },
                    { 4, "Chocolate blanco", "Blanco" },
                    { 5, "Chocolate relleno", "Relleno" }
                });

            migrationBuilder.InsertData(
                table: "Chocolate",
                columns: new[] { "idChocolate", "Descripcion", "IdCategoria", "Imagen", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "Chocolate oscuro con 70% de cacao", 1, "chocolate1.jpg", "Chocolate Amargo 70%", 50.00m },
                    { 2, "Chocolate oscuro con 85% de cacao", 1, "chocolate2.jpg", "Chocolate Amargo 85%", 60.00m },
                    { 3, "Chocolate semiamargo con 50% de cacao", 2, "chocolate3.jpg", "Chocolate Semiamargo 50%", 40.00m },
                    { 4, "Chocolate semiamargo con 60% de cacao", 2, "chocolate4.jpg", "Chocolate Semiamargo 60%", 45.00m },
                    { 5, "Chocolate oscuro con 75% de cacao", 3, "chocolate5.jpg", "Chocolate Oscuro 75%", 55.00m },
                    { 6, "Chocolate oscuro con 90% de cacao", 3, "chocolate6.jpg", "Chocolate Oscuro 90%", 65.00m },
                    { 7, "Chocolate blanco cremoso", 4, "chocolate7.jpg", "Chocolate Blanco", 50.00m },
                    { 8, "Chocolate blanco con trozos de almendras", 4, "chocolate8.jpg", "Chocolate Blanco con Almendras", 55.00m },
                    { 9, "Chocolate relleno de crema de fresa", 5, "chocolate9.jpg", "Chocolate Relleno de Fresa", 60.00m },
                    { 10, "Chocolate relleno de crema de naranja", 5, "chocolate10.jpg", "Chocolate Relleno de Naranja", 60.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chocolate_IdCategoria",
                table: "Chocolate",
                column: "IdCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chocolate");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
