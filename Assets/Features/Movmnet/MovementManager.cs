using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField]
    private LayerMask movementLayer;

    private IMover selectedMover;

    void Start()
    {
        Debug.Log("MovementManager Created");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SelectNewCard();

        if (Input.GetMouseButtonUp(0))
            DropSelectedCard();

        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        selectedMover?.Rotate(newPos);
        selectedMover?.Move(newPos);
    }

    void DropSelectedCard()
    {
        selectedMover?.ResetRotation();
        selectedMover?.StopMoving();
        selectedMover = null;
    }

    void SelectNewCard()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(
            ray.origin,
            ray.direction,
            Mathf.Infinity,
            movementLayer
        );

        if (hit.collider == null)
            return;

        IMover hitMover;
        hit.collider.TryGetComponent(out hitMover);

        selectedMover = hitMover;
        selectedMover?.StartMoving();
    }
}
