using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnergyMagnet : MonoBehaviour
{
    public InputAction interactAction;

    private void Start(){
        interactAction = InputSystem.actions.FindAction("Action");
    }

    private void Update(){
        if(interactAction.WasPerformedThisFrame() && ParryManager.Instance.isParryEnabled == true){
                CollectPowerup();
                Debug.Log("parry");
            }
        
    }
    
    // private void OnTriggerEnter(Collider collision)
    // {
    //     CollectPowerup();
    // }

    private void CollectPowerup()
    {
        PowerupManager.Instance.StartMagnetEffect();
        gameObject.SetActive(false);
    }

}
