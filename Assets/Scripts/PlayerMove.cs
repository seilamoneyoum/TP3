using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private Transform mainCamera;
    private CharacterController characterController;
    private Vector3 direction;
    private float rotationTime = 0.1f;
    private float rotationSpeed;
    private float gravity = 20f;
    private float verticalMovement = 0f;

    float horizontal, vertical, targetAngle, angle, tempSpeed, originalMovementMagnitude;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        BuildSurfaceMovement();
        BuildVerticalMovement();
        characterController.Move(direction);
    }

    private void BuildSurfaceMovement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        direction = new Vector3(horizontal, 0f, vertical);

        if (direction.magnitude > 1.0f) direction = direction.normalized;


        if (direction.magnitude >= 0.1f)
        {
            targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCamera.eulerAngles.y;

            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, rotationTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            tempSpeed = moveSpeed;
            if (!characterController.isGrounded) tempSpeed /= 2;

            Vector3 directionWithCamera = (Quaternion.Euler(0f, angle, 0f) * Vector3.forward).normalized;
            originalMovementMagnitude = direction.magnitude;
            direction.x = directionWithCamera.x * tempSpeed * originalMovementMagnitude * Time.deltaTime;
            direction.z = directionWithCamera.z * tempSpeed * originalMovementMagnitude * Time.deltaTime;
        }
        else
        {
            direction = Vector3.zero;
        }
    }
    private void BuildVerticalMovement()
    {
        if (!characterController.isGrounded) verticalMovement -= gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            verticalMovement = jumpSpeed;
        }

        direction.y = verticalMovement * Time.deltaTime;
    }
}