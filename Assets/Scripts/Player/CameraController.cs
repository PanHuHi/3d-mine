using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;                 // 따라갈 대상 (보통 플레이어)
    public Vector3 offset = new Vector3(0, 2, -4); // 초기 카메라 위치 오프셋

    [Header("회전 설정")]
    public float sensitivity = 3f;
    public float minY = -30f;
    public float maxY = 60f;

    [Header("줌 설정")]
    public float zoomSpeed = 2f;
    public float minZoom = 2f;
    public float maxZoom = 8f;
    private float currentZoom;

    private float xRotation = 10f;   // 상하
    private float yRotation = 0f;    // 좌우

    void Start()
    {
        currentZoom = offset.magnitude;

        Vector3 angles = transform.eulerAngles;
        xRotation = angles.x;
        yRotation = angles.y;

        // --------------------------------------------
        // 🔒 [임시 기능] 마우스 커서 잠금 + 숨김 처리
        // 추후 GameManager 또는 CursorManager에서 제어할 수 있도록 분리 가능
        Cursor.lockState = CursorLockMode.Locked;  // 화면 중앙에 고정
        Cursor.visible = false;                    // 커서 숨김
                                                   // --------------------------------------------
    }

    void LateUpdate()
    {
        if (target == null) return;

        // ✅ 마우스가 움직이기만 해도 회전
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        yRotation += mouseX * sensitivity;
        xRotation -= mouseY * sensitivity;
        xRotation = Mathf.Clamp(xRotation, minY, maxY);

        // 🔍 마우스 휠로 줌
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        currentZoom -= scroll * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        // 📸 카메라 위치 계산
        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        Vector3 desiredPosition = target.position + rotation * new Vector3(0, 0, -currentZoom);

        transform.position = desiredPosition + new Vector3(0, offset.y, 0); // 살짝 위로
        transform.LookAt(target.position + Vector3.up * 1.5f); // 캐릭터 머리 쪽을 바라보게
    }
}
