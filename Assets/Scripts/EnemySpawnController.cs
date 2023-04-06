using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    //********************************
    //Unity method
    void Start()
    {
        StartCoroutine(SpawnNewEnemy());
    }

    void Update()
    {

    }
    //********************************



    //********************************
    //Corutinas
    IEnumerator SpawnNewEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            Instantiate(enemyPrefab);
        }
    }
}
