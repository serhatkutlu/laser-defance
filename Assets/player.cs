using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float movespeed = 10;
    float MinX,MaxX,MinY,MaxY;
    [SerializeField] float paddle,projectile,projectilefiringperiod;
    [SerializeField]GameObject laserprefab;
    Coroutine firingcoroutine;

    
    void Start()
    {
        SetUpMoveBoundaries();
       
    }

    private void SetUpMoveBoundaries()
    {
        MinX = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x + paddle;
        MaxX = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x - paddle;
        MinY = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).y + paddle;
        MaxY = Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f, 0f)).y - paddle;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        fire();
    }

    private void fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingcoroutine = StartCoroutine(firecontinously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingcoroutine);
        }
    }
    IEnumerator firecontinously()
    {
        while (true)
        {

            GameObject laser = Instantiate(laserprefab, transform.position, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectile);
            yield return new WaitForSeconds(projectilefiringperiod);
        }
    }

    private void Move()
    {
        var deltax = Input.GetAxis("Horizontal") * Time.deltaTime*movespeed;
        var deltay = Input.GetAxis("Vertical") * Time.deltaTime*movespeed;
        var newxpos =Mathf.Clamp( transform.position.x + deltax,MinX,MaxX);
        var newypos = Mathf.Clamp( transform.position.y + deltay,MinY,MaxY) ;
        transform.position = new Vector2(newxpos,newypos);
    }
}
