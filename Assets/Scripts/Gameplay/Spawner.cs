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
        //init spawner routine
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
        if(enemiesQueue.Count > 0)
        {
            SpawnObject();
        }
        yield return new WaitForSeconds(spawnRate);
        if(CanSpawn)
        {
            StartSpawn();
        }
   }

    /// <summary>
    /// Get the boss of the current horde created in gameplay
    /// </summary>
    public Enemy GetBossClone => bossClone;

    //Check if boss in gameplay was defeated
    public bool BossDefeated => bossClone == null;

    /// <summary>
    /// If still alive and boss it's ok, then I can spawn more enemies
    /// </summary>
    bool CanSpawn => GameManager.Instance.CurrentGameMode.GetCurrentBase.GetHeatlh > 0 && bossClone != null;
}
