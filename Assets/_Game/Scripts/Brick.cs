using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : ColorObject
{
    [HideInInspector] public Stage stage;

    private void Start()
    {
        ChangeColor((ColorType)Random.Range(1,3));
    }
    public void OnDespawn()
    {
        stage.AddEmtyPoint(transform.position);
    }

}
