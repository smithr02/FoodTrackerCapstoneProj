using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitTrackerCapStone.Data.Migrations
{
    public partial class Dbsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79ddf8ea-46f9-4bb9-9e9d-bc2e2ea0c83b");

            migrationBuilder.CreateTable(
                name: "Diets",
                columns: table => new
                {
                    DietId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.DietId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true),
                    DietId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "DietId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    MealId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.MealId);
                    table.ForeignKey(
                        name: "FK_Meals_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "DietId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    FoodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealsID = table.Column<int>(nullable: false),
                    food_name = table.Column<string>(nullable: true),
                    brand_name = table.Column<string>(nullable: true),
                    serving_qty = table.Column<int>(nullable: false),
                    serving_unit = table.Column<string>(nullable: true),
                    serving_weight_grams = table.Column<float>(nullable: false),
                    nf_calories = table.Column<float>(nullable: false),
                    nf_total_fat = table.Column<float>(nullable: false),
                    nf_saturated_fat = table.Column<float>(nullable: false),
                    nf_cholesterol = table.Column<float>(nullable: false),
                    nf_sodium = table.Column<float>(nullable: false),
                    nf_total_carbohydrate = table.Column<float>(nullable: false),
                    nf_dietary_fiber = table.Column<float>(nullable: false),
                    nf_sugars = table.Column<float>(nullable: false),
                    nf_protein = table.Column<float>(nullable: false),
                    nf_potassium = table.Column<float>(nullable: false),
                    nf_p = table.Column<float>(nullable: false),
                    full_nutrientsID = table.Column<int>(nullable: false),
                    nix_brand_name = table.Column<string>(nullable: true),
                    nix_brand_id = table.Column<string>(nullable: true),
                    nix_item_name = table.Column<string>(nullable: true),
                    nix_item_id = table.Column<string>(nullable: true),
                    upc = table.Column<string>(nullable: true),
                    consumed_at = table.Column<DateTime>(nullable: false),
                    source = table.Column<int>(nullable: false),
                    ndb_no = table.Column<int>(nullable: false),
                    tagsID = table.Column<int>(nullable: false),
                    alt_measuresID = table.Column<int>(nullable: false),
                    lat = table.Column<string>(nullable: true),
                    lng = table.Column<string>(nullable: true),
                    meal_type = table.Column<int>(nullable: false),
                    photoID = table.Column<int>(nullable: false),
                    sub_recipe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.FoodId);
                    table.ForeignKey(
                        name: "FK_Foods_Meals_MealsID",
                        column: x => x.MealsID,
                        principalTable: "Meals",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alt_Measures",
                columns: table => new
                {
                    Alt_MeasuresID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    foodID = table.Column<int>(nullable: false),
                    serving_weight = table.Column<float>(nullable: false),
                    measure = table.Column<string>(nullable: true),
                    seq = table.Column<int>(nullable: true),
                    qty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alt_Measures", x => x.Alt_MeasuresID);
                    table.ForeignKey(
                        name: "FK_Alt_Measures_Foods_foodID",
                        column: x => x.foodID,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Full_Nutrients",
                columns: table => new
                {
                    Full_NutrientsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    foodId = table.Column<int>(nullable: false),
                    attr_id = table.Column<int>(nullable: false),
                    value = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Full_Nutrients", x => x.Full_NutrientsID);
                    table.ForeignKey(
                        name: "FK_Full_Nutrients_Foods_foodId",
                        column: x => x.foodId,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Metadata",
                columns: table => new
                {
                    metaDataID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    is_raw_food = table.Column<bool>(nullable: false),
                    FoodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metadata", x => x.metaDataID);
                    table.ForeignKey(
                        name: "FK_Metadata_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    photoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    foodID = table.Column<int>(nullable: false),
                    thumb = table.Column<string>(nullable: true),
                    highres = table.Column<string>(nullable: true),
                    is_user_uploaded = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.photoID);
                    table.ForeignKey(
                        name: "FK_Photo_Foods_foodID",
                        column: x => x.foodID,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodId = table.Column<int>(nullable: false),
                    item = table.Column<string>(nullable: true),
                    measure = table.Column<string>(nullable: true),
                    quantity = table.Column<string>(nullable: true),
                    food_group = table.Column<int>(nullable: false),
                    tag_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                    table.ForeignKey(
                        name: "FK_Tags_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "edf29ae9-ad37-4511-88ef-905037225de9", "ece829be-4f8d-4627-a9ad-e09f56ad9f41", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Alt_Measures_foodID",
                table: "Alt_Measures",
                column: "foodID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DietId",
                table: "Customers",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdentityUserId",
                table: "Customers",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_MealsID",
                table: "Foods",
                column: "MealsID");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_alt_measuresID",
                table: "Foods",
                column: "alt_measuresID");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_full_nutrientsID",
                table: "Foods",
                column: "full_nutrientsID");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_photoID",
                table: "Foods",
                column: "photoID");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_tagsID",
                table: "Foods",
                column: "tagsID");

            migrationBuilder.CreateIndex(
                name: "IX_Full_Nutrients_foodId",
                table: "Full_Nutrients",
                column: "foodId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_DietId",
                table: "Meals",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_Metadata_FoodId",
                table: "Metadata",
                column: "FoodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_foodID",
                table: "Photo",
                column: "foodID");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_FoodId",
                table: "Tags",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Alt_Measures_alt_measuresID",
                table: "Foods",
                column: "alt_measuresID",
                principalTable: "Alt_Measures",
                principalColumn: "Alt_MeasuresID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Full_Nutrients_full_nutrientsID",
                table: "Foods",
                column: "full_nutrientsID",
                principalTable: "Full_Nutrients",
                principalColumn: "Full_NutrientsID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Photo_photoID",
                table: "Foods",
                column: "photoID",
                principalTable: "Photo",
                principalColumn: "photoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Tags_tagsID",
                table: "Foods",
                column: "tagsID",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alt_Measures_Foods_foodID",
                table: "Alt_Measures");

            migrationBuilder.DropForeignKey(
                name: "FK_Full_Nutrients_Foods_foodId",
                table: "Full_Nutrients");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Foods_foodID",
                table: "Photo");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Foods_FoodId",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Metadata");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Alt_Measures");

            migrationBuilder.DropTable(
                name: "Full_Nutrients");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edf29ae9-ad37-4511-88ef-905037225de9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "79ddf8ea-46f9-4bb9-9e9d-bc2e2ea0c83b", "c9b3b010-b3d8-4026-9110-307dd24980c3", "Admin", "ADMIN" });
        }
    }
}
