using UnityEngine;

interface IMover
{
    public void Move(Vector3 newPos);
    public void Rotate(Vector3 newPos);
    public void ResetRotation();
    public void StartMoving();
    public void StopMoving();
}
