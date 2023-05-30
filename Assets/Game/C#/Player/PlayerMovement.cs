using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] public PlayerInput playerInput;
    [SerializeField] Transform inFront;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] public float movementSpeed = 3f;
    [SerializeField] public float turnSpeed = 200f;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float x, y;
    [SerializeField] private bool _canJump = true;

    public void TurnThePlayer(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        transform.Rotate(0, inputMovement.x * Time.deltaTime * turnSpeed, 0);

    }
    public void MovementPlayer(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        playerRigidbody.velocity = inputMovement * movementSpeed;
    } 
}
