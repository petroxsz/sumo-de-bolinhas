using UnityEngine;
using UnityEngine.InputSystem;

public class BolinhaController : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rb;
    private Vector2 moveInput;

    private GameplayInputActions inputActions;

    private bool isPlayer1;

    // Referência para o inimigo
    private GameObject enemy;

    public float attackForce = 12f;
public float attackRange = 5f;
public float cooldownTime = 3f;

private float currentCooldown = 0f;

    private void Attack()
{

if (currentCooldown > 0)
    return;

    if (enemy == null)
        return;

    float distance = Vector3.Distance(transform.position, enemy.transform.position);

    if (distance > attackRange)
        return;

    float proximity = 1f - (distance / attackRange);
    proximity = Mathf.Clamp01(proximity);

    Vector3 direction = (enemy.transform.position - transform.position).normalized;

    Rigidbody enemyRb = enemy.GetComponent<Rigidbody>();

    float finalForce = attackForce * proximity;

    enemyRb.AddForce(direction * finalForce, ForceMode.Impulse);

    currentCooldown = cooldownTime;
}

    public void Setup(bool player1)
    {
        isPlayer1 = player1;
    }

    // Recebe quem é o inimigo
    public void SetEnemy(GameObject otherPlayer)
    {
        enemy = otherPlayer;
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
if (currentCooldown > 0)
{
    currentCooldown -= Time.deltaTime;
}

    if (isPlayer1)
        moveInput = inputActions.Gameplay.P1Move.ReadValue<Vector2>();
    else
        moveInput = inputActions.Gameplay.P2Move.ReadValue<Vector2>();

    if (isPlayer1)
    {
        if (inputActions.Gameplay.P1Attack.WasPressedThisFrame())
        {
            Attack();
        }
    }
    else
    {
        if (inputActions.Gameplay.P2Attack.WasPressedThisFrame())
        {
            Attack();
        }
    }
}

    private void FixedUpdate()
    {
        Vector3 dir = new Vector3(moveInput.x, 0f, moveInput.y);
        rb.linearVelocity = dir * speed;
    }
}