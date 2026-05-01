using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    private Animator animator;
    private PlayerInput input;
    private PlayerController controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
        controller = GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (controller.hasWrench && input.isAttacking)
        {
            Attack();
        }
    }

    void Attack()
    {
        //animacion de atacar
        animator.SetBool("isAttacking", true);
    }

    public void HandleAttackEnd()
    {
        animator.SetBool("isAttacking", false);
    }
}
