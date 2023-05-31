using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] public float _damage;
    [SerializeField] public int id;
    [SerializeField] public string _name;
    [SerializeField] public bool _active = true;
    void Start()
    {
        _active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    public GameObject SetGameObject()
    {
        return this.gameObject;
    }

}
