﻿using FitTrackerCapStone;
using FitTrackerCapStone.Data;
using FitTrackerCapStone.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitTrackerCapStone
{
    public class Meal 
    { 
        [Key]
        public int MealId { get; set; }
        public Food[] Foods { get; set; }

        [ForeignKey("Customer")]
        public int customerId { get; set; }
        public Customer Customer { get; set; }

    }
 
}

public class Food
{
    [Key]
    public int FoodId { get; set; }

    [ForeignKey("Meal")]
    public int MealsID { get; set; }
    public Meal Meal { get; set; }

    public string food_name { get; set; }
    public string brand_name { get; set; }
    public int serving_qty { get; set; }
    public string serving_unit { get; set; }
    public float serving_weight_grams { get; set; }
    public float nf_calories { get; set; }
    public float nf_total_fat { get; set; }
    public float nf_saturated_fat { get; set; }
    public float nf_cholesterol { get; set; }
    public float nf_sodium { get; set; }
    public float nf_total_carbohydrate { get; set; }
    public float nf_dietary_fiber { get; set; }
    public float nf_sugars { get; set; }
    public float nf_protein { get; set; }
    public float nf_potassium { get; set; }
    public float nf_p { get; set; }

    [ForeignKey("full_nutrients")]
    public int full_nutrientsID { get; set; }

    public Full_Nutrients full_nutrients { get; set; }
    public string nix_brand_name { get; set; }
    public string nix_brand_id { get; set; }
    public string nix_item_name { get; set; }
    public string nix_item_id { get; set; }
    public string upc { get; set; }
    public DateTime consumed_at { get; set; }
    public Metadata metadata { get; set; }
    public int source { get; set; }
    public int ndb_no { get; set; }
    [ForeignKey("tags")]
    public int tagsID { get; set; }
    public Tags tags { get; set; }
    [ForeignKey("alt_measures")]
    public int alt_measuresID { get; set; }
    public Alt_Measures alt_measures { get; set; }
    public string lat { get; set; }
    public string lng { get; set; }
    public int meal_type { get; set; }
    [ForeignKey("photo")]
    public int photoID { get; set; }
    public Photo photo { get; set; }
    public string sub_recipe { get; set; }
}

public class Metadata
{
    [Key]
    public int metaDataID { get; set; }
    public bool is_raw_food { get; set; }

    [ForeignKey("Food")]
    public int FoodId { get; set; }
    public Food Food { get; set; }
}

public class Tags
{
    [Key]
    public int TagId { get; set; }

    [ForeignKey("Food")]
    public int FoodId { get; set; }
    public Food Food { get; set; }

    public string item { get; set; }
    public string measure { get; set; }
    public string quantity { get; set; }
    public int food_group { get; set; }
    public int tag_id { get; set; }
}

public class Photo
{
    [Key]
    public int photoID { get; set; }

    [ForeignKey("food")]
    public int foodID { get; set; }
    public Food food { get; set; }
    public string thumb { get; set; }
    public string highres { get; set; }
    public bool is_user_uploaded { get; set; }
}

public class Full_Nutrients
{
    [Key]
    public int Full_NutrientsID { get; set; }

    [ForeignKey("food")]
    public int foodId { get; set; }
    public Food food { get; set; }
    public int attr_id { get; set; }
    public float value { get; set; }
}

public class Alt_Measures
{
    [Key]
    public int Alt_MeasuresID { get; set; }

    [ForeignKey("food")]
    public int foodID { get; set; }
    public Food food { get; set; }
    public float serving_weight { get; set; }
    public string measure { get; set; }
    public int? seq { get; set; }
    public int qty { get; set; }
}
public class Kitchen
{

    private readonly ApplicationDbContext _context;
    public Kitchen(ApplicationDbContext context)
    {
        _context = context;
    }
    public  Meal ReturnFoods(JToken foods)
    {
        Alt_Measures alt_Measures;
        Full_Nutrients full_Nutrients;
        Photo photo;
        Tags tags;
        Meal meal = new Meal();
        Food foodOutput;
        //int alt_measuresId = alt_Measures.Alt_MeasuresID;
        //int foodId = food.FoodId;
        //int full_NutrientsId = full_Nutrients.Full_NutrientsID;
        //int photoId = photo.photoID;
        _context.Meals.Add(meal);
        _context.SaveChanges();
        int mealId = meal.MealId;
        foreach ( var food in foods)
        {
            foodOutput = new Food();
            foodOutput.MealsID = mealId;
            foodOutput.Meal = meal;
            foodOutput.food_name = food["food_name"];
            foodOutput.brand_name = food["brand_name"];
            foodOutput.serving_qty = food["serving_qty"];
            foodOutput.serving_unit = food["serving_unit"];
            foodOutput.serving_weight_grams = food["serving_weight_grams"];
            foodOutput.nf_calories = food["nf_calories"];
            foodOutput.nf_total_fat = food["nf_total_fat"];
            foodOutput.nf_saturated_fat = food["nf_saturated_fat"];
            foodOutput.nf_cholesterol = food["nf_cholesterol"];
            foodOutput.nf_sodium = food["nf_sodium"];
            foodOutput.nf_total_carbohydrate = food["nf_total_carbohydrate"];
            foodOutput.nf_dietary_fiber = food["nf_dietary_fiber"];
            foodOutput.nf_sugars = food["nf_sugars"];
            foodOutput.nf_protein = food["nf_protein"];
            foodOutput.nf_potassium = food["nf_potassium"];

            foodOutput.full_nutrients = food["full_nutrients"];



           var something = food;

        }


        return meal;
    }
    
}