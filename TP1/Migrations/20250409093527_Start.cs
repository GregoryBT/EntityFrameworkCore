using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TP1.Migrations
{
    /// <inheritdoc />
    public partial class Start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Intervenants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Prenom = table.Column<string>(type: "text", nullable: false),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Biographie = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Entreprise = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intervenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lieux",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Adresse = table.Column<string>(type: "text", nullable: false),
                    Ville = table.Column<string>(type: "text", nullable: false),
                    Pays = table.Column<string>(type: "text", nullable: false),
                    Capacite = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lieux", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Prenom = table.Column<string>(type: "text", nullable: false),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Entreprise = table.Column<string>(type: "text", nullable: false),
                    Poste = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evenements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titre = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DateDebut = table.Column<string>(type: "text", nullable: false),
                    DateFin = table.Column<string>(type: "text", nullable: false),
                    Statut = table.Column<string>(type: "text", nullable: false),
                    Categorie = table.Column<string>(type: "text", nullable: false),
                    LieuId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evenements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evenements_Lieux_LieuId",
                        column: x => x.LieuId,
                        principalTable: "Lieux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Capacite = table.Column<int>(type: "integer", nullable: false),
                    LieuId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salles_Lieux_LieuId",
                        column: x => x.LieuId,
                        principalTable: "Lieux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvenementParticipants",
                columns: table => new
                {
                    EvenementId = table.Column<int>(type: "integer", nullable: false),
                    ParticipantId = table.Column<int>(type: "integer", nullable: false),
                    DateInscription = table.Column<string>(type: "text", nullable: false),
                    StatutPresence = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvenementParticipants", x => new { x.EvenementId, x.ParticipantId });
                    table.ForeignKey(
                        name: "FK_EvenementParticipants_Evenements_EvenementId",
                        column: x => x.EvenementId,
                        principalTable: "Evenements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvenementParticipants_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titre = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    HeureDebut = table.Column<string>(type: "text", nullable: false),
                    HeureFin = table.Column<string>(type: "text", nullable: false),
                    EvenementId = table.Column<int>(type: "integer", nullable: false),
                    SalleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Evenements_EvenementId",
                        column: x => x.EvenementId,
                        principalTable: "Evenements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessions_Salles_SalleId",
                        column: x => x.SalleId,
                        principalTable: "Salles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Note = table.Column<int>(type: "integer", nullable: false),
                    Commentaire = table.Column<string>(type: "text", nullable: false),
                    SessionId = table.Column<int>(type: "integer", nullable: false),
                    ParticipantId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notations_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notations_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionIntervenants",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "integer", nullable: false),
                    IntervenantId = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionIntervenants", x => new { x.SessionId, x.IntervenantId });
                    table.ForeignKey(
                        name: "FK_SessionIntervenants_Intervenants_IntervenantId",
                        column: x => x.IntervenantId,
                        principalTable: "Intervenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionIntervenants_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Lieux",
                columns: new[] { "Id", "Adresse", "Capacite", "Nom", "Pays", "Ville" },
                values: new object[,]
                {
                    { 1, "123 Rue Principale", 500, "Centre des Congrès", "France", "Lyon" },
                    { 2, "456 Rue Expo", 800, "Palais des Expos", "France", "Paris" },
                    { 3, "789 Rue Sud", 300, "Auditorium Sud", "France", "Marseille" }
                });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "Email", "Entreprise", "Nom", "Poste", "Prenom" },
                values: new object[,]
                {
                    { 1, "alice@exemple.com", "TechCorp", "Durand", "Dév", "Alice" },
                    { 2, "bob@exemple.com", "DataInc", "Martin", "Analyste", "Bob" },
                    { 3, "claire@exemple.com", "WebSolutions", "Morel", "Cheffe de projet", "Claire" }
                });

            migrationBuilder.InsertData(
                table: "Evenements",
                columns: new[] { "Id", "Categorie", "DateDebut", "DateFin", "Description", "LieuId", "Statut", "Titre" },
                values: new object[,]
                {
                    { 1, "Tech", "2025-09-04", "2025-09-04", "Conférence tech.", 1, "Ouvert", "Tech 2025" },
                    { 2, "IA", "2025-09-04", "2025-09-04", "Sommet sur l'IA.", 2, "Complet", "IA Summit" },
                    { 3, "Blockchain", "2025-09-04", "2025-09-04", "Événement blockchain.", 3, "Ouvert", "Web3 Days" }
                });

            migrationBuilder.InsertData(
                table: "Salles",
                columns: new[] { "Id", "Capacite", "LieuId", "Nom" },
                values: new object[,]
                {
                    { 1, 100, 1, "Salle A" },
                    { 2, 150, 1, "Salle B" },
                    { 3, 200, 2, "Salle C" }
                });

            migrationBuilder.InsertData(
                table: "EvenementParticipants",
                columns: new[] { "EvenementId", "ParticipantId", "DateInscription", "StatutPresence" },
                values: new object[,]
                {
                    { 1, 1, "2025-09-04", "Présente" },
                    { 1, 2, "2025-09-04", "Présent" },
                    { 2, 3, "2025-09-04", "Présente" }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "Description", "EvenementId", "HeureDebut", "HeureFin", "SalleId", "Titre" },
                values: new object[,]
                {
                    { 1, "Bases de l'IA", 1, "2025-09-04", "2025-09-04", 1, "Intro IA" },
                    { 2, "Fonctionnement", 3, "2025-09-04", "2025-09-04", 3, "Blockchain" },
                    { 3, "Déploiement", 2, "2025-09-04", "2025-09-04", 2, "Cloud Azure" }
                });

            migrationBuilder.InsertData(
                table: "Notations",
                columns: new[] { "Id", "Commentaire", "Note", "ParticipantId", "SessionId" },
                values: new object[,]
                {
                    { 1, "Super présentation", 5, 1, 1 },
                    { 2, "Très intéressant", 4, 2, 2 },
                    { 3, "Excellent contenu", 5, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvenementParticipants_ParticipantId",
                table: "EvenementParticipants",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Evenements_LieuId",
                table: "Evenements",
                column: "LieuId");

            migrationBuilder.CreateIndex(
                name: "IX_Notations_ParticipantId",
                table: "Notations",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Notations_SessionId",
                table: "Notations",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Salles_LieuId",
                table: "Salles",
                column: "LieuId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionIntervenants_IntervenantId",
                table: "SessionIntervenants",
                column: "IntervenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_EvenementId",
                table: "Sessions",
                column: "EvenementId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_SalleId",
                table: "Sessions",
                column: "SalleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvenementParticipants");

            migrationBuilder.DropTable(
                name: "Notations");

            migrationBuilder.DropTable(
                name: "SessionIntervenants");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Intervenants");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Evenements");

            migrationBuilder.DropTable(
                name: "Salles");

            migrationBuilder.DropTable(
                name: "Lieux");
        }
    }
}
