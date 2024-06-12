using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    public GameObject[] baseEnemy;
    public GameObject[] bossEnemy;
    ObjectPool[] baseEnemyPool;
    ObjectPool[] bossEnemyPool;
    public GameObject[] spawn;
    public static float delay;
    float bossDelay;
    int random;
    int enemyNumber;
    void Start()
    {
        GetEnemyPool();
        delay = 3f;
        bossDelay = 25f;
        enemyNumber = 0;
        StartCoroutine(GeneralTimer());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator GeneralTimer() 
    {
        while (true)
        {
            Coroutine cor1 = StartCoroutine(SpawnTimer(baseEnemyPool, delay));
            yield return new WaitForSeconds(bossDelay);
            StopCoroutine(cor1);
            Coroutine cor2 = StartCoroutine(SpawnTimer(bossEnemyPool, 1f));
            yield return new WaitForSeconds(1f);
            StopCoroutine(cor2);
            enemyNumber++;
            if (enemyNumber > baseEnemy.Length)
            {
                enemyNumber = baseEnemy.Length - 1;
            }
            bossDelay = Mathf.Max(5f, bossDelay - 1f);
        }
    }
    IEnumerator SpawnTimer(ObjectPool[] enemyPool, float delay)
    {
        while (true)
        {
            random = Random.Range(0, enemyNumber);
            yield return new WaitForSeconds(delay);
            SpawnLocation(enemyPool[random]);
        }

    }
    void SpawnLocation(ObjectPool enemyPool)
    {
        GameObject enemy = enemyPool.SharedInstance.GetPooledObject();
        if (enemy != null)
        {
            enemy.transform.position = spawn[Random.Range(0, spawn.Length)].transform.position;
            enemy.SetActive(true);
        }
    }
    void GetEnemyPool()
    {
        baseEnemyPool = new ObjectPool[baseEnemy.Length];
        for (int i = 0; i < baseEnemy.Length; i++)
        {
            baseEnemyPool[i] = baseEnemy[i].GetComponent<ObjectPool>();
        }
        bossEnemyPool = new ObjectPool[bossEnemy.Length];
        for (int i = 0; i < bossEnemy.Length; i++)
        {
            bossEnemyPool[i] = bossEnemy[i].GetComponent<ObjectPool>();
        }
    }
}
