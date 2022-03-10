using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LivingObject : MonoBehaviour
{
    [SerializeField]
    protected int health;

    /// <summary>
    /// Returns the object health. I mean you are alive.
    /// </summary>
    public int GetHeatlh => health;

    //If you move it you can bleed. send an integer indicating the damage you want to make.
    public virtual void ReciveDamage(int damage)
    {
        health = health - damage > 0 ? health - damage : 0;
        CheckStillAlive();// im not using this
    }

    //It was a good idea on paper but at the end never used this. I keep it for a future feature
    protected virtual void CheckStillAlive()
    {
        
    }
}
