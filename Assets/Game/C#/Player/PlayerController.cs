using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : Character
{
    [Header("Sub Behaviours")]
    public PlayerBehaviourC playerAnimationBehaviour;
    public PlayerWeapons _weaponsStack;
    [Header("Input Settings")]
    [SerializeField] public PlayerInput playerInput;
    [Header("Movement Settings")]    
    [SerializeField] Transform inFront;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] public float movementSpeed = 3f;
    [SerializeField] public float turnSpeed = 200f;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private bool _canJump=false;
    [SerializeField]  float _isRotate;
    [SerializeField] float _isMovement;
    [Header("Raycast")]
    [SerializeField] private LayerMask myLayers;
    [SerializeField] private float distanceModifier = 0.03f;
    private void OnEnable()
    {
       
    }
    void Update()
    {
        Gravity();
        SiRota(_isRotate);
        SiMueve(_isMovement);
        MakeRaycast();
       
        
    }
    private void Gravity()
    {
        if (!_canJump)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * 2, transform.position.z);
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
    
    public void onTurnThePlayer(InputAction.CallbackContext value)
    {        
        _isRotate = value.ReadValue<float>();
    }
    public void SiRota(float _isRotate)
    {
        transform.Rotate(0, _isRotate * turnSpeed * Time.deltaTime, 0);
    }
    public void onMovementPlayer(InputAction.CallbackContext value)
    {
        _isMovement = value.ReadValue<float>();   
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
            if (_weaponsStack._weaponsStack.Count>0)
            {
                playerAnimationBehaviour.PlayShootAnimation();
                Debug.Log(_weaponsStack._weaponsStack.Top.value._name);
                Weapons tmp = Instantiate(_weaponsStack._weaponsStack.Top.value, inFront.position, inFront.rotation);         
                _weaponsStack._weaponsStack.Pop();
                _weaponsStack._gameObjStack.Pop();
            }
        }
    }
   
}
