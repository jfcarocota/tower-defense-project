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

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

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
    }

    protected virtual void Movement()
    {
        //transform.Translate(transform.forward * moveSpeed * Time.deltaTime);
    }
}
