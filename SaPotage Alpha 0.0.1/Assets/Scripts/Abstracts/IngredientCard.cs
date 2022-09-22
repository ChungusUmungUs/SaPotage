using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class IngredientCard
{
    public string ingredientName;
    public string ingredientType;
    public string ingredientRules;
    public int ingredientTasteSweet, ingredientTasteSour, ingredientTasteSalty, ingredientTasteSpicy, ingredientTasteUmami, ingredientTasteBitter, ownerID;

    public Sprite illustration;

}
