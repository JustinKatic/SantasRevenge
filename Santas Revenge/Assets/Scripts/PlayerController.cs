using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    [Header("Camera Controls")]
    [SerializeField] GameObject CinemachineCameraTarget;
    [SerializeField] float RotationSpeed = 15;
    [SerializeField] float TopClamp = 70.0f;
    [SerializeField] float BottomClamp = -30.0f;
    [SerializeField] float CameraAngleOverride = 0.0f;
    public float MouseSensitivity;
    [HideInInspector] public float _cinemachineTargetYaw;
    [HideInInspector] public float _cinemachineTargetPitch;
    private Camera mainCamera;

    Vector3 input;
    Vector2 mouseInput;

    private void Start()
    {
        mainCamera = Camera.main;
    }



    // Update is called once per frame
    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        transform.position += input * speed * Time.deltaTime;
        CameraRotation();
    }

    void RotatePlayerToFaceCamDirection()
    {
        //set the players rotation to the direction of the camera with a slerp smoothness
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), RotationSpeed * Time.deltaTime);
    }

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }

    private void CameraRotation()
    {
        // if there is an input and camera position is not fixed
        if (input.sqrMagnitude >= 0.01)
        {
            _cinemachineTargetYaw += mouseInput.x * MouseSensitivity * Time.deltaTime;
            _cinemachineTargetPitch += mouseInput.y * MouseSensitivity * Time.deltaTime;
        }

        // clamp our rotations so our values are limited 360 degrees
        _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
        _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

        // Cinemachine will follow this target
        CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride, _cinemachineTargetYaw, 0.0f);
    }
}
