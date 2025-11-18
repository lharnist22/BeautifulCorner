using UnityEngine;
using UnityEngine.InputSystem; // required for Mouse.current

public class CameraLook : MonoBehaviour
{
    public float sensitivity = 0.2f;
    public float clampAngle = 85f;

    float rotX;
    float rotY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Vector3 rot = transform.localRotation.eulerAngles;
        rotX = rot.x;
        rotY = rot.y;
    }

    void Update()
    {
        // Mouse delta from new Input System
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float mouseX = mouseDelta.x * sensitivity;
        float mouseY = mouseDelta.y * sensitivity;

        rotY += mouseX;
        rotX -= mouseY;
        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        transform.localRotation = Quaternion.Euler(rotX, rotY, 0f);
    }
}
