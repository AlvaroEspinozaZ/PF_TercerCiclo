using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [Header("Sub Behaviours")]
    public PlayerBehaviourC playerAnimationBehaviour;
    [Header("Input Settings")]
    [SerializeField] public PlayerInput playerInput;
    [Header("Movement Settings")]    
    [SerializeField] Transform inFront;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] public float movementSpeed = 3f;
    [SerializeField] public float turnSpeed = 200f;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private bool _canJump=true;
    [Header("Raycast")]
    [SerializeField] private LayerMask myLayers;
    [SerializeField] private float distanceModifier = 0.3f;

    void Update()
    {
        MakeRaycast();
       if (!_canJump)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime*movementSpeed, transform.position.z);
        }
    }
    private void MakeRaycast()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, new Vector3(0, -1,0), out hit,distanceModifier, myLayers))
        {
            //Debug.Log(hit.transform.tag);
            _canJump = true;
        }
        Debug.DrawRay(transform.position, new Vector2(0, - 1).normalized * distanceModifier, Color.red);

    }
    private void MovePlayer()
    {
        Vector3 tmp = new Vector3(inFront.position.x - transform.position.x, transform.position.y, inFront.position.z - transform.position.z);
       
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
    }

    public void onTurnThePlayer(InputAction.CallbackContext value)
    {
        Vector3 inputMovement = value.ReadValue<Vector3>();
        transform.Rotate(0, inputMovement.x *Time.deltaTime *turnSpeed, 0);
    }
    public void onMovementPlayer(InputAction.CallbackContext value)
    {        
            Vector3 tmp = new Vector3(inFront.position.x-transform.position.x, transform.position.y, inFront.position.z - transform.position.z); 
            Vector3 inputMovement = new Vector3(transform.position.x, value.ReadValue<Vector3>().y, transform.position.z);
            playerRigidbody.velocity = tmp * inputMovement.y * movementSpeed;
            playerAnimationBehaviour.UpdateMovementAnimation(inputMovement.y);        
    }
    public void onJumpPlayer(InputAction.CallbackContext value)
    {
        if (_canJump)
        {
            if (value.started)
            {
                playerRigidbody.AddForce(Vector3.up * movementSpeed*2, ForceMode.Impulse);
                playerAnimationBehaviour.PlayJumpAnimation();
                _canJump = false;
            }
        }              
    }
    public void OnOpen(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            
        }
    }
    public void OnAttack1(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            playerAnimationBehaviour.PlayAttackAnimation1();
        }
    }
    public void OnAttack2(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            playerAnimationBehaviour.PlayAttackAnimation2();
        }
    }
    public void OnShootWea(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            playerAnimationBehaviour.PlayShootAnimation();
        }
    }
}
