using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyC : MonoBehaviour
{
    [Header("Sub Behaviours")]
    public GameObject _Parent;
    public PlayerBehaviourC _playerAnimationBehaviour;
    public EnemyReaction _enemyReaction;
    public EnemyWea _enemyWea;
    public EnemyMovement _enemyMovement;
    public HealthBarController _healthBarController;
    public GameObject Weapon1;

    void Start()
    {       
        _enemyMovement.onMovementToPlayer += onMovementToPlayer;
        _enemyMovement.onRotationToPlayer += SiRota;
        _enemyReaction.onHitToPlayer += AtackEnemy;
    }

    void Update()
    {
    }
    private void FixedUpdate()
    {
            
    }
    public void AtackEnemy(bool atack)
    {
        if (atack)
        {
            Debug.Log("xqno ataco");
            _playerAnimationBehaviour.PlayEnemyAttackAnimation(); 
            StartCoroutine(WeaponOn());
            StartCoroutine(WeaponOf());
        }
        
    }
    public void SiRota(Transform other)
    {
        transform.LookAt(other.transform.position);
        /*rot += _isRotate * Time.deltaTime * turnSpeed;
        anguloSen = Mathf.Sin(Mathf.Deg2Rad * rot * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * rot * 0.5f);
        qy.Set(0, anguloSen, 0, anguloCos);
        r = qy;
        transform.rotation = r;*/
    }
    public void onMovementToPlayer(Transform other,Rigidbody rgb,float asd)
    {
        Vector3 tmp = new Vector3(_enemyMovement._infront.position.x - transform.position.x, 0, _enemyMovement._infront.position.z - transform.position.z);
        rgb.velocity = tmp * _enemyReaction._movementSpeed;
        transform.LookAt(other.transform.position);
        _playerAnimationBehaviour.UpdateMovementAnimation(asd);
        _enemyMovement._tevi = true;
        
    }
    private void OnTriggerEnter(Collider other)
    {        
    }
    private void OnTriggerStay(Collider other)
    {
    }
    private void OnTriggerExit(Collider other)
    {
    }
    IEnumerator WeaponOf()
    {
        yield return new WaitForSecondsRealtime(0.6f);
        Weapon1.GetComponent<BoxCollider>().enabled = false;
    }

    IEnumerator WeaponOn()
    {
        yield return new WaitForSecondsRealtime(0.55f);
        Weapon1.GetComponent<BoxCollider>().enabled = true;
    }
}
