using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    public  NavMeshAgent agent;
    public Transform winPoint;
    private void Start()
    {
        ChangeColor(ColorType.Red);
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        agent.destination=winPoint.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstranName.Brick))
        {
            Brick brick = other.GetComponent<Brick>();
            if (brick.colorType == colorType)
            {
                brick.OnDespawn();

                AddBrick();

                Destroy(brick.gameObject);
            }
        }


    }
}
