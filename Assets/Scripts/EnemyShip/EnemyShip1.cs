using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip1 : BaseEnemy
{
    //[SerializeField] BulletSpawner spawner;

    private PlayerController target;
    private GameObject motherSpaceEnemy;
    private float rangeAttack = 10;
    private float timer = 3;
    [SerializeField] private EnemyWeapon weapon;

    public GameObject MotherSpaceEnemy
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


    public override void SetPostion()
    {
        Vector2 pos = new Vector2();
        pos = motherSpaceEnemy.transform.position;
        this.transform.position = pos;
        this.Hp = this.MaxHp;
    }

    protected override void Attack()
    {
        if (Vector2.Distance(target.transform.position, this.transform.position) < rangeAttack && timer <= 0)
        {
            weapon.Attack();
            timer = 3;
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerShip"))
        {
            Dame(collision.gameObject.GetComponent<PlayerController>(), this.DameAgainstPlayer);
            this.gameObject.SetActive(false);
        }
    }
}
