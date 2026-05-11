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
        isAttacking = attack.WasPressedThisFrame(); //una vez pulsado

        // if (!InputSystem.actions.enabled)
        // {
        //     InputSystem.actions.Enable();
        //     Debug.LogWarning("Input Asset fue deshabilitado externamente, re-enabling...");
        // }
    }
    // void OnEnable()
    // {
    //     moveAction.Enable();
    //     attack.Enable();
    // }

    // void OnDisable()
    // {
    //     moveAction.Disable();
    //     attack.Disable();
    // }
}
