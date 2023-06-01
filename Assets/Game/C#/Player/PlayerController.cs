using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : Character
{
    [Header("Sub Behaviours")]
    public PlayerBehaviourC playerAnimationBehaviour;
    public PlayerWeapons _weaponsStack;
    public PlayerMovement _playerMovement;
    [Header("Input Settings")]
    [SerializeField] public PlayerInput playerInput;   
    private float _isRotate;
    private float _isMovement;
  
    private void FixedUpdate()
    {
        _playerMovement.SiMueve(_isMovement);
        _playerMovement.SiRota(_isRotate);
    }
   
    
    public void onTurnThePlayer(InputAction.CallbackContext value)
    {        
        _isRotate = value.ReadValue<float>();
    }
  
    public void onMovementPlayer(InputAction.CallbackContext value)
    {
        _isMovement = value.ReadValue<float>();
        playerAnimationBehaviour.UpdateMovementAnimation(_isMovement);
    }
    public void onJumpPlayer(InputAction.CallbackContext value)
    {
        _playerMovement._Jump(value, playerAnimationBehaviour);
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
                Weapons tmp = Instantiate(_weaponsStack._weaponsStack.Top.value,_playerMovement.inFront.position, transform.rotation);
                tmp.gameObject.SetActive(true);
                tmp.SetUpVelocity(_playerMovement.inFront.position-transform.position, _playerMovement.movementSpeed, _weaponsStack._weaponsStack.Top.value.tag);
                tmp._active = false;
                _weaponsStack._weaponsStack.Pop();
                _weaponsStack._gameObjStack.Pop();
            }
        }
    }
   
}
