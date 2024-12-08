using UnityEngine;

public class EnergyParticle : MonoBehaviour
{
    [SerializeField] private int energyGain;
    private bool isBeingAttracted;

    private void OnTriggerEnter(Collider collision)
    {
        CollectEnergy();
    }

    private void CollectEnergy()
    {
        EnergyManager.Instance.ChangeCurrentEnergy(energyGain);
        gameObject.SetActive(false);
    }

    public void SetIsBeingAttracted(bool value)
    {
        isBeingAttracted = value;
    }

    public bool GetIsBeingAttracted()
    {
        return isBeingAttracted;
    }
}
