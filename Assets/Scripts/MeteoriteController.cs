using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;


    private Vector2 orbit = new Vector2(100, 100);
    private Vector2 direction;

    private float speed = 0.05f;
    private float range = 5;

    public float Speed
    {
        get => speed; 
        set => speed = value;
    }


    private void Start()
    {
        rb.AddForceAtPosition(new Vector2(0,Random.Range(-1,1)), new Vector2(0,Random.Range(-1,1)));
    }

    private void Update()
    {
        Move();
    }

    private void Move(){
        Vector2 dV =  (Vector2)this.transform.position - orbit;
        direction = new Vector2(dV.y, -dV.x).normalized;
        rb.velocity = direction * speed;

        //Vector2 qDir = new Vector2();
        Quaternion t = Quaternion.LookRotation( direction, Vector3.back);
        t.x = 0;
        t.y = 0;
        Quaternion.Slerp(this.transform.rotation, t, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerShip"))
        {
            GameManager.instance.GameOver();
        }
        if (collision.gameObject.CompareTag("EnemyShip"))
        {
            collision.gameObject.GetComponent<BaseEnemy>().Die();
            this.gameObject.SetActive(false);
        }
    }
}
