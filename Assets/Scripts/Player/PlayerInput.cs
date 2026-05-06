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
        foreach (var binding in moveAction.bindings)
        {
            Debug.Log($"Action: {moveAction.name}, Path: {binding.path}, Groups: {binding.groups}");
        }
    }

    void Update()
    {
        movement = moveAction.ReadValue<Vector2>();
        isAttacking = attack.WasPressedThisFrame(); //una vez pulsado
    }
    void OnEnable()
    {
        moveAction.Enable();
        attack.Enable();
    }

    void OnDisable()
    {
        moveAction.Disable();
        attack.Disable();
    }
}
