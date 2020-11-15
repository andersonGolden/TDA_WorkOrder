using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TDADomain.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agbada",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    L = table.Column<double>(type: "float", nullable: false),
                    W = table.Column<double>(type: "float", nullable: false),
                    Head = table.Column<double>(type: "float", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agbada", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChestPocket",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChestPocket", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cuffs",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuffs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Embroidery",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Embroidery", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Flap",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flap", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Neck",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neck", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sleeve",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sleeve", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Style",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Style", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Top",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Neck = table.Column<double>(type: "float", nullable: false),
                    Back = table.Column<double>(type: "float", nullable: false),
                    Hand = table.Column<double>(type: "float", nullable: false),
                    Chest = table.Column<double>(type: "float", nullable: false),
                    Stomach = table.Column<double>(type: "float", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Hips = table.Column<double>(type: "float", nullable: false),
                    R_S = table.Column<double>(type: "float", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Top", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trouser",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Waist = table.Column<double>(type: "float", nullable: false),
                    Thigh = table.Column<double>(type: "float", nullable: false),
                    Sit = table.Column<double>(type: "float", nullable: false),
                    Bottom = table.Column<double>(type: "float", nullable: false),
                    Calf = table.Column<double>(type: "float", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trouser", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trousers",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trousers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopId = table.Column<long>(type: "bigint", nullable: false),
                    TrouserId = table.Column<long>(type: "bigint", nullable: false),
                    AgbadaId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Measurements_Agbada_AgbadaId",
                        column: x => x.AgbadaId,
                        principalTable: "Agbada",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Measurements_Top_TopId",
                        column: x => x.TopId,
                        principalTable: "Top",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Measurements_Trouser_TrouserId",
                        column: x => x.TrouserId,
                        principalTable: "Trouser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Description",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StyleId = table.Column<long>(type: "bigint", nullable: false),
                    CuffId = table.Column<long>(type: "bigint", nullable: false),
                    CuffsID = table.Column<long>(type: "bigint", nullable: true),
                    SleeveId = table.Column<long>(type: "bigint", nullable: false),
                    NeckId = table.Column<long>(type: "bigint", nullable: false),
                    FlapId = table.Column<long>(type: "bigint", nullable: false),
                    EmbroideryId = table.Column<long>(type: "bigint", nullable: false),
                    Underlay = table.Column<int>(type: "int", nullable: false),
                    MeasurementType = table.Column<int>(type: "int", nullable: false),
                    BackDetailing = table.Column<int>(type: "int", nullable: false),
                    ChestPocketId = table.Column<long>(type: "bigint", nullable: false),
                    SidePocket = table.Column<int>(type: "int", nullable: false),
                    TrousersId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Description", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Description_ChestPocket_ChestPocketId",
                        column: x => x.ChestPocketId,
                        principalTable: "ChestPocket",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Description_Cuffs_CuffsID",
                        column: x => x.CuffsID,
                        principalTable: "Cuffs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Description_Embroidery_EmbroideryId",
                        column: x => x.EmbroideryId,
                        principalTable: "Embroidery",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Description_Flap_FlapId",
                        column: x => x.FlapId,
                        principalTable: "Flap",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Description_Neck_NeckId",
                        column: x => x.NeckId,
                        principalTable: "Neck",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Description_Sleeve_SleeveId",
                        column: x => x.SleeveId,
                        principalTable: "Sleeve",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Description_Style_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Style",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Description_Trousers_TrousersId",
                        column: x => x.TrousersId,
                        principalTable: "Trousers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    DescriptionId = table.Column<long>(type: "bigint", nullable: false),
                    MeasurementId = table.Column<long>(type: "bigint", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Top = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Others = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fin_Button = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Description_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "Description",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Measurements_MeasurementId",
                        column: x => x.MeasurementId,
                        principalTable: "Measurements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Description_ChestPocketId",
                table: "Description",
                column: "ChestPocketId");

            migrationBuilder.CreateIndex(
                name: "IX_Description_CuffsID",
                table: "Description",
                column: "CuffsID");

            migrationBuilder.CreateIndex(
                name: "IX_Description_EmbroideryId",
                table: "Description",
                column: "EmbroideryId");

            migrationBuilder.CreateIndex(
                name: "IX_Description_FlapId",
                table: "Description",
                column: "FlapId");

            migrationBuilder.CreateIndex(
                name: "IX_Description_NeckId",
                table: "Description",
                column: "NeckId");

            migrationBuilder.CreateIndex(
                name: "IX_Description_SleeveId",
                table: "Description",
                column: "SleeveId");

            migrationBuilder.CreateIndex(
                name: "IX_Description_StyleId",
                table: "Description",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Description_TrousersId",
                table: "Description",
                column: "TrousersId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_AgbadaId",
                table: "Measurements",
                column: "AgbadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_TopId",
                table: "Measurements",
                column: "TopId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_TrouserId",
                table: "Measurements",
                column: "TrouserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_CustomerId",
                table: "WorkOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_DescriptionId",
                table: "WorkOrders",
                column: "DescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_MeasurementId",
                table: "WorkOrders",
                column: "MeasurementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WorkOrders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Description");

            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropTable(
                name: "ChestPocket");

            migrationBuilder.DropTable(
                name: "Cuffs");

            migrationBuilder.DropTable(
                name: "Embroidery");

            migrationBuilder.DropTable(
                name: "Flap");

            migrationBuilder.DropTable(
                name: "Neck");

            migrationBuilder.DropTable(
                name: "Sleeve");

            migrationBuilder.DropTable(
                name: "Style");

            migrationBuilder.DropTable(
                name: "Trousers");

            migrationBuilder.DropTable(
                name: "Agbada");

            migrationBuilder.DropTable(
                name: "Top");

            migrationBuilder.DropTable(
                name: "Trouser");
        }
    }
}
