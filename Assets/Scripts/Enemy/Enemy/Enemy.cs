using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IEnemyMoveable, ITriggerCheckeable
{
    private EnemyHealthBar healthBar;
    [field: SerializeField] public int maxHealth { get ; set ; }
    [SerializeField] private int score = 100;
    public int currentHealth { get ; set ; }
    public Rigidbody2D rb { get; set; }
    public bool isFacingRight { get; set; } = true;
    public bool isAggroed {get; set; }
    public bool isWithinStrikingDistance { get; set; }


    

    // STATE MACHINE VARIABLES

    // idle variables


    public Rigidbody2D bulletPrefab;
    public float randomMovementRange = 5f;
    public float randomMovementSpeed = 1f; 

    public EnemyStateMachine stateMachine{get; set; }
    public EnemyIdleState idleState {get; set;}
    public EnemyChaseState chaseState {get;set;}
    public EnemyAttackState attackState {get;set;}
    
    private void Awake()
    {
        stateMachine = new EnemyStateMachine();
        idleState = new EnemyIdleState(this, stateMachine);
        chaseState = new EnemyChaseState(this, stateMachine);
        attackState = new EnemyAttackState(this, stateMachine);

        //
        healthBar = GetComponentInChildren<EnemyHealthBar>();
    }




    private void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();

        // STATEMACHINE

        stateMachine.Initialize(idleState);

        Debug.Log("Hello! I have " + currentHealth + " health, wow");
    }

    private void Update()
    {
        stateMachine.CurrentEnemyState.FrameUpdate();
    }

    private void FixedUpdate()
    {
        stateMachine.CurrentEnemyState.PhysicsUpdate();
    }

    //Health / Die Functions

    // Movement Functions

   
    
    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        stateMachine.CurrentEnemyState.AnimationTriggerEvent(triggerType);
    }

    public enum AnimationTriggerType
    {
        EnemyDamaged,
        PlayFootstepsSound
    }

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }

        healthBar.SetSize(currentHealth, maxHealth);
    }

    public void Die()
    {
        GameManager.instance.AddScore(score);
        Destroy(gameObject);
    }

    public void MoveEnemy(Vector2 velocity)
    {
        rb.linearVelocity = velocity;
        CheckForLeftOrRightFacing(velocity);
    }

    public void CheckForLeftOrRightFacing(Vector2 velocity)
    {
        if (isFacingRight && velocity.x < 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x,180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = !isFacingRight;
        }
        else if (!isFacingRight && velocity.x > 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = !isFacingRight;
        }
        

    }

    public void SetAggroStatus(bool isAggroed)
    {
        this.isAggroed = isAggroed;
    }

    public void SetStrikingDistanceBool(bool isWithinStrikingDistance)
    {
        this.isWithinStrikingDistance = isWithinStrikingDistance;
    }

   
}