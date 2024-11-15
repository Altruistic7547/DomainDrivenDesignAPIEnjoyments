using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingModel3dModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projects_projectStatuses_StatusId",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "FK_projectTasks_projectTaskStatuses_StatusId",
                table: "projectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_projectTasks_projects_ProjectId",
                table: "projectTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_projectTaskStatuses",
                table: "projectTaskStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_projectTasks",
                table: "projectTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_projectStatuses",
                table: "projectStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_projects",
                table: "projects");

            migrationBuilder.RenameTable(
                name: "projectTaskStatuses",
                newName: "ProjectTaskStatuses");

            migrationBuilder.RenameTable(
                name: "projectTasks",
                newName: "ProjectTasks");

            migrationBuilder.RenameTable(
                name: "projectStatuses",
                newName: "ProjectStatuses");

            migrationBuilder.RenameTable(
                name: "projects",
                newName: "Projects");

            migrationBuilder.RenameIndex(
                name: "IX_projectTasks_StatusId",
                table: "ProjectTasks",
                newName: "IX_ProjectTasks_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_projectTasks_ProjectId",
                table: "ProjectTasks",
                newName: "IX_ProjectTasks_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_projects_StatusId",
                table: "Projects",
                newName: "IX_Projects_StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTaskStatuses",
                table: "ProjectTaskStatuses",
                column: "StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTasks",
                table: "ProjectTasks",
                column: "TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectStatuses",
                table: "ProjectStatuses",
                column: "StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "ProjectId");

            migrationBuilder.CreateTable(
                name: "Model3Ds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolygoneCount = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsValidated = table.Column<bool>(type: "bit", nullable: false),
                    CreationDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model3Ds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "model3DTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_model3DTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Model3DModel3DTag",
                columns: table => new
                {
                    TagsId = table.Column<int>(type: "int", nullable: false),
                    model3DsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model3DModel3DTag", x => new { x.TagsId, x.model3DsId });
                    table.ForeignKey(
                        name: "FK_Model3DModel3DTag_Model3Ds_model3DsId",
                        column: x => x.model3DsId,
                        principalTable: "Model3Ds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Model3DModel3DTag_model3DTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "model3DTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Model3DModel3DTag_model3DsId",
                table: "Model3DModel3DTag",
                column: "model3DsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectStatuses_StatusId",
                table: "Projects",
                column: "StatusId",
                principalTable: "ProjectStatuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_ProjectTaskStatuses_StatusId",
                table: "ProjectTasks",
                column: "StatusId",
                principalTable: "ProjectTaskStatuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectId",
                table: "ProjectTasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectStatuses_StatusId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_ProjectTaskStatuses_StatusId",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectId",
                table: "ProjectTasks");

            migrationBuilder.DropTable(
                name: "Model3DModel3DTag");

            migrationBuilder.DropTable(
                name: "Model3Ds");

            migrationBuilder.DropTable(
                name: "model3DTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTaskStatuses",
                table: "ProjectTaskStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTasks",
                table: "ProjectTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectStatuses",
                table: "ProjectStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "ProjectTaskStatuses",
                newName: "projectTaskStatuses");

            migrationBuilder.RenameTable(
                name: "ProjectTasks",
                newName: "projectTasks");

            migrationBuilder.RenameTable(
                name: "ProjectStatuses",
                newName: "projectStatuses");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "projects");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTasks_StatusId",
                table: "projectTasks",
                newName: "IX_projectTasks_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTasks_ProjectId",
                table: "projectTasks",
                newName: "IX_projectTasks_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_StatusId",
                table: "projects",
                newName: "IX_projects_StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_projectTaskStatuses",
                table: "projectTaskStatuses",
                column: "StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_projectTasks",
                table: "projectTasks",
                column: "TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_projectStatuses",
                table: "projectStatuses",
                column: "StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_projects",
                table: "projects",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_projectStatuses_StatusId",
                table: "projects",
                column: "StatusId",
                principalTable: "projectStatuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_projectTasks_projectTaskStatuses_StatusId",
                table: "projectTasks",
                column: "StatusId",
                principalTable: "projectTaskStatuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_projectTasks_projects_ProjectId",
                table: "projectTasks",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
