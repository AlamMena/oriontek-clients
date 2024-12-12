using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OriontekClientsServer.Infrastucture.Persitence.Migrations
{
    /// <inheritdoc />
    public partial class RestrictMode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientAddress_Clients_ClientId",
                table: "ClientAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientAddress_Clients_ClientId",
                table: "ClientAddress",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientAddress_Clients_ClientId",
                table: "ClientAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientAddress_Clients_ClientId",
                table: "ClientAddress",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
