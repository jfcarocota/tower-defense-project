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

    public void SetDamage(int damage) => base.damage = damage;

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

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.ReciveDamage(damage);
            Destroy(gameObject);
        }
    }
}
