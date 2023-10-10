﻿using System;
using System.Collections.Generic;

public class Recipe
{
    public string Name { get; set; }
    public List<string> Ingredients { get; set; }

    public Recipe(string name, List<string> ingredients)
    {
        this.Name = name;
        this.Ingredients = ingredients;
    }
}

public class RecipeManagementSystem
{
    public static Recipe SearchRecipeWithIngredient(List<Recipe> recipeList, string ingredient)
    {        
        foreach(Recipe recipe in recipeList)
        {
            foreach(string RecipeIngredient in recipe.Ingredients)
            {
                if(RecipeIngredient.Contains(ingredient))
                {
                    return recipe;
                }
            }
        }


        return null; // return null if recipe not found
    }
}

public class Program
{    
    public static void Main(string[] args)
    {
        List<Recipe> recipeList = new List<Recipe>();

        Recipe padThaiRecipe = new Recipe(
            "Pad Thai Noodles",
            new List<string>
            {
                "200g flat rice noodles",
                "150g firm tofu, cubed",
                "2 eggs, beaten",
                "3 tablespoons Pad Thai sauce"
            }
        );

        Recipe tomYumRecipe = new Recipe(
            "Tom Yum Soup",
            new List<string>
            {
                "500ml chicken or vegetable broth",
                "200g shrimp, peeled and deveined",
                "200g mushrooms, sliced",
                "2-3 tablespoons Tom Yum paste"
            }
        );
        
        recipeList.Add(padThaiRecipe);
        recipeList.Add(tomYumRecipe);

        Recipe recipeWithTofu = RecipeManagementSystem.SearchRecipeWithIngredient(recipeList, "tofu");
        if(recipeWithTofu == null) {
            Console.WriteLine("Recipe with tofu not found");
        } else {
            Console.WriteLine(recipeWithTofu.Name);
        }

        Recipe recipeWithTruffle = RecipeManagementSystem.SearchRecipeWithIngredient(recipeList, "truffle");
        if(recipeWithTruffle == null) {
            Console.WriteLine("Recipe with truffle not found");
        } else {
            Console.WriteLine(recipeWithTruffle.Name);
        }
    }
}