using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Hostile
{
    [SerializeField, Range(0.1f, 20f)]
    float keepAlive = 7f;
    float timer;
    [SerializeField, Range(0.1f, 20f)]
    float speed = 10f;

    IEnumerator destroyObject;

    void Start()
    {
        destroyObject = DestroyObject();
        StartCoroutine(destroyObject);
    }

    /// <summary>
    /// A projectile take its damage from a character, so plase send your damage when it's spawned
    /// </summary>
    /// <param name="damage"></param>
    public void SetDamage(int damage) => base.damage = damage;

    //Check how much time will be rendered this projectile.
    IEnumerator DestroyObject()
    {
        while(true)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            timer += Time.deltaTime;
            if(timer >= keepAlive)
            {
                Destroy(gameObject);
                yield break;
            }
            yield return null;
        }
    }

    //Check if I hit a bad guy
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            //GameManager.Instance.CurrentGameMode.HordeTotalHealth -= damage;
            enemy.ReciveDamage(damage);
            Destroy(gameObject);
        }
    }
}
