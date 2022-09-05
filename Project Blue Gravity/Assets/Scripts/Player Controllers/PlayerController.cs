using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // System Move Click
    [Header("BASE MOVMENTS")]

    Rigidbody2D rb;

    public bool moveClick; // if move to click

    [Range(0,3)]
    public float speed = 1; //speed move player

    [Space (10)]

    // move click system
    [Header("MOVE CLICK SYSTEM")]
    public GameObject clickFx; // prefab to click fx
    public Transform dirMovePlayer; // Get object orientation to move player to it
    public Transform LookingDirection; // Transform object look in direction Click for move RigidBody in foward direction

    Vector2 lastClickPosition; // Save last Click to move player

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); // get rigidbody
    }

    void Update()
    {
        Vector2 direction = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); // Get directions controllers

        // MOVMENTS
        if(direction.magnitude > 0) // if directions in use
        {
            moveClick = false; // cancele move click
            rb.velocity = direction * speed; // velocity rigidbody Player is equal controllers direction in velocity float speed

            float angle = Mathf.Atan2(-rb.velocity.x, rb.velocity.y) * Mathf.Rad2Deg; // Get angle of movement direction.
            LookingDirection.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // "LookingDirection" object Look at direction move.
        }
        else if (moveClick == true && (Vector2)transform.position != (Vector2)dirMovePlayer.position) // Else if bool moveClick true and position "Player" not igual position "dirMovePlayer".
        {
            rb.velocity = LookingDirection.up * speed; // move Player in direction click in velocity float speed

            // SYSTEM IN TRANSFORM MOVMENT !!!!! Bad system for moving around, checking speeds, checking directions and more. !!!!!
            //float step = speed * Time.deltaTime;
            //transform.position = Vector2.MoveTowards(transform.position, dirMovePlayer.position, step);
        }
        else 
        {
            rb.velocity = Vector2.zero;
            dirMovePlayer.gameObject.SetActive(false); // desactive object to orient direction click
            moveClick = false; //Desactive system move click
        }

        // MOVE CLICK SYSTEM
        if (Input.GetMouseButtonDown(1)) // If press down Mouse Button Right
        {
            lastClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get position mouse/click
            GameObject instantiateFx = Instantiate(clickFx) as GameObject; // create object FX
            instantiateFx.transform.position = new Vector2(lastClickPosition.x, lastClickPosition.y); //Position to FX

            dirMovePlayer.gameObject.SetActive(true);// active object to orient direction click
            dirMovePlayer.position = instantiateFx.transform.position; // Moves the object that guides the player's direction to the mouse click position

            Vector2 directionMove = new Vector2(dirMovePlayer.position.x - LookingDirection.position.x, dirMovePlayer.position.y - LookingDirection.position.y); // Get Direction move
            LookingDirection.transform.up = directionMove; // "LookingDirection" object Look at direction click.

            moveClick = true; //Active system move click
        }
    }
}
