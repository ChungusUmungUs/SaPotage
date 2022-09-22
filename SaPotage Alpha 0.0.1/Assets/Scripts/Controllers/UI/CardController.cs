using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler, IPointerUpHandler, IDragHandler
{
    public IngredientCard ingredientCard;
    public Image illustration, image;
    public TextMeshProUGUI ingredientName, ingredientType, ingredientTasteSweet, ingredientTasteSour, ingredientTasteSalty, ingredientTasteSpicy, ingredientTasteUmami, ingredientTasteBitter, ingredientRules;
    private Transform originalParent;
    
    private void Start()
    {
    }

    public void Initialize(IngredientCard ingredientCard)
    {
        this.ingredientCard = ingredientCard;
        illustration.sprite = ingredientCard.illustration;
        ingredientName.text = ingredientCard.ingredientName;
        ingredientType.text = ingredientCard.ingredientType;
        ingredientRules.text = ingredientCard.ingredientRules;
        ingredientTasteSweet.text = ingredientCard.ingredientTasteSweet.ToString();
        ingredientTasteSour.text = ingredientCard.ingredientTasteSour.ToString();
        ingredientTasteSalty.text = ingredientCard.ingredientTasteSalty.ToString();
        ingredientTasteSpicy.text = ingredientCard.ingredientTasteSpicy.ToString();
        ingredientTasteUmami.text = ingredientCard.ingredientTasteUmami.ToString();
        ingredientTasteBitter.text = ingredientCard.ingredientTasteBitter.ToString();
        originalParent = transform.parent;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Entered");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exited");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");
        if(originalParent.name == $"Player{ingredientCard.ownerID + 1}Field")
        {

        }
        else
        {
            transform.SetParent(transform.root);
            image.raycastTarget = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerEnter);
        image.raycastTarget = true;
        AnalyzePointerUp(eventData);
    }

    private void AnalyzePointerUp(PointerEventData eventData)
    {
        if(eventData.pointerEnter != null && eventData.pointerEnter.name == $"Player{ingredientCard.ownerID + 1}Field")
        {
            if(PlayerManager.instance.FindPlayerByID(ingredientCard.ownerID).plays >= -99)
            {
                PlayCard(eventData.pointerEnter.transform);
            }
            else
            {
                ReturnToHand();
            }
        }
               
        transform.SetParent(originalParent);
        transform.localPosition = Vector3.zero;
    }

    private void PlayCard(Transform field)
    {
        transform.SetParent(field);
        originalParent = field;
        transform.localPosition = Vector3.zero;
    }

    private void ReturnToHand()
    {
        transform.SetParent(originalParent);
        transform.localPosition = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (transform.parent == originalParent) return;
        transform.position = eventData.position;
    }
}
