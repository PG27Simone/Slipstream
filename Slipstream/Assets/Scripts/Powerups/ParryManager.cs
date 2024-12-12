using UnityEngine;

public class ParryManager : MonoBehaviour
{

    public static ParryManager Instance { get; private set; }
    [SerializeField] private GameObject player;

    [Header("Parry settings")]
    [SerializeField] private float parryRadius;
    [SerializeField] private LayerMask powerupLayer;

    public bool isParryEnabled = false;
    
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Update(){
        Collider[] powerup = Physics.OverlapSphere(player.transform.position, parryRadius, powerupLayer);
        
        if(powerup.Length > 0){
            isParryEnabled = true;
        }else{
            isParryEnabled = false;
        }
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.transform.position, parryRadius);
    }
}
