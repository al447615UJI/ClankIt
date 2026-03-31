using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInput : MonoBehaviour
{
    private InputAction moveAction;

    public Vector2 movement {get; private set;}


    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        movement = moveAction.ReadValue<Vector2>();
    }

}
