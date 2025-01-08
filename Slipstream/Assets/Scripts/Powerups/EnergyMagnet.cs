using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnergyMagnet : MonoBehaviour
{
    private InputAction interactAction;

    private void Start(){
        interactAction = InputSystem.actions.FindAction("Action");
    }

    private void Update(){
        if(interactAction.WasPerformedThisFrame() && ParryManager.Instance.isMagnetEnabled == true){
                CollectPowerup();
         }
        
    }

    private void CollectPowerup()
    {
        PowerupManager.Instance.StartMagnetEffect();
    }

}
