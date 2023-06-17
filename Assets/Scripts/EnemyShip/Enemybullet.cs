using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private Vector2 direction = Vector2.up;
    private float speed = 1;
    private float timer = 3;
    private float dameAgainstPlayer = 1;

    public Vector2 Direction
    {
        get { return direction; }
        set { direction = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        Direction = -transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (timer < 0)
            Destroy(gameObject);
        else
            timer -= Time.deltaTime;
    }

    private void Move()
    {
        rb.velocity = direction.normalized * speed * 10;
    }

    private void Dame(PlayerController player, float dame)
    {
        player.Hp -= dame;
        UIManager.instance.UpdateHp(player.Hp, player.MaxHP);
        if (player.Hp < 0)
        {
            GameManager.instance.GameOver();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PlayerShip"))
        {
            Dame(collision.gameObject.GetComponent<PlayerController>(), dameAgainstPlayer);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
