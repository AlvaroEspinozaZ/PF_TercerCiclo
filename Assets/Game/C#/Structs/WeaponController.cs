using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] PlayerWeapons _playerWeapons;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemt>().UpdateLife(_playerWeapons._weaponsStack.Top.value._damage);
            Debug.Log(_playerWeapons._weaponsStack.Top.value._damage);
        }
    }
}
