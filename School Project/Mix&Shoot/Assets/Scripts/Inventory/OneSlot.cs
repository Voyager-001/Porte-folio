using Unity.VisualScripting;
using UnityEngine;

public class OneSlot : MonoBehaviour
{
    void Start()
    {
        if(TryGetComponent(out UsableIngredient usableIngredient))
        {
            usableIngredient.Use();
        }
        else if(TryGetComponent(out UsablePotion usablePotion))
        {
            
        }
    }
}