using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class GpuAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BoostClock",
                table: "Attributes",
                newName: "GpuCoreClockGpu");

            migrationBuilder.RenameColumn(
                name: "BaseClock",
                table: "Attributes",
                newName: "BoostClockGpu");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Attributes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "BaseClockCpu",
                table: "Attributes",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "BoostClockCpu",
                table: "Attributes",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Attributes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cooler",
                table: "Attributes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayPort",
                table: "Attributes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HDMI",
                table: "Attributes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interface",
                table: "Attributes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxGPULength",
                table: "Attributes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Memory",
                table: "Attributes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemoryInterface",
                table: "Attributes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemoryType",
                table: "Attributes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PowerConnector",
                table: "Attributes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecommendedPSU",
                table: "Attributes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SlotWidth",
                table: "Attributes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreamProcessors",
                table: "Attributes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseClockCpu",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "BoostClockCpu",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "Cooler",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "DisplayPort",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "HDMI",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "Interface",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "MaxGPULength",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "Memory",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "MemoryInterface",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "MemoryType",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "PowerConnector",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "RecommendedPSU",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "SlotWidth",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "StreamProcessors",
                table: "Attributes");

            migrationBuilder.RenameColumn(
                name: "GpuCoreClockGpu",
                table: "Attributes",
                newName: "BoostClock");

            migrationBuilder.RenameColumn(
                name: "BoostClockGpu",
                table: "Attributes",
                newName: "BaseClock");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Attributes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
