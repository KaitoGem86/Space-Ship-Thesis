using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip1 : BaseEnemy
{
    //[SerializeField] BulletSpawner spawner;

    private PlayerController target;
    private float distance = 0.3f;
    private MotherSpaceEnemy motherSpaceEnemy;

    public MotherSpaceEnemy MotherSpaceEnemy
    {
        get { return motherSpaceEnemy; }
        set { motherSpaceEnemy = value; }
    }

    private void Start()
    {
        this.MaxHp = 20;
        this.Hp = this.MaxHp;
        this.SetPostion();
        target = GameManager.instance.currentShip;
        this.Speed = Random.Range(1.5f, 3f);
    }
    //Update is called once per frame
    void Update()
    {
        this.Attack();
    }

    public override void Die()
    {
        base.Die();
    }

    public override void SetPostion()
    {
        Vector2 pos = new Vector2();
        pos = motherSpaceEnemy.transform.position;
        this.transform.position = pos;
        this.Hp = this.MaxHp;
    }

    //protected override void Attack()
    //{
    //    if(Vector2.Distance(target.transform.position, this.transform.position) < distance)
    //    {
    //        Instantiate(bullet, this.transform.position, Quaternion.FromToRotation(this.Direction, this.Direction));
    //    }
    //}
}
