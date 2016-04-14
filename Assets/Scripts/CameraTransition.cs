using UnityEngine;
using System.Collections;

public class CameraTransition
{
    float smoothing = 0.01f;
    void CallCamera(Vector3 toPos, Vector3 lookAt)
    {
        //Vector3 fromPos = Camera.main.transform.position;

        //CamTransition(lookAt, fromPos, toPos);

    }

    public IEnumerator Transition(Transform target, Vector3 lookAt)
    {
        GameObject camera = Camera.main.gameObject;     // Find Main camera in Scene
        Vector3 fromPos = camera.transform.position;

         
        camera.transform.parent = target;               // Parents Camera to target's transform to insure posistion displacement is realtive to target
                

        
        while (Vector3.Distance(fromPos, target.position) > 1.05f)
        {
            camera.transform.localPosition = Vector3.Lerp(fromPos, new Vector3(0, 28f, -6f), smoothing * Time.deltaTime);
            Camera.main.transform.LookAt(lookAt);

            yield return null;
        }
        camera.transform.parent = null;                             // Un-Parent camera from target

        //Vector3 fromPos = Camera.main.transform.position;

        //while (Vector3.Distance(fromPos, toPos) > 1.05f)
        //{
        //    Camera.main.transform.position = Vector3.Lerp(fromPos, toPos, smoothing * Time.deltaTime);
        //    Camera.main.transform.LookAt(lookAt);

        //    yield return null;
        //}        

        Debug.Log("Transition Done");
    }
}
