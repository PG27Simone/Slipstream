using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    public static EnergyManager Instance { get; private set; }
    private int currentEnergy;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        currentEnergy = 0;
    }

    public int GetCurrentEnergy()
    {
        return currentEnergy;
    }

    public void ChangeCurrentEnergy(int amount)
    {
        currentEnergy += amount;
        Debug.Log(currentEnergy);
    }
}
