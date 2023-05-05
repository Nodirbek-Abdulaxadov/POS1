using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class LoansAndPayments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GivenDate",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "PaidDate",
                table: "LoanPayments");

            migrationBuilder.RenameColumn(
                name: "PaidAmount",
                table: "LoanPayments",
                newName: "TotalPayment");

            migrationBuilder.AddColumn<decimal>(
                name: "PaidCard",
                table: "LoanPayments",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PaidCash",
                table: "LoanPayments",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidCard",
                table: "LoanPayments");

            migrationBuilder.DropColumn(
                name: "PaidCash",
                table: "LoanPayments");

            migrationBuilder.RenameColumn(
                name: "TotalPayment",
                table: "LoanPayments",
                newName: "PaidAmount");

            migrationBuilder.AddColumn<string>(
                name: "GivenDate",
                table: "Loans",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaidDate",
                table: "LoanPayments",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
