using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TestCamLookAt : MonoBehaviour
{
    GameObject cam;
    void Start()
    {
       cam = Camera.main.gameObject;
    }

	void Update ()
    {
        cam.transform.LookAt(Vector3.zero);
	}
}
