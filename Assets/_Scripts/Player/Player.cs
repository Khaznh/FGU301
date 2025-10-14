using UnityEngine;

public class Player : Entity
{
    [SerializeField] public GameObject fishIcon;
    [SerializeField] public GameObject fishGamePlay;
    [SerializeField] public GameObject iWarn;

    public PlayerInput input;
    public PlayerMovement playerMovement;
    public PlayerAnimation playerAnimation;
    private PlayerCollider playerCollider;
    public PlayerSpawnBait PlayerSpawnBait;

    public bool onNearPort = false;

    public FSM fsm;
    public PlayerNormalState playerNormalState;
    public PlayerCastState playerCastState;
    public PlayerSpawnBait playerSpawnBait;
    public PlayerFishingState playerFishingState;
    public PlayerResultState playerResultState;

    public Transform pondTransform;
    public GameObject bait;
    public Animator animator;
    public FishingGamePlay fishingGamePlay;

    public FishStats fishStats;

    private void Awake()
    {
        fishGamePlay = transform.Find("Canvas").gameObject;
        fishIcon = transform.Find("FishingIcon").gameObject;
        iWarn = transform.Find("IconW").gameObject;
        playerCollider = transform.GetComponentInChildren<PlayerCollider>();

        playerCollider.OnNearPort += PlayerCollider_OnNearPort;

        fishingGamePlay = fishGamePlay.GetComponentInChildren<FishingGamePlay>();

        animator = transform.GetComponent<Animator>();

        playerMovement = GetComponent<PlayerMovement>();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerSpawnBait = GetComponent<PlayerSpawnBait>();

        fishIcon.SetActive(false);
        fishGamePlay.SetActive(false);
        iWarn.SetActive(false);

        input = new PlayerInput();
        fsm = new FSM();
        playerNormalState = new PlayerNormalState(fsm,this);
        playerCastState = new PlayerCastState(fsm,this);
        playerFishingState = new PlayerFishingState(fsm,this);
        playerResultState = new PlayerResultState(fsm,this);

        fsm.Init(playerNormalState);
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Update()
    {
        fsm.currentState.UpdateLogic();
    }

    private void FixedUpdate()
    {
        fsm.currentState.UpdatePhysic();
    }

    private void PlayerCollider_OnNearPort(bool obj, Transform transform)
    {
        onNearPort = obj;
        if (transform != null)
        {
            pondTransform = transform;
        }
    }

    public void DestroyBait()
    {
        Destroy(bait);
    }
}
