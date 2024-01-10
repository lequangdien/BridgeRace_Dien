using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PatrolState : IState<Bot>
{
    int target;
    public void OnEnter(Bot t)
    {
        target = Random.Range(2,7);
        FollowTarget(t);
    }

    public void OnExcute(Bot t)
    {
        if (t.Isdir)
        {
            if (t.BrickCount >=target)
            {
                t.ChangeState(new AttackState());
            }
            else
            {
                FollowTarget(t);
            }
        }
    }

    public void OnExit(Bot t)
    {
        
    }
    private void FollowTarget(Bot t)
    {

        if (t.stage != null)
        {
            Brick brick = t.stage.SeekBickPoint(t.colorType);
            if (brick == null)
            {
                t.ChangeState(new AttackState());
            }
            else
            {
                t.SetPointDestination(brick.transform.position);
            }
        }
        else
        {
            t.SetPointDestination(t.transform.position);
        }
    }
}
