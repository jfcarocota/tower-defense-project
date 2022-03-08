using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : LivingObject
{

  public override void ReciveDamage(int damage)
  {
    base.ReciveDamage(damage);
  }

  protected override void CheckStillAlive()
    {
        base.CheckStillAlive();
        if(health > 0)
        {
            
        }
    }
}
