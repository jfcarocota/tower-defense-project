using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    List<Enemy> enemies;
    Queue<Enemy> enemiesQueue;
    [SerializeField]
    int maxSpawn;
    [SerializeField, Range(0.1f, 10f)]
    float spawnRate;
    IEnumerator spawn;

    void Start()
    {
        enemiesQueue = new Queue<Enemy>(enemies);
        StartSpawn();
    }

    void StartSpawn()
    {
        spawn = Spawn();
        StartCoroutine(spawn);
    }

    void SpawnObject() => Instantiate<GameObject>(enemiesQueue.Dequeue().gameObject, transform.position, Quaternion.identity);

    public Queue<Enemy> GetEnemiesQueue => enemiesQueue;

   IEnumerator Spawn()
   {
       SpawnObject();
       yield return new WaitForSeconds(spawnRate);
       if(GameManager.Instance.CurrentGameMode.GetCurrentBase.GetHealth > 0 && enemiesQueue.Count > 0)
       {
           StartSpawn();
       }
   }
}
