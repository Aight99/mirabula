using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{

    private SpotsManager spotsManager;


    private List<Card> cards = new List<Card>();

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("CardManger craete");
        GetIt.registerSingleton(this);

        spotsManager = GetIt.get<SpotsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
