using UnityEngine;
using UnityEngine.InputSystem;

public class BolinhaController : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rb;
    private Vector2 moveInput;

    private GameplayInputActions inputActions;

    private bool isPlayer1;

    public void Setup(bool player1)
    {
        isPlayer1 = player1;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputActions = new GameplayInputActions();
    }

    private void OnEnable()
    {
        inputActions.Gameplay.Enable();
    }

    private void OnDisable()
    {
        inputActions.Gameplay.Disable();
    }

    private void Update()
    {
        if (isPlayer1)
            moveInput = inputActions.Gameplay.P1Move.ReadValue<Vector2>();
        else
            moveInput = inputActions.Gameplay.P2Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 dir = new Vector3(moveInput.x, 0f, moveInput.y);
        rb.linearVelocity = dir * speed;
    }
}