using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyWea : MonoBehaviour
{
    [SerializeField] public EnemyReaction _enemyReaction;
    public event Action<float, HealthBarController> onHitPlayer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            onHitPlayer?.Invoke(_enemyReaction._damage, other.GetComponent<HealthBarController>());           
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            onHitPlayer?.Invoke(_enemyReaction._damage, other.GetComponent<HealthBarController>());
        }
    }
}
