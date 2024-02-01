using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    public partial class sonuc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gazetes",
                columns: table => new
                {
                    GazeteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GazeteAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GazeteLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GazeteSlogan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GazeteEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GazetFacebook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GazeteInstagram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GazeteYoutube = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GazeteTelefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GazeteAdres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gazetes", x => x.GazeteId);
                });

            migrationBuilder.CreateTable(
                name: "katagoris",
                columns: table => new
                {
                    KatagoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KatagoriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_katagoris", x => x.KatagoriId);
                });

            migrationBuilder.CreateTable(
                name: "Konumlars",
                columns: table => new
                {
                    KonumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KonumAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konumlars", x => x.KonumId);
                });

            migrationBuilder.CreateTable(
                name: "Yazarlars",
                columns: table => new
                {
                    YazarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YazarAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YazarResim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YazarEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YazarSifre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazarlars", x => x.YazarId);
                });

            migrationBuilder.CreateTable(
                name: "Yetkilers",
                columns: table => new
                {
                    YetkiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YetkiAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yetkilers", x => x.YetkiId);
                });

            migrationBuilder.CreateTable(
                name: "Reklamlars",
                columns: table => new
                {
                    ReklamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReklamKonusu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReklamResim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KonumId = table.Column<int>(type: "int", nullable: false),
                    KonumlarKonumId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reklamlars", x => x.ReklamId);
                    table.ForeignKey(
                        name: "FK_Reklamlars_Konumlars_KonumlarKonumId",
                        column: x => x.KonumlarKonumId,
                        principalTable: "Konumlars",
                        principalColumn: "KonumId");
                });

            migrationBuilder.CreateTable(
                name: "haberlers",
                columns: table => new
                {
                    HaberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HaberBaslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HaberKonu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Haberİcerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MansetResim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KatagoriId = table.Column<int>(type: "int", nullable: false),
                    YazarId = table.Column<int>(type: "int", nullable: false),
                    YazarlarYazarId = table.Column<int>(type: "int", nullable: true),
                    HaberTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HaberManset = table.Column<int>(type: "int", nullable: true),
                    KonumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_haberlers", x => x.HaberId);
                    table.ForeignKey(
                        name: "FK_haberlers_katagoris_KatagoriId",
                        column: x => x.KatagoriId,
                        principalTable: "katagoris",
                        principalColumn: "KatagoriId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_haberlers_Konumlars_KonumId",
                        column: x => x.KonumId,
                        principalTable: "Konumlars",
                        principalColumn: "KonumId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_haberlers_Yazarlars_YazarlarYazarId",
                        column: x => x.YazarlarYazarId,
                        principalTable: "Yazarlars",
                        principalColumn: "YazarId");
                });

            migrationBuilder.CreateTable(
                name: "Kulanıcılars",
                columns: table => new
                {
                    KulanıcıId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KulaniciSifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KulaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YetkiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kulanıcılars", x => x.KulanıcıId);
                    table.ForeignKey(
                        name: "FK_Kulanıcılars_Yetkilers_YetkiId",
                        column: x => x.YetkiId,
                        principalTable: "Yetkilers",
                        principalColumn: "YetkiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resimlers",
                columns: table => new
                {
                    ResimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResimAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HaberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resimlers", x => x.ResimId);
                    table.ForeignKey(
                        name: "FK_Resimlers_haberlers_HaberId",
                        column: x => x.HaberId,
                        principalTable: "haberlers",
                        principalColumn: "HaberId");
                });

            migrationBuilder.CreateTable(
                name: "Yorumlars",
                columns: table => new
                {
                    YorumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YorumAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YorumMesaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HaberId = table.Column<int>(type: "int", nullable: false),
                    HaberlersHaberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorumlars", x => x.YorumId);
                    table.ForeignKey(
                        name: "FK_Yorumlars_haberlers_HaberlersHaberId",
                        column: x => x.HaberlersHaberId,
                        principalTable: "haberlers",
                        principalColumn: "HaberId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_haberlers_KatagoriId",
                table: "haberlers",
                column: "KatagoriId");

            migrationBuilder.CreateIndex(
                name: "IX_haberlers_KonumId",
                table: "haberlers",
                column: "KonumId");

            migrationBuilder.CreateIndex(
                name: "IX_haberlers_YazarlarYazarId",
                table: "haberlers",
                column: "YazarlarYazarId");

            migrationBuilder.CreateIndex(
                name: "IX_Kulanıcılars_YetkiId",
                table: "Kulanıcılars",
                column: "YetkiId");

            migrationBuilder.CreateIndex(
                name: "IX_Reklamlars_KonumlarKonumId",
                table: "Reklamlars",
                column: "KonumlarKonumId");

            migrationBuilder.CreateIndex(
                name: "IX_Resimlers_HaberId",
                table: "Resimlers",
                column: "HaberId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlars_HaberlersHaberId",
                table: "Yorumlars",
                column: "HaberlersHaberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gazetes");

            migrationBuilder.DropTable(
                name: "Kulanıcılars");

            migrationBuilder.DropTable(
                name: "Reklamlars");

            migrationBuilder.DropTable(
                name: "Resimlers");

            migrationBuilder.DropTable(
                name: "Yorumlars");

            migrationBuilder.DropTable(
                name: "Yetkilers");

            migrationBuilder.DropTable(
                name: "haberlers");

            migrationBuilder.DropTable(
                name: "katagoris");

            migrationBuilder.DropTable(
                name: "Konumlars");

            migrationBuilder.DropTable(
                name: "Yazarlars");
        }
    }
}
