using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(13)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    CarritoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => x.CarritoId);
                    table.ForeignKey(
                        name: "FK_Carrito_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarritoProducto",
                columns: table => new
                {
                    CarritoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoProducto", x => new { x.CarritoId, x.ProductoId });
                    table.ForeignKey(
                        name: "FK_CarritoProducto_Carrito_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carrito",
                        principalColumn: "CarritoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarritoProducto_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    OrdenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    CarritoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.OrdenId);
                    table.ForeignKey(
                        name: "FK_Orden_Carrito_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carrito",
                        principalColumn: "CarritoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "ClienteId", "Apellido", "DNI", "Direccion", "Nombre", "Telefono" },
                values: new object[] { 1, "Yedro", "43655405", "Calle 17 1234", "Valentin", "1125908161" });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "ProductoId", "Codigo", "Descripcion", "Image", "Marca", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "#1", "Un mate estilo camionero con virola de aluminio y recubierto de cuero.", "https://i.imgur.com/kBpL61h.jpg", "Mates Berazategui", "Mate camionero ALUMINIO", 2000m },
                    { 2, "#2", "Un mate estilo torpedo con virola de aluminio y recubierto de cuero.", "https://i.imgur.com/OBgi9Rq.jpg", "Mates Berazategui", "Mate torpedo ALUMINIO", 2000m },
                    { 3, "#3", "Un mate estilo camionero con virola de aluminio cincelada y recubierto de cuero.", "https://i.imgur.com/rTMC88Q.jpg", "Mates Berazategui", "Mate camionero ALUMINIO CINCELADO", 2300m },
                    { 4, "#4", "Un mate estilo torpedo con virola de aluminio cincelada y recubierto de cuero.", "https://i.imgur.com/lnaf51K.jpg", "Mates Berazategui", "Mate torpedo ALUMINIO CINCELADO", 2300m },
                    { 5, "#5", "Un mate estilo camionero con virola de alpaca lisa y recubierto de cuero.", "https://i.imgur.com/QChC7FG.jpg", "Mates Berazategui", "Mate camionero ALPACA LISA", 3000m },
                    { 6, "#6", "Un mate estilo torpedo con virola de alpaca lisa y recubierto de cuero.", "https://i.imgur.com/gRMsfCx.jpg", "Mates Berazategui", "Mate torpedo ALPACA LISA", 3000m },
                    { 7, "#7", "Un mate estilo camionero con virola de alpaca cincelada y recubierto de cuero.", "https://i.imgur.com/gt1RiK4.jpg", "Mates Berazategui", "Mate camionero ALPACA CINCELADA", 3300m },
                    { 8, "#8", "Un mate estilo torpedo con virola de alpaca cincelada y recubierto de cuero.", "https://i.imgur.com/DNDhDf6.jpg", "Mates Berazategui", "Mate torpedo ALPACA CINCELADA", 3300m },
                    { 9, "#9", "Un mate estilo camionero con virola de alpaca grabada totalmente personalizada y recubierto de cuero.", "https://i.imgur.com/Slb5Ojf.jpg", "Mates Berazategui", "Mate camionero ALPACA GRABADA", 4200m },
                    { 10, "#10", "Una bombilla ideal para un mate ideal. Con estilo pico loro para máximo confort.", "https://i.imgur.com/3UPfdzA.jpg", "Mates Berazategui", "Bombilla pico loro ACERO INOXIDABLE", 800m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_ClienteId",
                table: "Carrito",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoProducto_ProductoId",
                table: "CarritoProducto",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_CarritoId",
                table: "Orden",
                column: "CarritoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoProducto");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
