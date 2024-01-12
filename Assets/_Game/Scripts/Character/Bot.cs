using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    [SerializeField] private Rigidbody _rb;
    IState<Bot> currentState;
    public  NavMeshAgent agent;
    public Vector3 winPoint;
    private Vector3 dir;
    public bool Isdir => Vector3.Distance(dir,Vector3.right*transform.position.x+Vector3.forward*transform.position.z)<0.1f;

    public void Start()
    {
       ChangeColor(ColorType.Red);
       agent = GetComponent<NavMeshAgent>();
        ChangeState(new PatrolState());
    }
   private void Update()
    {
        if (currentState !=null )
        {
            currentState.OnExcute(this);
            CanMove(transform.position);
        }
        

    }
    
    public void ChangeState(IState<Bot> state)
    {
        if (currentState !=null)
        {
            currentState.OnExit(this);
        }
        currentState = state;
        if (currentState !=null)
        {
            currentState.OnEnter(this);
        }
    }
    public void SetPointDestination(Vector3 position)
    {
        dir = position;
        dir.y = 0;
        agent.SetDestination(position);
    }
    
    
}
