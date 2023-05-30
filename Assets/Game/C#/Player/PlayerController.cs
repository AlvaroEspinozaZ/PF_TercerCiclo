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
    [SerializeField]  float _isRotate;
    [SerializeField] float _isMovement;
    [Header("Raycast")]
    [SerializeField] private LayerMask myLayers;
    [SerializeField] private float distanceModifier = 0.03f;

    void Update()
    {
        SiRota(_isRotate);
        SiMueve(_isMovement);
        MakeRaycast();
       if (!_canJump)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime*2, transform.position.z);
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

        _isRotate = value.ReadValue<float>();
        //transform.Rotate(0,  inputMovement * turnSpeed, 0);
    }
    public void SiRota(float _isRotate)
    {
        transform.Rotate(0, _isRotate * turnSpeed * Time.deltaTime, 0);
    }
    public void onMovementPlayer(InputAction.CallbackContext value)
    {
        _isMovement = value.ReadValue<float>();            
        //Vector3 tmp = new Vector3(inFront.position.x-transform.position.x, transform.position.y, inFront.position.z - transform.position.z);
        //Vector3 inputMovement = new Vector3(transform.position.x, value.ReadValue<SnapAxis>(), transform.position.z);

        //playerRigidbody.velocity = transform.position *inputMovement * movementSpeed;
        //playerRigidbody.velocity = new Vector3(tmp.x, playerRigidbody.velocity.y, tmp.z) * inputMovement * movementSpeed;
        //Debug.Log(playerRigidbody.velocity);
        //playerAnimationBehaviour.UpdateMovementAnimation(inputMovement);        
    }
    public void SiMueve(float _isMovement)
    {
        Vector3 tmp = new Vector3(inFront.position.x - transform.position.x, 0, inFront.position.z - transform.position.z);
        playerRigidbody.velocity = tmp * _isMovement *movementSpeed;
        playerAnimationBehaviour.UpdateMovementAnimation(_isMovement);
    }
    public void onJumpPlayer(InputAction.CallbackContext value)
    {
        if (_canJump)
        {
            if (value.started)
            {
                playerAnimationBehaviour.PlayJumpAnimation();
                playerRigidbody.AddForce(Vector3.up * movementSpeed * 20, ForceMode.Impulse);
                
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
