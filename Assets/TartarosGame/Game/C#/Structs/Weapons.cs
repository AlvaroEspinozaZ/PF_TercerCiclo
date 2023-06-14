using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Weapons : MonoBehaviour
{
    [SerializeField] public float _damage;
    [SerializeField] public float impulse;
    [SerializeField] public float impulse2;
    [SerializeField] public int id;
    [SerializeField] public string _name;
    [SerializeField] public bool _active = false;
    [SerializeField] Rigidbody _rgb;  
    private void Start()
    {
        StartCoroutine(BeAWeaponOnGame());
    }
    public void Update()
    {
    }
    public void SetUpVelocity(Vector3 velocityVector,float velocity, string newTag)
    {
        _rgb.velocity = velocityVector * velocity;
        gameObject.tag = newTag;
        //myAudio.CreateSound(); SoundsScritableO myAudio
    }
    public GameObject SetGameObject()
    {
        return this.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _active = true;
        }
        if (other.gameObject.tag == "Enemy")
        {
            if (!_active)
            {
                Debug.Log("aver");
                Vector3 tmp = new Vector3(other.transform.position.x - transform.position.x, 0, other.transform.position.z - transform.position.z);
                if (other.GetComponent<EnemyC>()._enemyMovement.rgb.velocity.magnitude > 0.01f)
                {
                    other.GetComponent<EnemyC>()._enemyMovement.rgb.AddForce(tmp * impulse2, ForceMode.Impulse);
                }
                else
                {
                    other.GetComponent<EnemyC>()._enemyMovement.rgb.AddForce(tmp * impulse, ForceMode.Impulse);
                }
                
            }
            
        }
    }
    IEnumerator BeAWeaponOnGame()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        _active = true;
    }
    IEnumerator fly()
    {
        yield return new WaitForSecondsRealtime(2);
        _rgb = null;
    }


}
