using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoostPowerup : MonoBehaviour
{
    private InputAction interactAction;
    public Movement player;

    private void Start()
    {
        interactAction = InputSystem.actions.FindAction("Action");
    }

    private void Update()
    {
        if (interactAction.WasPerformedThisFrame() && ParryManager.Instance.isForBoostEnabled == true)
        {
            CollectPowerupBoost();
        }

    }

    private void CollectPowerupBoost()
    {
        player.SpeedBoostActive();
    }
}
