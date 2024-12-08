using System.Collections;
using UnityEngine;

public class EnergyMagnet : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        CollectPowerup();
    }

    private void CollectPowerup()
    {
        PowerupManager.Instance.StartMagnetEffect();
        gameObject.SetActive(false);
    }
}
