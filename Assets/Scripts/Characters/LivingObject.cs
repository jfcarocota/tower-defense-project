using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LivingObject : MonoBehaviour
{
    [SerializeField]
    protected int health;

    public virtual void ReciveDamage(int damage)
    {

    }

    protected virtual void CheckStillAlive()
    {
        
    }
}
