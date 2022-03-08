using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    new void Update()
    {
        base.Update();
    }

    protected override void Attack()
    {
    base.Attack();
    }

    protected override void CheckStillAlive()
    {
    base.CheckStillAlive();
    }

    protected virtual void Movement()
    {

    }
}
