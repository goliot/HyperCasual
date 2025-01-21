using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private PoolManager poolManager;

    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float spawnTime;
    private float time = 0.0f;

    private void Update()
    {
        time += Time.deltaTime;
        if(time > spawnTime)
        {
            time = 0;
            Spawn();
            //StartCoroutine(CoSpawn());
        }
    }

    void Spawn()
    {
        GameObject spawnedEnemy = GameManager.Instance.poolManager.GetPoolObject(0);
        spawnedEnemy.transform.position = spawnPoint.position;
    }

    /*IEnumerator CoSpawn()
    {
        
    }*/
}
