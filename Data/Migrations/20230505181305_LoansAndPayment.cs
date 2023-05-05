using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class LoansAndPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaidAmount",
                table: "Loans",
                newName: "TotalPayment");

            migrationBuilder.AddColumn<decimal>(
                name: "PaidCard",
                table: "Loans",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PaidCash",
                table: "Loans",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidCard",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "PaidCash",
                table: "Loans");

            migrationBuilder.RenameColumn(
                name: "TotalPayment",
                table: "Loans",
                newName: "PaidAmount");
        }
    }
}
