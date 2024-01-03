using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Padding
{
    public float verticapPading;
    public float horizontalPading;
}

[Serializable]
public class Size
{
    public int rowCount;
    public int colCount;
}

public class SpotsManager : MonoBehaviour
{

    [SerializeField]
    private Spot spotPrefab;

    [SerializeField]
    private Padding padding;

    [SerializeField]
    private Size size;


    private Spot[] spots;


    private string currentHoverSpotId;

    private float spotHeight;
    private float spotWidth;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SpotManger Craete");

        GetIt.registerSingleton(this);

        BoxCollider2D spotColider = spotPrefab.GetComponent<BoxCollider2D>();

        spotHeight = spotColider.size.y;
        spotWidth = spotColider.size.x;

        spots = new Spot[size.rowCount * size.colCount];

        Vector3 leftBottomCorner = new Vector3(0 , 0, 0 );
        
        leftBottomCorner.x -= size.colCount * spotWidth + (size.colCount - 1) * padding.horizontalPading;
        leftBottomCorner.y -= size.rowCount * spotHeight + (size.rowCount - 1) * padding.verticapPading;


        leftBottomCorner.x = leftBottomCorner.x / 2;
        leftBottomCorner.y = leftBottomCorner.y / 2;

        leftBottomCorner.x += spotWidth / 2;
        leftBottomCorner.y += spotHeight / 2;   

        Vector3 spotPoint = leftBottomCorner;


        for (int r = 0; r < size.rowCount; r += 1)
        {
            for (int c = 0; c < size.colCount; c += 1)
            {

                Spot newSpot = Instantiate(spotPrefab, spotPoint, Quaternion.identity);
                newSpot.Init((c + r * size.colCount ).ToString());
                spots[c + r * size.colCount ] = newSpot;

                spotPoint.x += spotWidth + padding.horizontalPading;

            }
            spotPoint.x = leftBottomCorner.x;
            spotPoint.y += spotHeight + padding.verticapPading;
        }
        
    }


    public void SetNewHoverSpot(string newSpotId)
    {

        if (spots.Where((s) => s.spotId == newSpotId).Count() != 1) return;


        Utils.Print($"New hover spot id: {newSpotId}");

        currentHoverSpotId = newSpotId ;
    }

    public void ResetHoverSpot()
    {
        Utils.Print($"Reset hover spot");
        currentHoverSpotId = null;
    }

    


}
