using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaZoom : MonoBehaviour
{
    [Header("SYSTEM ZOOM IN AND OUT")]

    public Zoom scriptZoom;
    public bool triggerEnter = true;
    public float lensOrthoSizeEnter = 3; // size cam / Zoom enter
    public bool triggerExit = true;
    public float lensOrthoSizeExit = 5;  // size cam / Zoom exit
    public float smooth = 0.7f; // smooth / speed to zoom

    [Space(10)]
    [Header("SYSTEM LOCK CAM")]
    public bool lockCamTarget = false;
    public Transform targetCam;
    public Transform eyeCamFocus;
    GameObject markParent;

    [Space(10)]
    [Header("OCULT SPRITES IN GAME")]
    public bool ocultSpriteInGame = false;


    private void Start()
    {
        if(ocultSpriteInGame == true) // If hiding the Sprite in game.
        {
            SpriteRenderer ocultSprite = gameObject.GetComponent<SpriteRenderer>(); // Get component SpriteRenderer this object
            SpriteRenderer ocultSprite2 = ocultSprite.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>(); // Get component SpriteRenderer this object
            ocultSprite.enabled = false; // Desactive component
            ocultSprite2.enabled = false; // Desactive component
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") // active zoom
        {
            if (triggerEnter == true)
            {
                scriptZoom.valueZoom = lensOrthoSizeEnter; // Set value to zoom
                scriptZoom.smooth = smooth;
            }

            if (lockCamTarget == true) // if system lock cam == true
            {
                markParent = Instantiate(new GameObject ("MarkParent"), eyeCamFocus.transform.parent) as GameObject; // Created object in transform origin
                markParent.transform.position = eyeCamFocus.position;
                markParent.transform.localRotation = eyeCamFocus.localRotation;
                eyeCamFocus.parent = null;
                eyeCamFocus.position = targetCam.position; // Set position cam in Target
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") // desactive zoom
        {

            if (triggerExit == true)
            {
                scriptZoom.valueZoom = lensOrthoSizeExit; // Set value to zoom
                scriptZoom.smooth = smooth;
            }

            if (lockCamTarget == true) // if system lock cam == true
            {
                eyeCamFocus.parent = markParent.transform.parent; // Reset position cam in transform origin
                eyeCamFocus.localPosition = new Vector3(0, 0.309f, 0);
                eyeCamFocus.localRotation = markParent.transform.localRotation;
                Destroy(markParent); // Destroy transform origin
            }
        }
    }
}
