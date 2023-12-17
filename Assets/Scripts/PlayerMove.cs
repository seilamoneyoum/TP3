using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isStanding = true;
    [SerializeField] private bool canMove = true;
    private const float SIZE_Y_CROUCHING = 0.3f;
    private const float SIZE_Y_STANDING = 0.9f;
    private const float SPEED_STANDING = 1.1f;
    private const float SPEED_CROUCHING = 0.4f;
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
        if (canMove == true)
        {
            BuildSurfaceMovement();
            BuildVerticalMovement();
            characterController.Move(direction);
        }
    }

    public void SetMovementStatus(bool willMove)
    {

        canMove = willMove;
        Debug.Log(canMove);
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

        if (Input.GetButtonDown("Jump"))
        {
            if (isStanding == true)
            {
                // Cette méthode diminue la grandeur du personnage, mais cela permet de donner l'illusion que le personnage est accroupi.
                transform.localScale = new Vector3(transform.localScale.x, SIZE_Y_CROUCHING, transform.localScale.z);
                isStanding = false;
                moveSpeed = SPEED_CROUCHING;
            }
            else
            {
                // Cette méthode augmente la grandeur diminuée du personnage, mais cela permet de donner l'illusion que le personnage est debout.
                transform.localScale = new Vector3(transform.localScale.x, SIZE_Y_STANDING, transform.localScale.z);
                isStanding = true;
                moveSpeed = SPEED_STANDING;

            }
        }

        direction.y = verticalMovement * Time.deltaTime;
    }
}