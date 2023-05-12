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
        this.Speed = Random.Range(1.5f, 3f);
    }
    //Update is called once per frame
    void Update()
    {
        this.Move();
    }

    public override void Move()
    {
        if (Vector2.Distance(target.transform.position, this.transform.position) < distance)
            return;
        this.Direction = target.transform.position - this.transform.position;
        Debug.Log(this.Speed);

        base.Move();
    }

    public override void Die()
    {
        base.Die();
        this.SetPostion();
    }

    protected override void SetPostion()
    {
        Vector2 pos = new Vector2();
        pos = GameManager.instance.motherSpaceEnemy.transform.position;
        this.transform.position = pos;
    }
}
