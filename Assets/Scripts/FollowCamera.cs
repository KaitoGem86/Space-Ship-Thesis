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
        position.y = target.transform.position.y;
        transform.position = position;
    }
}