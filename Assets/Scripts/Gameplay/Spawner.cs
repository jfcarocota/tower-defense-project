using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    [SerializeField]
    Enemy boss;
    [SerializeField]
    Enemy bossClone;

    void Start()
    {
        enemiesQueue = new Queue<Enemy>();
         //InitBoss
        GameObject goBoss = Instantiate<GameObject>(boss.gameObject, transform.position, Quaternion.identity);
        goBoss.SetActive(false);
        bossClone = goBoss.GetComponent<Enemy>();
        //Init normal enemies
        foreach(Enemy enemy in enemies)
        {
            GameObject go = Instantiate<GameObject>(enemy.gameObject, transform.position, Quaternion.identity);
            go.SetActive(false);
            enemiesQueue.Enqueue(go.GetComponent<Enemy>());
        }
        //Add boss
        enemiesQueue.Enqueue(bossClone);
        StartSpawn();
    }

    void StartSpawn()
    {
        //Init spawning
        spawn = Spawn();
        StartCoroutine(spawn);
    }

    //Activate some enemy and remove from queue
    void SpawnObject() => enemiesQueue.Dequeue().gameObject.SetActive(true);

    //Controling spawn rate
   IEnumerator Spawn()
   {
       SpawnObject();
       yield return new WaitForSeconds(spawnRate);
       if(!GameManager.Instance.CurrentGameMode.LoseGame && bossClone != null);
       {
           StartSpawn();
       }
   }

   public Enemy GetBossClone => bossClone;
}
