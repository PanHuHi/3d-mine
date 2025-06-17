using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("이동 관련")]
    public float moveSpeed = 3f;
    public float rotationSpeed = 8f;

    [Header("점프 관련")]
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    private float verticalVelocity = 0f;
    private bool isJumping = false;

    [Header("상태")]
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
                // 추후 공격 상태
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

            // 수직 이동만 적용
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
                verticalVelocity = -1f; // 가볍게 눌러줌
                isJumping = false;
            }
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
    }
}
