using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] waweconfig wave;
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float speed;
    int waypointsindex=0;
    void Start()
    {
        waypoints = wave.GetWayPoints();
        
        transform.position = waypoints[waypointsindex].position;
    }

   
    void Update()
    {
        move(); 
    }

    private void move()
    {
        
        if (waypointsindex<=waypoints.Count-1)
        {
           
            var targetpos = waypoints[waypointsindex].transform.position;
            float movementspeed = Time.deltaTime * speed;
            transform.position = Vector2.MoveTowards(transform.position,targetpos,movementspeed);

            if (transform.position==targetpos)
            {
                waypointsindex++;
                print(4);
            }

        }
        else
        {
            Destroy(gameObject);
        }

    }
}
