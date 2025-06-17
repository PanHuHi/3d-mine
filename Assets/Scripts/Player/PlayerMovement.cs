using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("�̵� ����")]
    public float moveSpeed = 3f;
    public float rotationSpeed = 8f;

    [Header("���� ����")]
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    private float verticalVelocity = 0f;
    private bool isJumping = false;

    [Header("����")]
    public PlayerActionState currentState = PlayerActionState.Idle;

    private CharacterController controller;
    private Vector3 moveDir;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        switch (currentState)
        {
            case PlayerActionState.Idle:
            case PlayerActionState.Moving:
                HandleMovement();
                HandleJumpInput();
                break;

            case PlayerActionState.Attacking:
                // ���� ���� ����
                break;
        }

        ApplyGravity();
    }

    void HandleMovement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(h, 0, v).normalized;

        if (moveDir.magnitude >= 0.1f)
        {
            currentState = PlayerActionState.Moving;

            float targetAngle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg;
            float angle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 move = moveDir * moveSpeed;
            move.y = verticalVelocity;
            controller.Move(move * Time.deltaTime);
        }
        else
        {
            currentState = isJumping ? currentState : PlayerActionState.Idle;

            // ���� �̵��� ����
            Vector3 move = new Vector3(0, verticalVelocity, 0);
            controller.Move(move * Time.deltaTime);
        }
    }

    void HandleJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            verticalVelocity = jumpForce;
            isJumping = true;
        }
    }

    void ApplyGravity()
    {
        if (controller.isGrounded)
        {
            if (verticalVelocity < 0f)
            {
                verticalVelocity = -1f; // ������ ������
                isJumping = false;
            }
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
    }
}
