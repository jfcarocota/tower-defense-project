using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LivingObject : MonoBehaviour
{
    [SerializeField]
    protected int health;

    public virtual void ReciveDamage(int damage)
    {
        health = health - damage > 0 ? health - damage : 0;
    }

    protected virtual void CheckStillAlive()
    {
        
    }
}
