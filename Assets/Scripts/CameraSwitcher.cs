using UnityEngine;
using System.Collections;

public class CameraSwitcher : MonoBehaviour 
{
	public GameObject mainCamera;
	public Transform camera2;
	public Transform camera3;
	public Transform camera4; 
	public Transform resetCamera;

	public int counter = 1;


	// Use this for initialization
	void Start () 
	{
		
		
	}
	
	// Update is called once per frame
	void Update ()
	{

        //Debug.Log(counter);

		if (counter == 1)
		{
            changeCameraDirection(camera2, camera4, 2, 4);
		}
        else if (counter == 2)
        {
            changeCameraDirection(camera3, resetCamera, 3, 1);
        }
        else if (counter == 3)
        {
            changeCameraDirection(camera4, camera2, 4, 2);
        }
        else if (counter == 4)
        {
            changeCameraDirection(resetCamera, camera3, 1, 3);
        }
		
	}

    public void changeCameraDirection(Transform cameraForward, Transform cameraBack, int counterForward, int counterBack)
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            mainCamera.transform.position = cameraForward.transform.position;
            mainCamera.transform.rotation = cameraForward.transform.rotation;

            counter = counterForward;


            Debug.Log(counter);
            Debug.Log(mainCamera.transform.position);
            Debug.Log(mainCamera.transform.rotation.eulerAngles);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            mainCamera.transform.position = cameraBack.transform.position;
            mainCamera.transform.rotation = cameraBack.transform.rotation;

            counter = counterBack;


            Debug.Log(counter);
            Debug.Log(mainCamera.transform.position);
            Debug.Log(mainCamera.transform.rotation.eulerAngles);
        }
    }
		
}
