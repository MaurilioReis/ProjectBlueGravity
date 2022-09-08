using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Zoom : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCam;
    public float smooth = 1; // smoth to time
    public float valueZoom = 5; // value size cam

    private void FixedUpdate()
    {
        if (virtualCam.m_Lens.OrthographicSize != valueZoom) // VirtualCam value is different from variable "valueZoom"
        {
            if (virtualCam.m_Lens.OrthographicSize < valueZoom) // Zoom out
            {
                virtualCam.m_Lens.OrthographicSize += Time.deltaTime * smooth;
            }

            if (virtualCam.m_Lens.OrthographicSize > valueZoom) //  Zoom in
            {
                virtualCam.m_Lens.OrthographicSize -= Time.deltaTime * smooth;
            }
        }
    }


}
