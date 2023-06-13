using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private Quaternion qy = Quaternion.identity;
    [SerializeField] private Quaternion r = Quaternion.identity;
    [SerializeField] private float rot = 0;
    private float anguloSen;
    private float anguloCos;
    [SerializeField] public Transform inFront;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] public float movementSpeed = 3f;
    [SerializeField] public float turnSpeed = 200f;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private bool _canJump = false;
    [SerializeField] float _isRotate;
    [SerializeField] float _isMovement;
    [Header("Raycast")]
    [SerializeField] private LayerMask myLayers;
    [SerializeField] private float distanceModifier = 0.03f;
    void Update()
    {
        Gravity();
        MakeRaycast();
    }
    private void FixedUpdate()
    {
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
        if (Physics.Raycast(transform.position, new Vector3(0, -1, 0), out hit, distanceModifier, myLayers))
        {
            //Debug.Log(hit.transform.tag);
            _canJump = true;
        }
        else
        {
            _canJump = false;
        }
        Debug.DrawRay(transform.position, new Vector2(0, -1).normalized * distanceModifier, Color.red);
    }
    public void SiRota(float _isRotate)
    {
        rot += _isRotate * Time.deltaTime * turnSpeed;
        anguloSen = Mathf.Sin(Mathf.Deg2Rad * rot * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * rot * 0.5f);
        qy.Set(0, anguloSen, 0, anguloCos);

        r = qy;
        transform.rotation = r;
    }
    public void SiMueve(float _isMovement)
    {
        Vector3 tmp = new Vector3(inFront.position.x - transform.position.x, 0, inFront.position.z - transform.position.z);
        playerRigidbody.velocity = tmp * _isMovement * movementSpeed;
    }
    public void _Jump(InputAction.CallbackContext value, PlayerBehaviourC playerAnimationBehaviour)
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
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Escalera")
        {
            Vector3 tmp = new Vector3(0, inFront.position.y - transform.position.y, 0);
            playerRigidbody.velocity = tmp * _isMovement * movementSpeed;
        }
    }*/
}
