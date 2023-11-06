using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pos.Migrations
{
    public partial class date : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PoDate",
                table: "Invoices",
                newName: "InvoiceDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InvoiceDate",
                table: "Invoices",
                newName: "PoDate");
        }
    }
}
