using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInput : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction attack;

    public bool isAttacking;

    public Vector2 movement { get; private set; }

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        attack = InputSystem.actions.FindAction("Attack");
    }

    void Update()
    {
        movement = moveAction.ReadValue<Vector2>();
        isAttacking = attack.WasPressedThisFrame(); 
    }
}
