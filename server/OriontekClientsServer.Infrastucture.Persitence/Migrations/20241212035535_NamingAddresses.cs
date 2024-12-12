using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OriontekClientsServer.Infrastucture.Persitence.Migrations
{
    /// <inheritdoc />
    public partial class NamingAddresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientAddress_Clients_ClientId",
                table: "ClientAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientAddress",
                table: "ClientAddress");

            migrationBuilder.RenameTable(
                name: "ClientAddress",
                newName: "ClientsAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_ClientAddress_ClientId",
                table: "ClientsAddresses",
                newName: "IX_ClientsAddresses_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientsAddresses",
                table: "ClientsAddresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientsAddresses_Clients_ClientId",
                table: "ClientsAddresses",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientsAddresses_Clients_ClientId",
                table: "ClientsAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientsAddresses",
                table: "ClientsAddresses");

            migrationBuilder.RenameTable(
                name: "ClientsAddresses",
                newName: "ClientAddress");

            migrationBuilder.RenameIndex(
                name: "IX_ClientsAddresses_ClientId",
                table: "ClientAddress",
                newName: "IX_ClientAddress_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientAddress",
                table: "ClientAddress",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientAddress_Clients_ClientId",
                table: "ClientAddress",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
