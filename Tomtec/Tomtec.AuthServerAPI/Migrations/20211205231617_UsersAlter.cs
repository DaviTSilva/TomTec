using Microsoft.EntityFrameworkCore.Migrations;

namespace Tomtec.AuthServerAPI.Migrations
{
    public partial class UsersAlter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRikes_Roles_RoleId",
                table: "UserRikes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRikes_Users_UserId",
                table: "UserRikes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Addresses_AddressId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTypes",
                table: "UserTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRikes",
                table: "UserRikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "UserTypes",
                newName: "UserType");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "UserRikes",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_UserTypes_Name",
                table: "UserType",
                newName: "IX_UserType_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email_UserName",
                table: "User",
                newName: "IX_User_Email_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserTypeId",
                table: "User",
                newName: "IX_User_UserTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_AddressId",
                table: "User",
                newName: "IX_User_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRikes_RoleId",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_Name",
                table: "Role",
                newName: "IX_Role_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserType",
                table: "UserType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Address_AddressId",
                table: "User",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserType_UserTypeId",
                table: "User",
                column: "UserTypeId",
                principalTable: "UserType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Role_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_User_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Address_AddressId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserType_UserTypeId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Role_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_User_UserId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserType",
                table: "UserType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "UserType",
                newName: "UserTypes");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "UserRikes");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_UserType_Name",
                table: "UserTypes",
                newName: "IX_UserTypes_Name");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRikes",
                newName: "IX_UserRikes_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Email_UserName",
                table: "Users",
                newName: "IX_Users_Email_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_User_UserTypeId",
                table: "Users",
                newName: "IX_Users_UserTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_User_AddressId",
                table: "Users",
                newName: "IX_Users_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Role_Name",
                table: "Roles",
                newName: "IX_Roles_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTypes",
                table: "UserTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRikes",
                table: "UserRikes",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRikes_Roles_RoleId",
                table: "UserRikes",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRikes_Users_UserId",
                table: "UserRikes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Addresses_AddressId",
                table: "Users",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
