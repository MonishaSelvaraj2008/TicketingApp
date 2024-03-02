using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class dbcreatiionn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "varchar(250)", nullable: true),
                    Email = table.Column<string>(type: "varchar(250)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", nullable: true),
                    Mobile = table.Column<string>(type: "varchar(20)", nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bug",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(250)", nullable: true),
                    Environment = table.Column<string>(type: "varchar(50)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Responsible = table.Column<int>(type: "int", nullable: false),
                    Regression = table.Column<bool>(type: "bit", nullable: false),
                    FixedID = table.Column<string>(type: "varchar(50)", nullable: true),
                    NotFixedReason = table.Column<string>(type: "varchar(250)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "varchar(250)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bug", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bug_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Bug_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Bug_Users_Responsible",
                        column: x => x.Responsible,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSupport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Responsible = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "varchar(250)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "varchar(250)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSupport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerSupport_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CustomerSupport_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CustomerSupport_Users_Responsible",
                        column: x => x.Responsible,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserStory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Responsible = table.Column<int>(type: "int", nullable: false),
                    StoryPoint = table.Column<int>(type: "int", nullable: false),
                    AcceptanceCriteria = table.Column<string>(type: "varchar(250)", nullable: true),
                    Description = table.Column<string>(type: "varchar(250)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "varchar(250)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserStory_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserStory_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserStory_Users_Responsible",
                        column: x => x.Responsible,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BugHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BugId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(250)", nullable: true),
                    Environment = table.Column<string>(type: "varchar(50)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Responsible = table.Column<int>(type: "int", nullable: false),
                    Regression = table.Column<bool>(type: "bit", nullable: false),
                    FixedID = table.Column<string>(type: "varchar(50)", nullable: true),
                    NotFixedReason = table.Column<string>(type: "varchar(250)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "varchar(250)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BugHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BugHistory_Bug_BugId",
                        column: x => x.BugId,
                        principalTable: "Bug",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSupportHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerSupportId = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "varchar(250)", nullable: true),
                    Responsible = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "varchar(250)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSupportHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerSupportHistory_CustomerSupport_CustomerSupportId",
                        column: x => x.CustomerSupportId,
                        principalTable: "CustomerSupport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserStoryHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserStoryId = table.Column<int>(type: "int", nullable: false),
                    Responsible = table.Column<int>(type: "int", nullable: false),
                    StoryPoint = table.Column<int>(type: "int", nullable: false),
                    AcceptanceCriteria = table.Column<string>(type: "varchar(250)", nullable: true),
                    Description = table.Column<string>(type: "varchar(250)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "varchar(250)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStoryHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserStoryHistory_UserStory_UserStoryId",
                        column: x => x.UserStoryId,
                        principalTable: "UserStory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bug_CreatedBy",
                table: "Bug",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Bug_Responsible",
                table: "Bug",
                column: "Responsible");

            migrationBuilder.CreateIndex(
                name: "IX_Bug_StatusId",
                table: "Bug",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BugHistory_BugId",
                table: "BugHistory",
                column: "BugId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSupport_CreatedBy",
                table: "CustomerSupport",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSupport_Responsible",
                table: "CustomerSupport",
                column: "Responsible");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSupport_StatusId",
                table: "CustomerSupport",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSupportHistory_CustomerSupportId",
                table: "CustomerSupportHistory",
                column: "CustomerSupportId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStory_CreatedBy",
                table: "UserStory",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserStory_Responsible",
                table: "UserStory",
                column: "Responsible");

            migrationBuilder.CreateIndex(
                name: "IX_UserStory_StatusId",
                table: "UserStory",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStoryHistory_UserStoryId",
                table: "UserStoryHistory",
                column: "UserStoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BugHistory");

            migrationBuilder.DropTable(
                name: "CustomerDetails");

            migrationBuilder.DropTable(
                name: "CustomerSupportHistory");

            migrationBuilder.DropTable(
                name: "UserStoryHistory");

            migrationBuilder.DropTable(
                name: "Bug");

            migrationBuilder.DropTable(
                name: "CustomerSupport");

            migrationBuilder.DropTable(
                name: "UserStory");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
