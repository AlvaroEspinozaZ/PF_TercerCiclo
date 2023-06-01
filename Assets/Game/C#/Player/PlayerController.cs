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
    [SerializeField] private Quaternion qy = Quaternion.identity;
    [SerializeField] private Quaternion r = Quaternion.identity;
    [SerializeField] private float rot=0;
    private float anguloSen;
    private float anguloCos;
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
        MakeRaycast();      
    }
    private void FixedUpdate()
    {
        SiMueve(_isMovement);
        SiRota(_isRotate);
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
        else
        {
            _canJump = false;
        }
        Debug.DrawRay(transform.position, new Vector2(0, - 1).normalized * distanceModifier, Color.red);
    } 
    
    public void onTurnThePlayer(InputAction.CallbackContext value)
    {        
        _isRotate = value.ReadValue<float>();
    }
    public void SiRota(float _isRotate)
    {
        rot += _isRotate * Time.deltaTime* turnSpeed;
        anguloSen = Mathf.Sin(Mathf.Deg2Rad * rot * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * rot * 0.5f);
        qy.Set(0, anguloSen, 0, anguloCos);

        r = qy ;
        transform.rotation = r;
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
                Weapons tmp = Instantiate(_weaponsStack._weaponsStack.Top.value,inFront.position, transform.rotation);
                tmp.gameObject.SetActive(true);
                tmp.SetUpVelocity(inFront.position-transform.position, movementSpeed, _weaponsStack._weaponsStack.Top.value.tag);
                tmp.Update();
                tmp._active = false;
                _weaponsStack._weaponsStack.Pop();
                _weaponsStack._gameObjStack.Pop();
            }
        }
    }
   
}
