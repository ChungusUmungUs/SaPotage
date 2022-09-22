using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;
    public List<IngredientCard> ingredientCards = new List<IngredientCard>();
    public Transform player1Hand, player2Hand;
    public CardController cardControllerPrefab;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GenerateCards();
    }

    private void GenerateCards()
    {
        foreach(IngredientCard ingredientCard in ingredientCards)
        {
            CardController newCard = Instantiate(cardControllerPrefab, player1Hand);
            newCard.transform.localPosition = Vector3.zero;
            newCard.Initialize(ingredientCard);
        }
    }
}
