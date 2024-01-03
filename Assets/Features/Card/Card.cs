using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [Header("Id статистики")]
    [ShowOnly]
    public  string referenceId = Guid.NewGuid().ToString();

    [Header("Уникальный Id карточки")]
    [ShowOnly]
    public  string cardId = Guid.NewGuid().ToString();

    

}
