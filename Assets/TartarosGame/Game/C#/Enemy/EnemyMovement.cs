using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyMovement : MonoBehaviour
{
    [Header("Movement Ene")]
    [SerializeField] public Rigidbody rgb;
    public event Action<Transform,Rigidbody, float> onMovementToPlayer;
    [Header("Rotate Ene")]
    [SerializeField] public Transform _infront;
    [SerializeField] public float turnSpeed = 200f;
    [SerializeField] public float asd = 0;
    [SerializeField] private Quaternion qy = Quaternion.identity;
    [SerializeField] private Quaternion r = Quaternion.identity;
    [SerializeField] private float rot = 0;
    public event Action<Transform> onRotationToPlayer;
    private float anguloSen;
    private float anguloCos;
    public bool _tevi = false;
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            onRotationToPlayer?.Invoke(other.transform);         
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            asd = 1;
            onMovementToPlayer?.Invoke(other.transform, rgb, asd);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("salio");
            _tevi = false;
            asd = 0;
            onMovementToPlayer?.Invoke(other.transform, rgb, asd);
        }
    }
}
