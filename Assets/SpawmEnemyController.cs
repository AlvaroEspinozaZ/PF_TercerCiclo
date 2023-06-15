using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmEnemyController : MonoBehaviour
{
    public MyStructs.CircularDoublyList<GameObject> enemysList;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform _pointInfront;


    void Start()
    {
        enemysList = new MyStructs.CircularDoublyList<GameObject>();
        StartCoroutine(StartSpwamsEnemys());
    }
    IEnumerator StartSpwamsEnemys()
    {
        GameObject tmpEnemy = Instantiate(enemyPrefab,_pointInfront.position,Quaternion.identity);
        enemysList.InsertAtStart(tmpEnemy);
        Debug.Log(enemysList.Count);
        yield return new WaitForSecondsRealtime(4f);
        StartCoroutine(StartSpwamsEnemys());
    }
}
