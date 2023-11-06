using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pos.Migrations
{
    public partial class no : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PoNumber",
                table: "Invoices",
                newName: "InvoiceNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InvoiceNo",
                table: "Invoices",
                newName: "PoNumber");
        }
    }
}
