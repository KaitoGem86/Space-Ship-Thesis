using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpItem : DropItem
{
    private PlayerController playerShip;
    private float exp = 5;
    // Start is called before the first frame update
    void Start()
    {
        playerShip = GameManager.instance.currentShip;

    }

    protected override void OnPickUp()
    {
        playerShip.Exp += exp;
        playerShip.BulletSpawner.Weapon.ChangeBullet();
        playerShip.BulletSpawner.SetBullet();
        if (playerShip.Exp > playerShip.ExpLimitation)
        {
            int nextLevel = (int)(playerShip.Exp / playerShip.ExpLimitation);
            playerShip.UpdateLevel(nextLevel);
            UIManager.instance.UpdateHp(playerShip.Hp, playerShip.MaxHP);
            playerShip.Exp = playerShip.Exp % playerShip.ExpLimitation;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerShip"))
        {
            OnPickUp();
            Destroy(gameObject);
        }
    }
}
