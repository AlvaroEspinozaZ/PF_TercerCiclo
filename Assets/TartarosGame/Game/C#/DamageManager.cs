using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    [SerializeField] private PlayerController _playerC;
    [SerializeField] private EnemyC _enemyC;
    [SerializeField] private GameObject phisical;
    //[SerializeField] private List<>

    public void Start()
    {
        _enemyC._enemyWea.onHitPlayer += DamageCalculation;
        _playerC._weaponController.onHitEnemy += DamageCalculation;

        _enemyC._healthBarController.onDeath += Died;
    }  
    private void DamageCalculation(float damageTaken, HealthBarController healthBarController)
    {
        healthBarController.UpdateHealth(-damageTaken);
    }
    private void Died()
    {
        Destroy(_enemyC._Parent);
    }
   
}
