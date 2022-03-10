using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Hostile
{
    [SerializeField]
    protected Transform rotator;
    protected Enemy target;
    [SerializeField]
    protected Projectile projectile;
    [SerializeField]
    protected Transform spawnPoint;

    [SerializeField]
    List<GameObject> projectiles;

    IEnumerator shooting;

    protected bool canAttak = true;

    //Basically instantiate a bullet, it could have awesome implement an object pooling but no time :C
    protected override void Attack()
    {
        base.Attack();
        GameObject go = Instantiate<GameObject>(projectile.gameObject, spawnPoint.position, rotator.rotation);
        Projectile p = go.GetComponent<Projectile>();
        p.SetDamage(damage);
    }

    protected override void CheckStillAlive()
    {
        base.CheckStillAlive();
    }

    new void Update()
    {
        base.Update();
    }

    protected void StartShooting()
    {
        shooting = Shooting();
        StartCoroutine(shooting);
    }

    //Fire a bullet
    protected virtual IEnumerator Shooting()
    {
        Attack();
        yield return new WaitForSeconds(attackRate);
        if(target && canAttak)
        {
            StartShooting();
        }
    }

    //Not always can attack, this resets the checker of attack
    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(attackRate);
        canAttak = true;
    }

    //Seek for enemies and start fire.
    private void OnTriggerStay(Collider other)
    {
        if(canAttak)
        {
            if(other.CompareTag("Enemy") && !target)
            {
                canAttak = false;
                StartCoroutine(ResetAttack());
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
}
