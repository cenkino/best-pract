using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task2.Repository.Migrations
{
    public partial class updateseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CreatedDate", "Name", "Picture", "Price" },
                values: new object[] { 1, "HP1", new DateTime(2023, 10, 2, 17, 25, 55, 831, DateTimeKind.Local).AddTicks(8786), "HP", "/Images/laptop.jpg", 590m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CreatedDate", "Name", "Picture", "Price" },
                values: new object[] { 2, "LEN1", new DateTime(2023, 10, 2, 17, 25, 55, 831, DateTimeKind.Local).AddTicks(8802), "Lenovo", "/Images/laptop.jpg", 640m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CreatedDate", "Name", "Picture", "Price" },
                values: new object[] { 3, "ASUS1", new DateTime(2023, 10, 2, 17, 25, 55, 831, DateTimeKind.Local).AddTicks(8804), "Asus", "/Images/laptop.jpg", 750m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
