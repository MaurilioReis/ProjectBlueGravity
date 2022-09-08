using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideOrOutside : MonoBehaviour
{
    public GameObject[] activeObjs; // selec objects ative
    public GameObject[] desactiveObjs; // selec objects desactive

    public bool enterTrigger = true; // select trigger in enter or exit

    private void OnTriggerEnter2D(Collider2D collision) // Enter
    {
        if (collision.tag == "Player" && enterTrigger == true) // if Player enter and bool enterTrigger == true
        {
            foreach (GameObject insideGo in activeObjs)
            {
                insideGo.SetActive(true); // Active Inside
            }

            foreach (GameObject outsideObj in desactiveObjs)
            {
                outsideObj.SetActive(false);// Desactive Outside
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision) // Exit
    {
        if (collision.tag == "Player" && enterTrigger == false) // if Player exit and bool enterTrigger == true
        {
            foreach (GameObject insideGo in activeObjs)
            {
                insideGo.SetActive(true); // Active Inside
            }

            foreach (GameObject outsideObj in desactiveObjs)
            {
                outsideObj.SetActive(false);// Desactive Outside
            }
        }
    }
}
