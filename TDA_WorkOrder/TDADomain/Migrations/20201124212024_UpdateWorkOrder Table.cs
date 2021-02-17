using Microsoft.EntityFrameworkCore.Migrations;

namespace TDADomain.Migrations
{
    public partial class UpdateWorkOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Description_ChestPocket_ChestPocketId",
                table: "Description");

            migrationBuilder.DropForeignKey(
                name: "FK_Description_Cuffs_CuffsID",
                table: "Description");

            migrationBuilder.DropForeignKey(
                name: "FK_Description_Embroidery_EmbroideryId",
                table: "Description");

            migrationBuilder.DropForeignKey(
                name: "FK_Description_Flap_FlapId",
                table: "Description");

            migrationBuilder.DropForeignKey(
                name: "FK_Description_Neck_NeckId",
                table: "Description");

            migrationBuilder.DropForeignKey(
                name: "FK_Description_Sleeve_SleeveId",
                table: "Description");

            migrationBuilder.DropForeignKey(
                name: "FK_Description_Style_StyleId",
                table: "Description");

            migrationBuilder.DropForeignKey(
                name: "FK_Description_Trousers_TrousersId",
                table: "Description");

            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Agbada_AgbadaId",
                table: "Measurements");

            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Top_TopId",
                table: "Measurements");

            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Trouser_TrouserId",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_AgbadaId",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_TopId",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_TrouserId",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Description_ChestPocketId",
                table: "Description");

            migrationBuilder.DropIndex(
                name: "IX_Description_CuffsID",
                table: "Description");

            migrationBuilder.DropIndex(
                name: "IX_Description_EmbroideryId",
                table: "Description");

            migrationBuilder.DropIndex(
                name: "IX_Description_FlapId",
                table: "Description");

            migrationBuilder.DropIndex(
                name: "IX_Description_NeckId",
                table: "Description");

            migrationBuilder.DropIndex(
                name: "IX_Description_SleeveId",
                table: "Description");

            migrationBuilder.DropIndex(
                name: "IX_Description_StyleId",
                table: "Description");

            migrationBuilder.DropIndex(
                name: "IX_Description_TrousersId",
                table: "Description");

            migrationBuilder.DropColumn(
                name: "AgbadaId",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "TopId",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "TrouserId",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "ChestPocketId",
                table: "Description");

            migrationBuilder.DropColumn(
                name: "CuffId",
                table: "Description");

            migrationBuilder.DropColumn(
                name: "CuffsID",
                table: "Description");

            migrationBuilder.DropColumn(
                name: "EmbroideryId",
                table: "Description");

            migrationBuilder.DropColumn(
                name: "FlapId",
                table: "Description");

            migrationBuilder.DropColumn(
                name: "NeckId",
                table: "Description");

            migrationBuilder.DropColumn(
                name: "SleeveId",
                table: "Description");

            migrationBuilder.DropColumn(
                name: "StyleId",
                table: "Description");

            migrationBuilder.DropColumn(
                name: "TrousersId",
                table: "Description");

            migrationBuilder.AddColumn<double>(
                name: "AgbadaLength",
                table: "Measurements",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AgbadaWidth",
                table: "Measurements",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Back",
                table: "Measurements",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Bottom",
                table: "Measurements",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Calf",
                table: "Measurements",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Chest",
                table: "Measurements",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Hand",
                table: "Measurements",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Head",
                table: "Measurements",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Hips",
                table: "Measurements",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Neck",
                table: "Measurements",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "R_S",
                table: "Measurements",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Sit",
                table: "Measurements",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Stomach",
                table: "Measurements",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Thigh",
                table: "Measurements",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TopLength",
                table: "Measurements",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TrouserLength",
                table: "Measurements",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Waist",
                table: "Measurements",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Underlay",
                table: "Description",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "SidePocket",
                table: "Description",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "MeasurementType",
                table: "Description",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BackDetailing",
                table: "Description",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ChestPocket",
                table: "Description",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cuffs",
                table: "Description",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Embroidery",
                table: "Description",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Flap",
                table: "Description",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Neck",
                table: "Description",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sleeve",
                table: "Description",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Style",
                table: "Description",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Trousers",
                table: "Description",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgbadaLength",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "AgbadaWidth",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Back",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Bottom",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Calf",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Chest",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Hand",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Head",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Hips",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Neck",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "R_S",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Sit",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Stomach",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Thigh",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "TopLength",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "TrouserLength",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Waist",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "ChestPocket",
                table: "Description");

            migrationBuilder.DropColumn(
                name: "Cuffs",
                table: "Description");

            migrationBuilder.DropColumn(
                name: "Embroidery",
                table: "Description");

            migrationBuilder.DropColumn(
                name: "Flap",
                table: "Description");

            migrationBuilder.DropColumn(
                name: "Neck",
                table: "Description");

            migrationBuilder.DropColumn(
                name: "Sleeve",
                table: "Description");

            migrationBuilder.DropColumn(
                name: "Style",
                table: "Description");

            migrationBuilder.DropColumn(
                name: "Trousers",
                table: "Description");

            migrationBuilder.AddColumn<long>(
                name: "AgbadaId",
                table: "Measurements",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TopId",
                table: "Measurements",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TrouserId",
                table: "Measurements",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<int>(
                name: "Underlay",
                table: "Description",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SidePocket",
                table: "Description",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MeasurementType",
                table: "Description",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BackDetailing",
                table: "Description",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ChestPocketId",
                table: "Description",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CuffId",
                table: "Description",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CuffsID",
                table: "Description",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EmbroideryId",
                table: "Description",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "FlapId",
                table: "Description",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "NeckId",
                table: "Description",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SleeveId",
                table: "Description",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "StyleId",
                table: "Description",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TrousersId",
                table: "Description",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Description_ChestPocket_ChestPocketId",
                table: "Description",
                column: "ChestPocketId",
                principalTable: "ChestPocket",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Description_Cuffs_CuffsID",
                table: "Description",
                column: "CuffsID",
                principalTable: "Cuffs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Description_Embroidery_EmbroideryId",
                table: "Description",
                column: "EmbroideryId",
                principalTable: "Embroidery",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Description_Flap_FlapId",
                table: "Description",
                column: "FlapId",
                principalTable: "Flap",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Description_Neck_NeckId",
                table: "Description",
                column: "NeckId",
                principalTable: "Neck",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Description_Sleeve_SleeveId",
                table: "Description",
                column: "SleeveId",
                principalTable: "Sleeve",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Description_Style_StyleId",
                table: "Description",
                column: "StyleId",
                principalTable: "Style",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Description_Trousers_TrousersId",
                table: "Description",
                column: "TrousersId",
                principalTable: "Trousers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Agbada_AgbadaId",
                table: "Measurements",
                column: "AgbadaId",
                principalTable: "Agbada",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Top_TopId",
                table: "Measurements",
                column: "TopId",
                principalTable: "Top",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Trouser_TrouserId",
                table: "Measurements",
                column: "TrouserId",
                principalTable: "Trouser",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
