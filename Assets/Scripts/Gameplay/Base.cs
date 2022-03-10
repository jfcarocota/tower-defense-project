using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : LivingObject
{

    private IEnumerator Start()
    {
        while(true)
        {
            if(GameManager.Instance.CurrentGameMode)
            {
                GameManager.Instance.CurrentGameMode.GetHealthBar.InitHealth(health);
                break;
            }
            yield return null;
        }
    }

  public override void ReciveDamage(int damage)
  {
        base.ReciveDamage(damage);
        GameManager.Instance.CurrentGameMode.GetHealthBar.UpdateHealth(health);
  }

    protected override void CheckStillAlive()
    {
        base.CheckStillAlive();
        if(health > 0)
        {
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            ReciveDamage(enemy.GetDamage);
            Destroy(other.gameObject);
        }
    }

    public bool ImDead => health == 0;
}
