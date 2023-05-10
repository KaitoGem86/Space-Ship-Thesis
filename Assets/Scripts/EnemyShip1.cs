using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip1 : BaseEnemy
{
    private PlayerController target;
    private float distance = 0.3f;

    private void Start()
    {
        target = GameManager.instance.currentShip;
    }
    //Update is called once per frame
    void Update()
    {
        this.Move();
    }

    protected override void Move()
    {
        if (Vector2.Distance(target.transform.position, this.transform.position) < distance)
            return;
        this.Direction = target.transform.position - this.transform.position;
        base.Move();
    }


}
