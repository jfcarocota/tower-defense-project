using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerM : Tower
{
    [SerializeField]
    Transform spawnPointDownRight;
    [SerializeField]
    Transform spawnPointDownLeft;

    protected override void Attack()
    {
        base.Attack();
        //left bullet
        GameObject goR = Instantiate<GameObject>(projectile.gameObject, spawnPointDownRight.position, Quaternion.identity);
        Projectile pR = goR.GetComponent<Projectile>();
        pR.SetDamage(damage);
        //right bullet
        GameObject goL = Instantiate<GameObject>(projectile.gameObject, spawnPointDownLeft.position, Quaternion.identity);
        Projectile pL = goL.GetComponent<Projectile>();
        pL.SetDamage(damage);

        goL.transform.LookAt(target.transform);
        goR.transform.LookAt(target.transform);
    }
}
