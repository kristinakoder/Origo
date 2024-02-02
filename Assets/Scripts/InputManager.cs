using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.NoGravityActions noGravity;
    private PlayerMotor motor;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        noGravity = playerInput.noGravity;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.ProcessMove(noGravity.Movement.ReadValue<Vector3>());
    }
    void LateUpdate()
    {
        motor.ProcessLook(noGravity.Look.ReadValue<Vector2>());
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
