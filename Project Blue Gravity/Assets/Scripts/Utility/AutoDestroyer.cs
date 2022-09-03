using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyer : MonoBehaviour
{
    public bool destroyByTime = false;
    public float time = 0;

    void Start()
    {
        if(destroyByTime) // if bool true:
        StartCoroutine("TimeToDestroy");
    }
    
    IEnumerator TimeToDestroy()
    {
        yield return new WaitForSeconds(time); // time to execute

        Destroy(gameObject);
    }

    public void StartDestroy() // Set comand in animation
    {
        Destroy(gameObject);
    }
}
