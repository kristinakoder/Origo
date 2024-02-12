using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.NoGravityActions noGravity;
    private PlayerMotor motor;

    void Awake()
    {
        playerInput = new PlayerInput();
        noGravity = playerInput.noGravity;
        motor = GetComponent<PlayerMotor>();
        //noGravity.Interact.triggered += ctx => motor.Interact();
        //noGravity.Interact.performed += ctx => motor.Interact();
    }

    void FixedUpdate()
    {
        motor.ProcessMove(noGravity.Movement.ReadValue<Vector3>());
    }
    void LateUpdate()
    {
        motor.ProcessLook(noGravity.Look.ReadValue<Vector2>());
        motor.ProcessZoom(noGravity.Zoom.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        noGravity.Enable();
    }

    private void OnDisable()
    {
        noGravity.Disable();
    }
}