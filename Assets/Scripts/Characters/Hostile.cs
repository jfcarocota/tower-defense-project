using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostile : Character
{
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected string enemyTag;
    [SerializeField]
    protected LayerMask enemyLayer;

    public int GetDamage => damage;
}
