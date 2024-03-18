using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSG.Service.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Nueva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SecundName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FirstLastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SecundLastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
