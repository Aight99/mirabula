using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMover : MonoBehaviour
{

    private Transform transformReference;
    private Tween moveTween;

    [Header("Задерэка анимации в милисекундах")]
    [SerializeField]
    private  int moveDuration = 300;


    [SerializeField]
    private Vector2 basicRotaion = Vector2.zero;

    [SerializeField]
    private Vector2 maxAbsRotation = new Vector2(1 , 1);

    [SerializeField]
    private float speedMaxRotation;

    void Start()
    {
        transformReference = GetComponent<Transform>();
      
    }


    public void Move(Vector3 newPos)
    {
        if (newPos == transformReference.position) return;

        newPos.z = transformReference.position.z;
        
        moveTween?.Kill();
        moveTween = transform.DOMove(newPos , moveDuration / 1000.0f);
    }

    public void Rotate(Vector3 newPos)
    {
        Vector2 diff = transform.position - newPos;


        float ry = Mathf.Lerp(basicRotaion.x , maxAbsRotation.x , Mathf.Min( Mathf.Abs(diff.x) / speedMaxRotation , 1.0f ) );
        float rx = Mathf.Lerp(basicRotaion.y , maxAbsRotation.y , Mathf.Min( Mathf.Abs(diff.y) / speedMaxRotation , 1.0f ) );

        ry *= diff.x > 0 ? 1 : -1;
        rx *= diff.y > 0 ? 1 : -1;


        Vector3 newRotation =  new Vector3(rx, ry, 0);
        transform.eulerAngles = newRotation;
       
    }


}
