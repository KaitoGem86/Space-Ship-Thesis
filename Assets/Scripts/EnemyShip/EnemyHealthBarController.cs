using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBarController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer container;
    [SerializeField] private SpriteRenderer healthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealth(float percent)
    {
        Vector2 size = container.size;
        size.x = container.size.x * percent;
        size.y = healthBar.size.y;
        healthBar.size = size;
    }
}
