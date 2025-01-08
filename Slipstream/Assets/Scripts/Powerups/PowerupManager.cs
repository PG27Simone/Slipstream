using System.Collections;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public static PowerupManager Instance { get; private set; }
    [SerializeField] private GameObject player;

    [Header("Magnet power up variables")]
    [SerializeField] private float magnetDuration;
    [SerializeField] private float magnetRadius;
    [SerializeField] private float magnetSpeed;
    [SerializeField] private LayerMask energyLayer;
    private bool isMagnetActive;
    private float remainingMagnetTime;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

#region Magnet

    public void StartMagnetEffect()
    {
        if (remainingMagnetTime <= 0)
        {
            StartCoroutine(SetMagnetActive());
        }
        else
        {
            remainingMagnetTime += magnetDuration;
        }
    }

    private IEnumerator SetMagnetActive()
    {
        isMagnetActive = true;
        remainingMagnetTime = magnetDuration;
        StartCoroutine(SetMagnetArea());

        while (remainingMagnetTime > 0)
        {
            yield return new WaitForSecondsRealtime(1);
            remainingMagnetTime -= 1.0f;
        }

        isMagnetActive = false;
    }

    private IEnumerator SetMagnetArea()
    {
        while(isMagnetActive)
        {
            Collider[] particles = Physics.OverlapSphere(player.transform.position, magnetRadius, energyLayer);

            for(int i = 0; i < particles.Length; i++)
            {
                if(!particles[i].GetComponent<EnergyParticle>().GetIsBeingAttracted())
                {
                    particles[i].GetComponent<EnergyParticle>().SetIsBeingAttracted(true);
                    StartCoroutine(AttractEnergy(particles[i].gameObject));
                }
            }

            yield return null;
        }
    }

    private IEnumerator AttractEnergy(GameObject energyParticle)
    {
        while(energyParticle.activeSelf)
        {
            energyParticle.transform.position = Vector3.MoveTowards(energyParticle.transform.position, player.transform.position, magnetSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }    
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(player.transform.position, magnetRadius);
    }

#endregion


#region Boost






#endregion
}
