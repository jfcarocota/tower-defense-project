using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Hostile
{
    [SerializeField]
    Transform rotator;
    protected Enemy target;
    [SerializeField]
    protected Projectile projectile;
    [SerializeField]
    protected Transform spawnPoint;

    [SerializeField]
    List<GameObject> projectiles;

    IEnumerator shooting;

    protected override void Attack()
    {
        base.Attack();
        GameObject go = Instantiate<GameObject>(projectile.gameObject, spawnPoint.position, Quaternion.identity);
        Projectile p = go.GetComponent<Projectile>();
        p.SetDamage(damage);
        go.transform.LookAt(target.transform);
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
        Attack();
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
