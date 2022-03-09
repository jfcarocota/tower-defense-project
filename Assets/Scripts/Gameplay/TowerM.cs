using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerM : Tower
{
    [SerializeField]
    Transform spawnPointDownRight;
    [SerializeField]
    Transform spawnPointDownLeft;

    public override void ReciveDamage(int damage)
    {
        base.ReciveDamage(damage);
    }

    public override string ToString()
    {
        return base.ToString();
    }

    protected override void Attack()
    {
        base.Attack();
        //left bullet
        GameObject goR = Instantiate<GameObject>(projectile.gameObject, spawnPointDownRight.position, rotator.rotation);
        Projectile pR = goR.GetComponent<Projectile>();
        pR.SetDamage(damage);
        //right bullet
        GameObject goL = Instantiate<GameObject>(projectile.gameObject, spawnPointDownLeft.position, rotator.rotation);
        Projectile pL = goL.GetComponent<Projectile>();
        pL.SetDamage(damage);
    }

    protected override IEnumerator Shooting()
    {
        Attack();
        yield return new WaitForSeconds(attackRate);
        Attack();
        yield return new WaitForSeconds(0.1f);
        Attack();
        yield return new WaitForSeconds(0.1f);
        if(target)
        {
            StartShooting();
        }
    }
}
