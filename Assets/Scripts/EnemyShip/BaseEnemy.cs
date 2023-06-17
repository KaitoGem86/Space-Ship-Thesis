using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private EnemyHealthBarController healthBar;
    [SerializeField] DropItemControll dropItem;
    //[SerializeField] protected BulletController bullet;

    private Vector2 direction;
    private Vector2 rotateDirection;

    private float speed = 2;
    private EnemyPool pool;

    private float dameAgainstPlayer = 1;

    private float maxHp = 10;
    private float hp;

    public EnemyPool Pool
    {
        get { return pool; }
        set { pool = value; }
    }

    public Vector2 RotateDirection
    {
        get { return rotateDirection; }
        set { rotateDirection = value; }
    }

    public Vector2 Direction
    {
        get { return direction; }
        set { direction = value; }
    }

    public float DameAgainstPlayer
    {
        get { return dameAgainstPlayer; }
    }

    public float Speed
    {
        get { return this.speed; }
        set { speed = value; }
    }

    public float Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public float MaxHp
    {
        get { return maxHp; }
        set { maxHp = value; }
    }

    public virtual void Move()
    {

        direction.Normalize();
        //Vector2 pos = this.transform.position;
        //pos += direction * speed * Time.deltaTime * 2;
        //this.transform.position = pos;
        rb.velocity = direction.normalized * speed;
    }

    public virtual void Rotate()
    {
        Quaternion t = Quaternion.LookRotation(rotateDirection, Vector3.back);
        t.x = 0;
        t.y = 0;
        this.transform.rotation = t;
        //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, t, 0.1f);
    }

    public virtual void Die()
    {
        this.gameObject.SetActive(false);
        dropItem.InstantiatePos = this.transform.position;
        dropItem.InstantiateItem();
        this.Pool.num -= 1;
        if (this.Pool.num == 0)
        {
            this.Pool.gameObject.SetActive(false);
        }
    }


    public virtual void Dame(PlayerController player, float dame)
    {
        player.Hp -= dame;
        UIManager.instance.UpdateHp(player.Hp, player.MaxHP);
        if (player.Hp < 0)
        {
            GameManager.instance.GameOver();
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerShip"))
        {
            Dame(collision.GetComponent<PlayerController>(), dameAgainstPlayer);
        }
    }

    public virtual void SetPostion()
    {
        Vector2 pos = new Vector2();
        pos = GameManager.instance.motherSpaceEnemy.transform.position;
        this.transform.position = pos;
    }

    public virtual void UpdateHealth()
    {
        healthBar.SetHealth(this.hp / this.maxHp);
    }

    protected virtual void Attack()
    {
    }
}
