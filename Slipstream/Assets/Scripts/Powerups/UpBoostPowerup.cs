using UnityEngine;
using UnityEngine.InputSystem;

public class UpBoostPowerup : MonoBehaviour
{
    private InputAction interactAction;
    public Movement player;

    private void Start()
    {
        interactAction = InputSystem.actions.FindAction("Action");
    }

    private void Update()
    {
        if (interactAction.WasPerformedThisFrame() && ParryManager.Instance.isUpBoostEnabled == true)
        {
            CollectPowerupUpBoost();
        }

    }

    private void CollectPowerupUpBoost()
    {
        player.SpeedBoostUpActive();
    }
}
