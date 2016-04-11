﻿using UnityEngine;
using System.Collections;

public class CameraSnap : MonoBehaviour
{
    public static void CameraSnapOverTarget(Transform targetPos)
    {
        GameObject camera = Camera.main.gameObject;
        camera.transform.parent = targetPos;
        
        camera.transform.position = targetPos.position +  new Vector3(0, 28f, -6f);
        camera.transform.parent = null;

        camera.transform.LookAt(new Vector3(0, 0, 0));
    }

    
    //void Update()
    //{
    //    Debug.DrawLine(transform.position, Vector3.zero, Color.blue);
    //}
}