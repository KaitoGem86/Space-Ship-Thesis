using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : DropItem
{

    private PlayerController playerShip;
    private float health = 3;
    


    // Start is called before the first frame update
    void Start()
    {
        playerShip = GameManager.instance.currentShip;
    }

    // Update is called once per frame

    protected override void OnPickUp()
    {
        playerShip.Hp += health;
        if (playerShip.Hp > playerShip.MaxHP) 
        {
            playerShip.Hp = playerShip.MaxHP;
        }
        UIManager.instance.UpdateHp(playerShip.Hp, playerShip.MaxHP);
    } 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerShip"))
        {
            OnPickUp();
            Destroy(gameObject);
        }
    }
}
