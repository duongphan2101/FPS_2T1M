using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour {

    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerMotor PlayerMotor;

    private PlayerLook look;
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        PlayerMotor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        onFoot.Jump.performed += ctx => PlayerMotor.Jump();
    }

    void FixedUpdate()
    {
        PlayerMotor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }


}
