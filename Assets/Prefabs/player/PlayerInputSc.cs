using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSc : MonoBehaviour
{
    public int FPS = 60;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float lookSensitivity = 0.5f;

    private Vector3 moveDirection = Vector3.zero;

    float yRotation;
    float xRotation;
    float currentXRotation;
    float currentYRotation;
    float yRotationV;
    float xRotationV;
    float lookSmoothnes = .1f;

    public InputActionReference directionActionReference;
    public InputActionReference jumpActionReference;
    public InputActionReference turnCameraActionReference;
    public InputActionReference fireActionReference;

    private CharacterController controller;

    [SerializeField]
    private ShootManagementSc shootManagement;

    private PlayerSpellSc playerSpell;

    void Start()
    {
        Application.targetFrameRate = FPS;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
        playerSpell = GetComponent<PlayerSpellSc>();
    }

    void OnEnable()
    {
        directionActionReference.action.performed += DirectionAction;
        directionActionReference.action.canceled += DirectionActionCancel;

        jumpActionReference.action.performed += JumpAction;

        turnCameraActionReference.action.performed += TurnAction;

        fireActionReference.action.performed += FireAction;
    }

    void OnDisable()
    {
        directionActionReference.action.performed -= DirectionAction;
        directionActionReference.action.canceled -= DirectionActionCancel;
        
        jumpActionReference.action.performed -= JumpAction;
        
        turnCameraActionReference.action.performed -= TurnAction;

        fireActionReference.action.performed -= FireAction;
    }

    void DirectionAction(InputAction.CallbackContext callback)
    {
        ChangeMove(callback.ReadValue<Vector2>());
    }

    void JumpAction(InputAction.CallbackContext callback)
    {
        ChangeJump();
    }

    void TurnAction(InputAction.CallbackContext callback)
    {
        Vector2 look = callback.ReadValue<Vector2>();
        ChangeRotation(look);
    }

    void FireAction(InputAction.CallbackContext callback)
    {
        Vector3 source = transform.position;
        Vector3 target = transform.position + (transform.forward * 500);

        shootManagement.AddShoot(
            this.playerSpell.GetCurrentShootData(),
            source, target
        );
    }

    void DirectionActionCancel(InputAction.CallbackContext callback)
    {
        ResetChangeMove();
    }

    void ChangeJump()
    {
        if (controller.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
    }

    void ChangeMove(Vector2 direction)
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(direction.x, 0, direction.y);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }
    }

    void ResetChangeMove()
    {
        moveDirection = Vector2.zero;
    }

    void ChangeRotation(Vector2 mouseMove)
    {
        yRotation += mouseMove.x * lookSensitivity;
        xRotation -= mouseMove.y * lookSensitivity;
        xRotation = Mathf.Clamp(xRotation, -80, 100);
        currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, ref xRotationV, lookSmoothnes);
        currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationV, lookSmoothnes);
    }

    void Update()
    {
        moveDirection.y -= gravity * Time.deltaTime;
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        controller.Move(moveDirection * Time.deltaTime);
    }
}
