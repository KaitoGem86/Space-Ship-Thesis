using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    private void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 pos = transform.position;
        if (pos.y < -40f)
            pos.y = 40f;
        pos += Vector2.down * Time.deltaTime * 5;
        this.transform.position = pos;

    }
}
