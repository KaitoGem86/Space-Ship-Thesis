using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] BulletData[] bulletDatas;
    public GameObject bulletPrefab;
    private int indexBullet = 0;

    public int IndexBullet
    {
        get { return indexBullet; }
        set { indexBullet = value; }
    }

    private void Start()
    {
        bulletPrefab = bulletDatas[indexBullet].bulletPrefab;
    }

    public void ChangeBullet()
    {
        Debug.Log("Change");
        this.indexBullet = (this.indexBullet + 1);
        if (indexBullet > bulletDatas.Length - 1)
        {
            indexBullet = bulletDatas.Length - 1;
        }
    }

    public GameObject SetBullet()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            indexBullet = (indexBullet + 1) % bulletDatas.Length;
        bulletPrefab = bulletDatas[indexBullet].bulletPrefab;
        return bulletPrefab;
    }
}
