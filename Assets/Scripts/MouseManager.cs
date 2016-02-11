using UnityEngine;
using System.Collections;

public class MouseManager : MonoBehaviour 
{
    public GameObject placeableTile;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            GameObject ourHitObject = hit.collider.transform.gameObject;

            //Detecting which face of the building/placeable tile is clicked
            Vector3 localPoint = hit.transform.InverseTransformPoint(hit.point);
            Vector3 localDir = localPoint.normalized;

            float upDot = Vector3.Dot(localDir, Vector3.up);
            float fwdDot = Vector3.Dot(localDir, Vector3.forward);
            float rightDot = Vector3.Dot(localDir, Vector3.right);

            float upPower = Mathf.Abs(upDot);
            float fwdPower = Mathf.Abs(fwdDot);
            float rightPower = Mathf.Abs(rightDot);

            Debug.Log("Raycast hit: " + ourHitObject.name);

            if (Input.GetMouseButtonUp(0) && ourHitObject.tag == "Tile" || Input.GetMouseButtonUp(0) && ourHitObject.tag == "Building" && upDot > 0.0f && upPower > fwdPower && upPower > rightPower)
            {
                GameObject placeableTile_go = (GameObject)Instantiate(placeableTile, new Vector3(ourHitObject.transform.position.x, ourHitObject.transform.position.y + 1, ourHitObject.transform.position.z), Quaternion.identity);
            }
            if(Input.GetMouseButtonUp(1) && ourHitObject.tag == "Building")
            {
                Destroy(ourHitObject);           
            }
        }
	
	}

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 30), "Left Click: Place block");
        GUI.Label(new Rect(10, 40, 300, 30), "Right Click: Delete block");
    }
}
