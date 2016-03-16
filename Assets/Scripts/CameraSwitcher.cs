using UnityEngine;
using System.Collections;

public class CameraSwitcher : MonoBehaviour 
{
	public GameObject mainCamera;
	public Transform camera2;
	public Transform camera3;
	public Transform camera4; 
	public Transform defaultTransform;

	public int counter = 0;

	// Use this for initialization
	void Start () 
	{
		defaultTransform = mainCamera.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.Q) && counter == 0)
		{
			mainCamera.transform.position = camera2.position;
			mainCamera.transform.rotation = camera2.rotation;

			counter = 1;

			Debug.Log (mainCamera.transform.position);
			Debug.Log (mainCamera.transform.rotation.eulerAngles);
		}	

		if (Input.GetKeyUp (KeyCode.Q) && counter == 0)
	}
}
