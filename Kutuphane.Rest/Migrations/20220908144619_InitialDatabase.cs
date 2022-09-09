using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kutuphane.Rest.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Durums",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Durums", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UyeBilgileris",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UyeBilgileris", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "YayınEvis",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YayınEvis", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kitaps",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yazari = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Türü = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SayfaSayisi = table.Column<int>(type: "int", nullable: false),
                    YayinEviId = table.Column<int>(type: "int", nullable: false),
                    DurumID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaps", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kitaps_Durums_DurumID",
                        column: x => x.DurumID,
                        principalTable: "Durums",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kitaps_YayınEvis_YayinEviId",
                        column: x => x.YayinEviId,
                        principalTable: "YayınEvis",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KitapHarekets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapID = table.Column<int>(type: "int", nullable: false),
                    UyeBilgileriID = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HareketYonu = table.Column<int>(type: "int", nullable: false),
                    Hareket = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapHarekets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KitapHarekets_Kitaps_KitapID",
                        column: x => x.KitapID,
                        principalTable: "Kitaps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitapHarekets_UyeBilgileris_UyeBilgileriID",
                        column: x => x.UyeBilgileriID,
                        principalTable: "UyeBilgileris",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KitapHarekets_KitapID",
                table: "KitapHarekets",
                column: "KitapID");

            migrationBuilder.CreateIndex(
                name: "IX_KitapHarekets_UyeBilgileriID",
                table: "KitapHarekets",
                column: "UyeBilgileriID");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaps_DurumID",
                table: "Kitaps",
                column: "DurumID");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaps_YayinEviId",
                table: "Kitaps",
                column: "YayinEviId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KitapHarekets");

            migrationBuilder.DropTable(
                name: "Kitaps");

            migrationBuilder.DropTable(
                name: "UyeBilgileris");

            migrationBuilder.DropTable(
                name: "Durums");

            migrationBuilder.DropTable(
                name: "YayınEvis");
        }
    }
}
