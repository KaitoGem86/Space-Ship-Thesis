using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private Vector2 direction;
    private float speed = 2;

    private float dameAgainstPlayer = 1;

    private float hp = 10;
    private float maxHp = 10;

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

    public virtual void Move()
    {   

        direction.Normalize();
        Quaternion t = Quaternion.LookRotation(direction, Vector3.back);
        t.x = 0;
        t.y = 0;

        //Vector2 pos = this.transform.position;
        //pos += direction * speed * Time.deltaTime * 2;
        //this.transform.position = pos;
        rb.velocity = direction * speed;

        this.transform.rotation = t;
    }

    public virtual void Die()
    {
        this.gameObject.SetActive(false);
    }


    public virtual void Dame(PlayerController player,float dame)
    {
        player.Hp -= dame;
        if (player.Hp < 0)
        {
            player.gameObject.SetActive(false);
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

    protected virtual void SetPostion()
    {
        Vector2 pos = new Vector2();
        pos = GameManager.instance.motherSpaceEnemy.transform.position;
        this.transform.position = pos;
    }
}
