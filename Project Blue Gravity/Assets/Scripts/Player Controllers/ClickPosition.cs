using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPosition : MonoBehaviour
{
    PlayerController pc; //Script Player Controller

    public GameObject clickFx; // prefab to click fx
    public Transform dirMovePlayer; // Get object orientation to move player to it

    Vector2 lastClickPosition; // Save last Click to move player

    void Start()
    {
        pc = gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // If press down Mouse Button Right
        {
            lastClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get position mouse/click
            GameObject instantiateFx = Instantiate(clickFx) as GameObject; // create object FX
            instantiateFx.transform.position = new Vector2(lastClickPosition.x, lastClickPosition.y); //Position to FX
            dirMovePlayer.position = instantiateFx.transform.position; // Moves the object that guides the player's direction to the mouse click position
            pc.moveClick = true; //Active system move click
        }
    }
}
