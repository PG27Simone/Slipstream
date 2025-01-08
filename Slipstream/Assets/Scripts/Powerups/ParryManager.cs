using UnityEngine;
using UnityEngine.InputSystem;

public class ParryManager : MonoBehaviour
{

    public static ParryManager Instance { get; private set; }
    [SerializeField] private GameObject player;

    [Header("Parry settings")]
    [SerializeField] private float parryRadius;
    [SerializeField] private LayerMask powerupLayer;

    //enabling different powerups
    public bool isMagnetEnabled = false;
    public bool isForBoostEnabled = false;
    public bool isUpBoostEnabled = false;

    //action button
    private InputAction interactAction;


    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        interactAction = InputSystem.actions.FindAction("Action");
    }

    private void Update(){
        Collider[] powerup = Physics.OverlapSphere(player.transform.position, parryRadius, powerupLayer);
        
        //magnet powerup
        if(powerup.Length > 0 && powerup[0].gameObject.tag == "Magnet")
        {
            isMagnetEnabled = true;
        }
        else if (powerup.Length > 0 && powerup[0].gameObject.tag == "Boost")
        {
            isForBoostEnabled = true;
        }
        else if (powerup.Length > 0 && powerup[0].gameObject.tag == "UpwardBoost")
        {
            isUpBoostEnabled = true;
        }
        else
        {
            isMagnetEnabled = false;
            isForBoostEnabled = false;
            isUpBoostEnabled = false;
        }


        //Magnet
        if (interactAction.WasPerformedThisFrame() && isMagnetEnabled == true)
        {
            powerup[0].gameObject.SetActive(false);
            isMagnetEnabled = false;
        }

        //Forward boost
        if (interactAction.WasPerformedThisFrame() && isForBoostEnabled == true)
        {
            powerup[0].gameObject.SetActive(false);
            isForBoostEnabled = false;
        }

        //Up Boost
        if (interactAction.WasPerformedThisFrame() && isUpBoostEnabled == true)
        {
            powerup[0].gameObject.SetActive(false);
            isUpBoostEnabled = false;
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.transform.position, parryRadius);
    }
}
