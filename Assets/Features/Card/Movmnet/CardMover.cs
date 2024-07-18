using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CardMover : MonoBehaviour, IMover
{
    private Transform transformReference;
    private Tween moveTween;

    [Header("Задерэка анимации перемещения в милисекундах")]
    [SerializeField]
    private int moveDuration = 300;

    [Header("Задерэка анимации вращения в милисекундах")]
    [SerializeField]
    private int rotateDuration = 300;

    [SerializeField]
    private Vector2 basicRotaion = Vector2.zero;

    [SerializeField]
    private Vector2 maxAbsRotation = new Vector2(1, 1);

    [SerializeField]
    private float speedMaxRotation;

    void Start()
    {
        transformReference = GetComponent<Transform>();
    }

    public void Move(Vector3 newPos)
    {
        if (newPos == transformReference.position)
            return;

        newPos.z = transformReference.position.z;

        moveTween?.Kill();
        moveTween = transform.DOMove(newPos, moveDuration / 1000.0f);
    }

    public void Rotate(Vector3 newPos)
    {
        Vector2 diff = transform.position - newPos;

        float ry = Mathf.Lerp(
            basicRotaion.x,
            maxAbsRotation.x,
            Mathf.Min(Mathf.Abs(diff.x) / speedMaxRotation, 1.0f)
        );
        float rx = Mathf.Lerp(
            basicRotaion.y,
            maxAbsRotation.y,
            Mathf.Min(Mathf.Abs(diff.y) / speedMaxRotation, 1.0f)
        );

        ry *= diff.x > 0 ? 1 : -1;
        rx *= diff.y > 0 ? 1 : -1;

        Vector3 newRotation = new Vector3(rx, ry, 0);
        transform.eulerAngles = newRotation;
    }

    public void ResetRotation()
    {
        transform.DORotate(Vector3.zero, rotateDuration / 1000);
    }

    public void StartMoving() { }

    public void StopMoving() { }
}
