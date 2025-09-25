using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newRecipe", menuName = "ScriptableObject/Recipe")]
public class Recipe : ScriptableObject
{
    [SerializeField] private List<Ingredient> ingredients;
    public List<Ingredient> Ingredients{ get { return ingredients; } }

    [SerializeField] private GameObject recipeResult;
    public GameObject RecipeResult { get { return recipeResult; } }
}


