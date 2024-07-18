using UnityEngine;

public class Spot : MonoBehaviour
{
    [Header("Уникальный Id места")]
    [ShowOnly]
    public string spotId;

    private SpotsManager spotManager;

    public void Init(string spotId)
    {
        this.spotId = spotId;
        spotManager = GetIt.get<SpotsManager>();
    }

    public void StartHover() => spotManager.SetNewHoverSpot(spotId);

    public void StopHover() => spotManager.ResetHoverSpot();
}
