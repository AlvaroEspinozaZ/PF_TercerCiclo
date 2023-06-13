using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyReaction : Character
{
    [SerializeField] public Rigidbody rgb;
    [SerializeField] public bool _atacar=false;
    [SerializeField] public HealthBarController _healthBarController;
    public event Action<bool> onHitToPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            rgb.AddForce(Vector3.up,ForceMode.Impulse);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(AttackOn());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _atacar = false;
    }


    IEnumerator AttackOn()
    {
        Debug.Log("Arrr");
        onHitToPlayer?.Invoke(_atacar);
        _atacar = true;
        yield return new WaitForSecondsRealtime(0.55f);
        _atacar = false;
    }
}
