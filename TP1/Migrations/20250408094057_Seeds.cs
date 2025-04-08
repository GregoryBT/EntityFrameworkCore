using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TP1.Migrations
{
    /// <inheritdoc />
    public partial class Seeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salle",
                table: "Sessions");

            migrationBuilder.InsertData(
                table: "Lieux",
                columns: new[] { "Id", "Adresse", "Nom" },
                values: new object[,]
                {
                    { 1, "79 Rue de la République, 69002 Lyon", "Pathé Bellcour" },
                    { 2, "43 Rue des Docks, 69009 Lyon", "Pathé Vaise" }
                });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "Email", "Nom", "Prenom", "Telephone" },
                values: new object[,]
                {
                    { 1, "jean@dupuis.fr", "Dupuis", "Jean", "0606060606" },
                    { 2, "Jeanne@Dupont.fr", "Dupont", "Jeanne", "0606060606" }
                });

            migrationBuilder.InsertData(
                table: "Evenements",
                columns: new[] { "Id", "Description", "LieuId", "Name" },
                values: new object[,]
                {
                    { 1, "Une conférence sur les dernières avancées en intelligence artificielle.", 1, "Conférence sur l'IA" },
                    { 2, "Un atelier pratique sur le développement web.", 2, "Atelier de développement web" }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "EvenementId", "HeureDebut", "HeureFin" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 4, 8, 9, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 4, 8, 11, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 2, new DateTime(2025, 4, 8, 12, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 4, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, 1, new DateTime(2025, 4, 8, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 4, 8, 17, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, 2, new DateTime(2025, 4, 8, 18, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 4, 8, 20, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Evenements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Evenements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lieux",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lieux",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "Salle",
                table: "Sessions",
                type: "text",
                nullable: true);
        }
    }
}
