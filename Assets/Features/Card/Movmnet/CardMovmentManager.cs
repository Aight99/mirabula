using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMovmentManager : MonoBehaviour
{
    [SerializeField]
    private LayerMask cardsLayer;

    private CardMover selectedCard;

    void Start()
    {
        Debug.Log("CardMovmentManager create");
    }

    void Update()
    {


        if (Input.GetMouseButtonDown(0)) SelectNewCard();

        if (Input.GetMouseButtonUp(0)) DropSelectedCard();

        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        selectedCard?.Rotate(newPos);
        selectedCard?.Move(newPos);
        

    }

    void DropSelectedCard()
    {
        selectedCard = null;
    }

    void SelectNewCard()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, cardsLayer);

        if (hit.collider == null) return;

        CardMover hitCard;
        hit.collider.TryGetComponent(out hitCard);

        selectedCard = hitCard;
    }
}



