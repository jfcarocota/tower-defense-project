using System.Collections;
using System.Collections.Generic;
using ICSharpCode.NRefactory.Ast;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Hostile
{
    [SerializeField]
    protected float moveSpeed;
    NavMeshAgent navMeshAgent;
    [SerializeField, Range(1, 100)]
    protected int points = 1;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    //waiting for gamemanager init
    private IEnumerator Start()
    {
        while(true)
        {
            if(GameManager.Instance.CurrentGameMode)
            {
                navMeshAgent.destination = GameManager.Instance.CurrentGameMode.GetCurrentBase.transform.position;
                break;
            }
            yield return null;
        }
    }

    new void Update()
    {
        base.Update();
        Movement();
    }

    protected override void Attack()
    {
        base.Attack();
    }

    protected override void CheckStillAlive()
    {
        base.CheckStillAlive();
        if(health == 0)
        {
            GameManager.Instance.CurrentGameMode.GetScore.AddPoints(points);
            Destroy(gameObject);
        }
    }

    protected virtual void Movement()
    {
        //transform.Translate(transform.forward * moveSpeed * Time.deltaTime);
    }
}
