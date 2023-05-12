using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] private Rigidbody2D rb;
    private PlayerController ship;

    private float time = 5f;
    private float speed = 1;
    private float dame = 1;

    private Vector2 direction;

    private void Start()
    {
        SetPosition();
    }


    void Update()
    {
        Move();
        DestroyBullet();
    }

    void Move()
    {
        var t = Quaternion.LookRotation(direction, Vector3.forward);
        t.x = 0;
        t.y = 0;
        transform.rotation = t;
        rb.velocity = direction * speed * 20;
    }

    void DestroyBullet()
    {
        if(time > 0)
            time -= Time.deltaTime;
        else
        {
            time = 5f;
            this.gameObject.SetActive(false);
            SetPosition();
        }
    }
    

    public void SetPosition()
    {
        direction = InputController.Instance.GetInputMove();
        direction.Normalize();
        ship = GameManager.instance.currentShip;
        transform.position = (Vector2)ship.transform.position + direction * 1f;
    }

    private void Damage(BaseEnemy enemy, float dame)
    {
        enemy.Hp -= dame;
        if (enemy.Hp < 0)
            enemy.Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyShip"))
        {
            Damage(collision.GetComponent<BaseEnemy>(), dame);
            this.gameObject.SetActive(false);
        }
    }
}
