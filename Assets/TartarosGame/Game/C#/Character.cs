using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] public float _damage;
    [SerializeField] public float _life;
    [SerializeField] public string _name;
    [SerializeField] public float _movementSpeed;
    [SerializeField] public bool _active=true;
    [SerializeField] public GameObject _gameObecjtWea;
    [SerializeField] public Sprite _spriteWea;

    private void Start()
    {
       
    }
    public void UpdateLife()
    {

    }
    public void setStats(float damage, string name)
    {
        this._damage = damage;
        this._name = name;
    }
    public void UpdateStats()
    {

    }
  
}
