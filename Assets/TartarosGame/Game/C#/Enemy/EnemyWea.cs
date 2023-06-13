using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyWea : MonoBehaviour
{
    [SerializeField] public EnemyReaction _enemyReaction;
    [SerializeField] public GameObject Frente;
    [SerializeField] public GameObject body;
    [SerializeField] public float forfe;
    public event Action<float, HealthBarController> onHitPlayer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {            
            onHitPlayer?.Invoke(_enemyReaction._damage, other.GetComponent<HealthBarController>());
            Vector3 tmp = new Vector3(Frente.transform.position.x - body.transform.position.x,0, Frente.transform.position.z - body.transform.position.z);
            
                other.GetComponent<Rigidbody>().AddForce(tmp * forfe, ForceMode.Impulse);      
           
        }
    }
}