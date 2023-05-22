using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyShip1AI : BaseEnemy
{
    private Transform target;
    private float nextWayPointDistance = 3f;

    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.instance.currentShip.transform;
        seeker = GetComponent<Seeker>();


        InvokeRepeating("UpdatePath", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        this.Rotate();
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    public override void Move()
    {
        if (path == null)
            return;
        if(currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath =false;
        }

        this.Direction = ((Vector2)path.vectorPath[currentWayPoint] - (Vector2)this.transform.position).normalized;
        //Vector2 force = direction * speed * Time.deltaTime;

        //rb.AddForce(force);
        base.Move();

        float distance = Vector2.Distance(this.transform.position, path.vectorPath[currentWayPoint]);
        
        if(distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }
    }

    public override void Rotate()
    {
        this.RotateDirection = target.transform.position - this.transform.position;
        if (this.RotateDirection.magnitude > 30)
            this.RotateDirection = this.Direction;
        base.Rotate();

    }

    void UpdatePath() 
    {
        if(seeker.IsDone())
        seeker.StartPath(this.transform.position, target.position, OnPathComplete);
    }
}
