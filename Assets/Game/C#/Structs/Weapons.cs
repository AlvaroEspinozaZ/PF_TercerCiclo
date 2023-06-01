using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] public float _damage;
    [SerializeField] public int id;
    [SerializeField] public string _name;
    [SerializeField] public bool _active = false;
    [SerializeField] Rigidbody _rgb;
    [Header("Raycast")]
    [SerializeField] private LayerMask myLayers;
    [SerializeField] private float distanceModifier = 0.15f;
    [SerializeField] private bool _canJump = false;

    void Start()
    {
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
    }
    IEnumerator BeAWeaponOnGame()
    {
        yield return new WaitForSecondsRealtime(4);
        this.tag = "1";
    }
    IEnumerator fly()
    {
        yield return new WaitForSecondsRealtime(2);
        _rgb = null;
    }


}
