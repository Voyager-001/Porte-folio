using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableIngredient : UsableObject
{
    [SerializeField] private Ingredient _ingredient = Ingredient.None;
    private Cauldron _cauldronInRange;

    public override bool Use()
    {
        print("Use called");
        if (_cauldronInRange != null && _cauldronInRange.AddIngredient(_ingredient))
        {
            Destroy(gameObject);
            return true;
        }
        else
            return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Cauldron cauldron))
        {
            _cauldronInRange = cauldron;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Cauldron cauldron))
        {
            _cauldronInRange = null;
        }
    }
}
