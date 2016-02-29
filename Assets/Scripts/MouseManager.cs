using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour 
{
    public GameObject placeableTile;
    public float xOffset = -0.25f;
    public float yOffSet = 1.0f;
    public float zOffset = -0.25f;


	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            GameObject ourHitObject = hit.collider.transform.gameObject;
            MouseOverTile(ourHitObject);

            //Debug.Log("Raycast hit: " + ourHitObject.name);
            
        }
	
	}

    void MouseOverTile(GameObject ourHitObject)
    {
        BuildingManager bm = GameObject.FindObjectOfType<BuildingManager>();
        TileColorChange tileColourChange = ourHitObject.GetComponent<TileColorChange>();

        if (Input.GetMouseButtonUp(0) && ourHitObject.tag == "Tile")
        {
            if(bm.selectedBuilding.tag == "Factory" && tileColourChange.tileAbove != null )
            {
                Instantiate(bm.selectedBuilding, new Vector3(ourHitObject.transform.position.x + bm.selectedBuilding.transform.position.x, ourHitObject.transform.position.y + bm.selectedBuilding.transform.position.y, ourHitObject.transform.position.z + bm.selectedBuilding.transform.position.z), bm.selectedBuilding.transform.rotation);
            }
            if(bm.selectedBuilding.tag == "Tower")
            {
                Instantiate(bm.selectedBuilding, new Vector3(ourHitObject.transform.position.x + bm.selectedBuilding.transform.position.x, ourHitObject.transform.position.y + bm.selectedBuilding.transform.position.y, ourHitObject.transform.position.z + bm.selectedBuilding.transform.position.z), bm.selectedBuilding.transform.rotation);
            }

        }
    }

   
}
