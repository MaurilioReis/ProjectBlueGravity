using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public bool moveClick; // if move to click

    [Range(0,3)]
    public float speed = 1; //speed move player

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); // Get directions controllers

        if(direction.magnitude > 0) // if directions in use
        {
            moveClick = false; // cancele move click
            rb.velocity = direction * speed;
        }
    }
}
