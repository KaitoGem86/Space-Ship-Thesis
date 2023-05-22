using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{   
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        FollowCharacter();
    }

    void FollowCharacter()
    {

        target = GameManager.instance.currentShip.gameObject;
        Vector3 position = transform.position;
        position.x = target.transform.position.x;
        position.y = target.transform.position.y + 1.5f;
        if (position.x < 2.2f)
            position.x = 2.2f;
        if (position.x > 58.5f)
            position.x = 58.5f;
        if (position.y < -7.8f)
            position.y = -7.8f;
        if (position.y > 58.5f)
            position.y = 58.5f;
        transform.position = position;
    }

}