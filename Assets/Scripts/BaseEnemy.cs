using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private Vector2 direction;
    private float speed = 2;

    public Vector2 Direction
    {
        get { return direction; }
        set { direction = value; }
    }

    protected virtual void Move()
    {   

        direction.Normalize();
        Quaternion t = Quaternion.LookRotation(direction, Vector3.back);
        t.x = 0;
        t.y = 0;

        Vector2 pos = this.transform.position;
        pos += direction * speed * Time.deltaTime*2;
        this.transform.position = pos;

        this.transform.rotation = t;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerShip"))
        {
            collision.gameObject.SetActive(false);
            GameManager.instance.GameOver();
        }
    }
}
