using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyPool : MonoBehaviour
{
    public int num;

    public abstract void SetPosition();

    public abstract void SetEnemy();
}
