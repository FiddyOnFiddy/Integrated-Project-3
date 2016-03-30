using UnityEngine;
using System.Collections;

public class CameraZoomScript : MonoBehaviour 
{
    public Camera mainCamera;

	// Use this for initialization
	void Start () 
    {
        mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            mainCamera.orthographicSize -= 0.25f;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            mainCamera.orthographicSize += 0.25f;
        }

	}
}
