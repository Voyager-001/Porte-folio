using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [SerializeField] private int nbOfMixRequired;
    [SerializeField] private int maxIngredients;
    [SerializeField] private Transform _spawnTransform;
    private int currentMixNb;

    private List<Ingredient> ingredient;
    [SerializeField] private Renderer _gaugeRenderer;
    private MaterialPropertyBlock _mpb;

    private void Start()
    {
        _mpb = new MaterialPropertyBlock(); 
        ResetMix();
        ingredient = new List<Ingredient>();
    }

    /// <summary>
    /// Add an ingredient to the cauldron, return true if the ingredient has been successfully added.
    /// </summary>
    /// <param name="newIngredient">Ingredient you want to add to the cauldron</param>
    /// <returns></returns>
    public bool AddIngredient(Ingredient newIngredient)
    {
        if (ingredient.Count < maxIngredients)
        {
            ingredient.Add(newIngredient);
            return true;
        }

        return false;
    }

    public void Mix()
    {
        if (ingredient.Count > 0) currentMixNb++;
        _mpb.SetFloat("_FillAmount", currentMixNb / (float)nbOfMixRequired);
        _gaugeRenderer.SetPropertyBlock(_mpb);
        print("Mix");
        if (currentMixNb >= nbOfMixRequired)
        {
            ResetMix();
            //RecipeManager.Instance.ProcessIngredients(ingredient.ToArray());

            Instantiate(RecipeManager.Instance.ProcessIngredients(ingredient.ToArray()), _spawnTransform.position, _spawnTransform.rotation);
            print("Recipe get !");
            ingredient.Clear();
        }
    }

    public void ResetMix()
    {
        currentMixNb = 0;
        _mpb.SetFloat("_FillAmount", 0);
        _gaugeRenderer.SetPropertyBlock(_mpb);
    }
}
