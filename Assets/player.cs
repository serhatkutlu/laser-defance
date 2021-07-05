using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float movespeed = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var deltax = Input.GetAxis("Horizontal") * Time.deltaTime*movespeed;
        var deltay = Input.GetAxis("Vertical") * Time.deltaTime*movespeed;
        var newxpos = transform.position.x + deltax;
        var newypos = transform.position.y + deltay;
        transform.position = new Vector2(newxpos,newypos);
    }
}
