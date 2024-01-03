using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverManager : MonoBehaviour
{

    [SerializeField]
    private LayerMask hoverLayer;

    private IHover currentHover;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("HoverManager create");

    }

    // Update is called once per frame
    void Update()
    {
     
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, hoverLayer);

        
        IHover hitHover = null;

        
        hit.collider?.TryGetComponent(out hitHover);
        

        bool isOutsideHover = hitHover == null && currentHover == null;

        bool isStartHover = hitHover != null && currentHover == null;

        bool isInsideHOver = hitHover != null && currentHover != null && hitHover == currentHover;

        bool isStopHover = hitHover == null && currentHover != null;

        
        if (isStartHover) hitHover?.StartHover();

        if (isStopHover) currentHover?.StopHover();

        currentHover = hitHover;


    }
}
