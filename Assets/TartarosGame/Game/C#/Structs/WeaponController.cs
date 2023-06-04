using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WeaponController : MonoBehaviour
{
    [SerializeField] PlayerWeapons _playerWeapons;
    public event Action<float, HealthBarController> onHitEnemy;
    public int score;
    private void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            score += 20;
            onHitEnemy?.Invoke(_playerWeapons._weaponsStack.Top.value._damage, other.GetComponent<EnemyReaction>()._healthBarController);
            //other.GetComponent<EnemyReaction>().UpdateLife(_playerWeapons._weaponsStack.Top.value._damage);
            Debug.Log(_playerWeapons._weaponsStack.Top.value._damage);
        }
    }
}
