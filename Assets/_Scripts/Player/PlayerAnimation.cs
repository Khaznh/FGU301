using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerInput playerInput;
    private Animator animator;
    private Vector2 moveVec;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        HandleAnimation();
    }

    private void HandleAnimation()
    {
        animator.SetFloat("Speed", moveVec.sqrMagnitude);
        
        if (moveVec != Vector2.zero)
        {
            animator.SetFloat("MoveX", moveVec.x);
            animator.SetFloat("MoveY", moveVec.y);

            animator.SetFloat("LastMoveX", moveVec.x);
            animator.SetFloat("LastMoveY", moveVec.y);
        } 
    }

    private void GetInput()
    {
        moveVec = playerInput.Movement.Move.ReadValue<Vector2>();
    }
}
