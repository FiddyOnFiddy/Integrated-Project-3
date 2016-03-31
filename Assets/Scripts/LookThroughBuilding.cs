using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class LookThroughBuilding : MonoBehaviour 
{
    public GameObject currentObject;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject ourHitObject = hit.collider.transform.gameObject;
            DetectBuilding(ourHitObject);
            Debug.DrawRay(ray.origin, ray.direction * 500.0f, Color.red);
        }
	
	}


    void DetectBuilding(GameObject ourHitObject)
    {
        if (ourHitObject.tag == "Clean Factory" || ourHitObject.tag == "Water Tower" || ourHitObject.tag == "Science Building" || ourHitObject.tag == "Tower")
        {
            currentObject = ourHitObject;

            SpriteRenderer buildingToOmit = ourHitObject.GetComponent<SpriteRenderer>();

            Color tempCol = buildingToOmit.color;
            tempCol.a = 0.5f;
            buildingToOmit.color = tempCol;

            ourHitObject.GetComponent<BoxCollider>().enabled = false;

            Debug.Log(buildingToOmit.color);
        }
        else
        {
            if (currentObject != null)
            {
                if(Input.GetMouseButtonUp(1))
                {
                    currentObject.GetComponent<BoxCollider>().enabled = true;
                    SpriteRenderer buildingToOmit = currentObject.GetComponent<SpriteRenderer>();

                    Color tempCol = buildingToOmit.color;
                    tempCol.a = 1.0f;
                    buildingToOmit.color = tempCol;
                }
            }
        }
    }
}
