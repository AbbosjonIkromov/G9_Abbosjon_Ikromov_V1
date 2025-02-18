using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ModulExam5.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_date = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "current_timestamp"),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.order_id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_name = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false, defaultValue: 0.00m),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "order_details",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_id = table.Column<int>(type: "integer", nullable: false),
                    product_id = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_details", x => x.id);
                    table.ForeignKey(
                        name: "fk_order_details_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_order_details_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_order_details_order_id",
                table: "order_details",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_details_product_id",
                table: "order_details",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_details");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
