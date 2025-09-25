using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    private static RecipeManager s_instance;
    public static RecipeManager Instance { get { return s_instance; } }

    [SerializeField] private List<Recipe> recipes = new();
    [SerializeField] private GameObject defaultResult;

    private void Awake()
    {
        if (s_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            s_instance = this;
        }
    }

    public GameObject ProcessIngredients(params Ingredient[] ingredients)
    {
        List<Recipe> recipesKept = new();
        List<Ingredient> ingredientsToProcess = new List<Ingredient>(ingredients);

        foreach(Recipe recipe in recipes)
        {
            if(recipe.Ingredients.Count == ingredientsToProcess.Count) recipesKept.Add(recipe);
        }

        int i = 0;
        bool recipeFound = false;

        GameObject recipeResult = defaultResult;

        while (i < recipesKept.Count && !recipeFound)
        {
            recipeFound = true;

            for (int j = 0; j < recipesKept[i].Ingredients.Count && recipeFound; j++) 
            {
                if (!ingredientsToProcess.Contains(recipesKept[i].Ingredients[j])) recipeFound = false;
            }

            if(recipeFound) recipeResult = recipesKept[i].RecipeResult;

            i++;
        }

        return recipeResult;
    }
}
