using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Linq;

public class LookThroughBuilding : MonoBehaviour 
{
    //public GameObject currentObject;
    public List<GameObject> highlightedBuildings = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        BuildingReappear();


        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject ourHitObject = hit.collider.transform.gameObject;
            HideBuilding(ourHitObject);
            Debug.DrawRay(ray.origin, ray.direction * 500.0f, Color.red);
        }
	
	}


    void HideBuilding(GameObject ourHitObject)
    {
        if (ourHitObject.tag == "Clean Factory" || ourHitObject.tag == "Water Tower" || ourHitObject.tag == "Science Building" || ourHitObject.tag == "Tower" || ourHitObject.tag == "Factory")
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                highlightedBuildings.Add(ourHitObject);

                SpriteRenderer buildingToOmit = ourHitObject.GetComponent<SpriteRenderer>();
                Color tempCol = buildingToOmit.color;
                tempCol.a = 0.5f;
                buildingToOmit.color = tempCol;

                ourHitObject.GetComponent<BoxCollider>().enabled = false;

                Debug.Log(buildingToOmit.color);
            }

        }
    }

    void BuildingReappear()
    {
        if (Input.GetKeyUp(KeyCode.LeftAlt) && highlightedBuildings.Count > 0)
        {
            foreach (GameObject building in highlightedBuildings)
            {
                SpriteRenderer sr = building.GetComponent<SpriteRenderer>();
                Color tmpCol = sr.color;
                tmpCol.a = 1.0f;
                sr.color = tmpCol;

                building.GetComponent<BoxCollider>().enabled = true;
            }

            highlightedBuildings.Clear();
        }
    }
}
