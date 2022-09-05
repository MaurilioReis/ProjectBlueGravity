using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AreaZoom : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCam;

    public float lensOrthoSizeEnter = 3; // size cam / Zoom enter
    public float lensOrthoSizeExit = 5;  // size cam / Zoom exit
    public float smooth = 1; // smoth to time

    float valueZoom; 
    bool activeZoom = false;

    public bool oculSpriteInGame = false;


    private void Start()
    {
        if(oculSpriteInGame == true) // If hiding the Sprite in game.
        {
            SpriteRenderer ocultSprite = gameObject.GetComponent<SpriteRenderer>(); // Get component SpriteRenderer this object
            ocultSprite.enabled = false; // Desactive component
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") // active zoom
        {
            activeZoom = true;
            valueZoom = lensOrthoSizeEnter;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") // desactive zoom
        {
            activeZoom = true;
            valueZoom = lensOrthoSizeExit;
        }
    }

    private void FixedUpdate()
    {
        if (activeZoom == true && virtualCam.m_Lens.OrthographicSize != valueZoom) // if in activeZoom and VirtualCam value is different from variable "valueZoom"
        {
            if (virtualCam.m_Lens.OrthographicSize < valueZoom) // Zoom in
            {
                virtualCam.m_Lens.OrthographicSize += Time.deltaTime * smooth;
            }
            
            if (virtualCam.m_Lens.OrthographicSize > valueZoom) // Zoom out
            {
                virtualCam.m_Lens.OrthographicSize -= Time.deltaTime * smooth;
            }
        }
    }
}
