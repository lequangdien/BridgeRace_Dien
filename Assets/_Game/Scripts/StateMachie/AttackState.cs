using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState<Bot>
{
    public void OnEnter(Bot t)
    {
        //test tốn hiệu năng
      // Transform taget = GameObject.Find("WINPOINT").transform;
        t.SetPointDestination(t.winPoint);
    }

    public void OnExcute(Bot t)
    {
        if (t.BrickCount==0)
        {
            t.ChangeState(new PatrolState());
        }
    }

    public void OnExit(Bot t)
    {
       
    }
}
