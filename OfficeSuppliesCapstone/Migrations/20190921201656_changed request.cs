using Microsoft.EntityFrameworkCore.Migrations;

namespace OfficeSuppliesCapstone.Migrations
{
    public partial class changedrequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK__RequestId",
                table: "RequestLine");

            migrationBuilder.DropIndex(
                name: "IX_Vendor_1",
                table: "Vendor");

            migrationBuilder.DropIndex(
                name: "IX_Vendor",
                table: "Vendor");

            migrationBuilder.DropIndex(
                name: "IX_User",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Product",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_1",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "Users",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "Users",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "RequestLine",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "((1))");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Request",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(11, 2)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Request",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldDefaultValueSql: "(N'NEW')");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryMode",
                table: "Request",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldDefaultValueSql: "(N'Pick Up')");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Product",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(11, 2)");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Users_UserId",
                table: "Request",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestLine_Request_RequestId",
                table: "RequestLine",
                column: "RequestId",
                principalTable: "Request",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Users_UserId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestLine_Request_RequestId",
                table: "RequestLine");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "Users",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "Users",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "RequestLine",
                nullable: false,
                defaultValueSql: "((1))",
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Request",
                type: "decimal(11, 2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Request",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "(N'NEW')",
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryMode",
                table: "Request",
                maxLength: 20,
                nullable: false,
                defaultValueSql: "(N'Pick Up')",
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "decimal(11, 2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_1",
                table: "Vendor",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendor",
                table: "Vendor",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User",
                table: "Users",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product",
                table: "Product",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_1",
                table: "Product",
                column: "PartNbr",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserId",
                table: "Request",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__RequestId",
                table: "RequestLine",
                column: "RequestId",
                principalTable: "Request",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
