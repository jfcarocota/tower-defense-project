using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : LivingObject
{
    [SerializeField]
    protected float attackRate;

    protected void Update()
    {

    }

    protected virtual void Attack()
    {

    }
}
