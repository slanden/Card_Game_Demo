/*
    Usage:
            call the Transition coroutine when you wanna make the camera transition from 
            it's current location to another.

            void EndTurn()
            {
                StartCoroutine(CameraTransition.Transition(player.transform, Vector3.zero));
            }
*/

using UnityEngine;
using System.Collections;

public class CameraTransition : MonoBehaviour
{    
    static float smoothing = 2f;
    static bool isRunning;

    public static IEnumerator Transition(Transform target, Vector3 lookAt)
    {        
        //Vector3 fromPos = Camera.main.transform.position;   //this don't work because fromPos is set to camera position here, but
                                                              //is never updated with new position 'cause coroutine moves past this
                                                              //point and the position remains outside of the current position and
                                                              //new position range, rendering it invalid

        if(isRunning)         //since coroutines run as seperate instances, this will stop the new instance if one is already running
            yield break;

        isRunning = true;

        Camera.main.transform.parent = target;      // Parent camera to target's transform to insure relative position displacement

        Vector3 toPos = new Vector3(20.27f, 22.62f, -4.11f);

        while ((Camera.main.transform.localPosition - toPos).sqrMagnitude > 0.0005f)
        {
            Camera.main.transform.localPosition = Vector3.Lerp(Camera.main.transform.localPosition, 
                                             toPos, smoothing * Time.deltaTime);
            Camera.main.transform.LookAt(lookAt);   //camera always faces target

            yield return null;
        }

        Camera.main.transform.localPosition = toPos;    //the camera will be a hair away from it's target, unacceptable.
        Camera.main.transform.parent = null;

        isRunning = false;
        Debug.Log("Transition Done");
    }
}
