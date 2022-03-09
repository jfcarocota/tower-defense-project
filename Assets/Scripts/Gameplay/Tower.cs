using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Hostile
{
    [SerializeField]
    Transform rotator;
    Enemy target;
    [SerializeField]
    Projectile projectile;
    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    List<GameObject> projectiles;

    IEnumerator shooting;
    float spawnTimer;

    private void Start()
    {
        spawnTimer = attackRate;
    }

    protected override void Attack()
    {
        base.Attack();
    }

    protected override void CheckStillAlive()
    {
        base.CheckStillAlive();
    }

    new void Update()
    {
        base.Update();
    }

    void StartShooting()
    {
        shooting = Shooting();
        StartCoroutine(shooting);
    }

    protected virtual IEnumerator Shooting()
    {
        GameObject go = Instantiate<GameObject>(projectile.gameObject, spawnPoint.position, Quaternion.identity);
        Projectile p = go.GetComponent<Projectile>();
        p.SetDamage(damage);
        go.transform.LookAt(target.transform);
        yield return new WaitForSeconds(attackRate);
        if(target)
        {
            StartShooting();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy") && !target)
        {
            target = other.GetComponent<Enemy>();
            rotator.LookAt(target.transform);
            StartShooting();
        }
        if(target)
        {
            rotator.LookAt(target.transform);
        }
    }
}
