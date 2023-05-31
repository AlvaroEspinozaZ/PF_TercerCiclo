using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] public Weapons[] _arrayWeapons;
    [SerializeField] GameObject _handWeapon;
    [SerializeField] Weapons _handWeaponStats;
    [SerializeField] int  _handWeaponStatsCounr;
    public MyStructs.Stack<Weapons> _weaponsStack;
    public MyStructs.Stack<GameObject> _gameObjStack;
    private void Start()
    {
        _weaponsStack= new MyStructs.Stack<Weapons>();
        _gameObjStack = new MyStructs.Stack<GameObject>();
        _handWeapon.SetActive(false);
    }
    private void Update()
    {
        _handWeaponStatsCounr = _weaponsStack.Count;
        if (_weaponsStack.Count > 0)
        {
            _handWeapon.GetComponent<MeshFilter>().mesh = _gameObjStack.Top.value.GetComponent<MeshFilter>().mesh;
            _handWeaponStats = _weaponsStack.Top.value;
            _handWeapon.SetActive(true);
        }
        else
        {
            _handWeapon.SetActive(false);
        }
    }
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "1")        {
            _weaponsStack.Push(other.GetComponent<Weapons>());
            _gameObjStack.Push(other.GetComponent<Weapons>().SetGameObject());
            other.gameObject.transform.position=new Vector3(0,1000,0);
            //other.gameObject.SetActive(false);
            Debug.Log(_weaponsStack.Count + "-" + _gameObjStack.Count);
            Debug.Log(_weaponsStack.Top.value.name);            
        }        
    }
    public void SetWeaponst()
    {
     
    }
}