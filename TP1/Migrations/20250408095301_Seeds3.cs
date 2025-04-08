using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TP1.Migrations
{
    /// <inheritdoc />
    public partial class Seeds3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ParticipantSession",
                columns: new[] { "ParticipantsId", "SessionsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 2 },
                    { 2, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParticipantSession",
                keyColumns: new[] { "ParticipantsId", "SessionsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ParticipantSession",
                keyColumns: new[] { "ParticipantsId", "SessionsId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ParticipantSession",
                keyColumns: new[] { "ParticipantsId", "SessionsId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ParticipantSession",
                keyColumns: new[] { "ParticipantsId", "SessionsId" },
                keyValues: new object[] { 2, 4 });
        }
    }
}
