using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip1 : PlayerController
{

    private void Update()
    {
        Move();
        Attack();
    }

    protected override void Move()
    {
        base.Move();

        var t = Quaternion.LookRotation(InputController.Instance.GetInputMove(),Vector3.back);
        t.x = 0;
        t.y = 0;
        transform.rotation = t;
    }

    protected override void Attack()
    {
        base.Attack();
    }
}
