using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    private SpotsManager spotsManager;

    private List<Card> cards = new List<Card>();

    void Start()
    {
        Debug.Log("CardManger Created");
        GetIt.registerSingleton(this);

        spotsManager = GetIt.get<SpotsManager>();
    }
}
