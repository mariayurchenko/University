using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    COURSE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.COURSE_ID);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GROUP_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    COURSE_ID = table.Column<int>(nullable: false),
                    NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GROUP_ID);
                    table.ForeignKey(
                        name: "FK_Group_Course_COURSE_ID",
                        column: x => x.COURSE_ID,
                        principalTable: "Course",
                        principalColumn: "COURSE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    STUDENT_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GROUP_ID = table.Column<int>(nullable: false),
                    FIRST_NAME = table.Column<string>(nullable: true),
                    LAST_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.STUDENT_ID);
                    table.ForeignKey(
                        name: "FK_Student_Group_GROUP_ID",
                        column: x => x.GROUP_ID,
                        principalTable: "Group",
                        principalColumn: "GROUP_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Group_COURSE_ID",
                table: "Group",
                column: "COURSE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_GROUP_ID",
                table: "Student",
                column: "GROUP_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
