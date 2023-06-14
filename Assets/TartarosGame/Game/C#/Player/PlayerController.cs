using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class PlayerController : Character
{
    [Header("Sub Behaviours")]
    public PlayerBehaviourC playerAnimationBehaviour;
    public PlayerWeapons _weaponsStack;
    public PlayerMovement _playerMovement;
    public WeaponController _weaponController;
    public HealthBarController _healthBarController;
    public Abilities _abilities;
    [Header("Input Settings")]
    [SerializeField] public PlayerInput playerInput;   
    private float _isRotate;
    private float _isMovement;
    [SerializeField] private bool _isdash=false;
    private void Start()
    {
       
    }
    private void Update()
    {
      
    }
    private void FixedUpdate()
    {
       
        _playerMovement.SiMueve(_isMovement);
        _playerMovement.SiRota(_isRotate);
        _playerMovement.SiDash(_isdash);
    }
    public void UpdateLife(float damage)
    {
        _life += damage;
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
    public void OnDash(InputAction.CallbackContext value)
    {
        if (value.started && !_abilities.isCooldown4)
        {
            _abilities.doIt4 = value.started;
            StartCoroutine(DuracionDash());
         }
    }
    public void OnAttack1(InputAction.CallbackContext value)
    {
        if (value.started && !_abilities.isCooldown1)
        {
            _abilities.doIt1 = value.started;
            playerAnimationBehaviour.PlayAttackAnimation1();
            _playerMovement.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
    public void OnAttack2(InputAction.CallbackContext value)
    {
        if (value.started && !_abilities.isCooldown2)
        {
            _abilities.doIt2 = value.started;
            playerAnimationBehaviour.PlayAttackAnimation2();
            _playerMovement.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
    public void OnShootWea(InputAction.CallbackContext value)
    {
        if (value.started && !_abilities.isCooldown3)
        {
            _abilities.doIt3 = value.started;
            if (_weaponsStack._weaponsStack.Count>0)
            {
                playerAnimationBehaviour.PlayShootAnimation();
                Debug.Log(_weaponsStack._weaponsStack.Top.value._name);
                Weapons tmp = Instantiate(_weaponsStack._weaponsStack.Top.value,_playerMovement.inFront.position, transform.rotation);
                tmp.gameObject.SetActive(true);
                Vector3 shoot = new Vector3(_playerMovement.inFront.position.x - transform.position.x, (_playerMovement.inFront.position.y - transform.position.y)/2, _playerMovement.inFront.position.z - transform.position.z);
                tmp.SetUpVelocity(shoot, _playerMovement.movementSpeed*2, _weaponsStack._weaponsStack.Top.value.tag);
                tmp._active = false;
                _weaponsStack._weaponsStack.Pop();
                _weaponsStack._gameObjStack.Pop();
            }
        }
    }
    IEnumerator DuracionDash()
    {
        _isdash = true;
        yield return new WaitForSecondsRealtime(0.4f);
        _isdash = false;
    }   
}
