using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Sub Behaviours")]
    public PlayerBehaviourC playerAnimationBehaviour;
    [Header("Input Settings")]
    //public PlayerInput playerInput;
    public float movementSmoothingSpeed = 1f;
    private Vector3 rawInputMovement;
    private Vector3 smoothInputMovement;
    [Header("Movement Settings")]
    public Rigidbody playerRigidbody;
    public float movementSpeed = 3f;
    public float turnSpeed = 0.1f;
    [SerializeField] private Camera mainCamera;
    private Vector3 movementDirection;
    [SerializeField]private float x, y;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        rawInputMovement = new Vector3(x,0,y);
        playerRigidbody.velocity = rawInputMovement * movementSpeed;
        playerAnimationBehaviour.UpdateMovementAnimation(playerRigidbody.velocity.magnitude);
        //playerRigidbody.MoveRotation(45);
    }
    void FixedUpdate()
    {      
        TurnThePlayer();
    }

    void TurnThePlayer()
    {
        if (movementDirection.sqrMagnitude > 0.01f)
        {
            //Quaternion rotation = Quaternion.Slerp(playerRigidbody.rotation,Quaternion.LookRotation(mainCamera.transform),turnSpeed);
            //playerRigidbody.MoveRotation(rotation);
        }
    }
    /*
    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
    }
    public void OnAttack(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            playerAnimationBehaviour.PlayAttackAnimation();
        }
    }*/
}
