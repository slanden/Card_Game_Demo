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
    static float smoothing = 2.5f;
    static bool isRunning;
    static bool isAwayFromStartPos = false;
    static bool isNearDesiredHeight = false;

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

            #region make camera droop down during transition
            //float speed = 1f;
            //Vector3 ySine = Camera.main.transform.localPosition;

            //if (!isNearDesiredHeight)
            //{
            //    if ((toPos.y - ySine.y) >= 0.1f)
            //        isAwayFromStartPos = true;


            //    ySine.y = Mathf.Sin(Time.time * speed) * (ySine.y / 3) + ySine.y; //instead of 5, add transform's height in world space

            //    Camera.main.transform.localPosition = ySine;
            //    Debug.Log(ySine);
            //}
            //else if ((toPos.y - ySine.y) <= 0.1f && isAwayFromStartPos)
            //    isNearDesiredHeight = true;
            #endregion

            Camera.main.transform.LookAt(lookAt);   //camera always faces target

            yield return null;
        }

        Camera.main.transform.localPosition = toPos;    //the camera will be a hair away from it's target, unacceptable.
        Camera.main.transform.parent = null;

        isRunning = false;
        Debug.Log("Transition Done");
    }
}
