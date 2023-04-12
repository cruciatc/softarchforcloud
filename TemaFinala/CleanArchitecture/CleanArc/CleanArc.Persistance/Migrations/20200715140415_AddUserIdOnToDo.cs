using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArc.Persistance.Migrations
{
    public partial class AddUserIdOnToDo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ToDos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            #region ***Cornel***

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Person",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            #endregion ***Cornel***
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ToDos");

            #region ***Cornel***

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Person");

            #endregion ***Cornel***
        }
    }
}
