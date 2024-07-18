using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotHover : MonoBehaviour, IHover
{
    private Spot baseSpot;

    public void StartHover() => baseSpot.StartHover();

    public void StopHover() => baseSpot.StopHover();

    void Start()
    {
        baseSpot = GetComponent<Spot>();
    }
}
