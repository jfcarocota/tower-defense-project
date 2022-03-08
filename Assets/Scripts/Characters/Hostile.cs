using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostile : MonoBehaviour
{
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected string enemyTag;
    [SerializeField]
    protected LayerMask enemyLayer;
}
