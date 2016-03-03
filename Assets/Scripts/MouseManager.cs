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


        if (Physics.Raycast(ray, out hit))
        {
            GameObject ourHitObject = hit.collider.transform.gameObject;
            SpawnBuilding(ourHitObject);
            Debug.Log("Raycast hit: " + ourHitObject.name);
            
        }
	
	}

    void SpawnBuilding(GameObject ourHitObject)
    {
        BuildingManager bm = GameObject.FindObjectOfType<BuildingManager>();
        TileColorChange tileColourChange = ourHitObject.GetComponent<TileColorChange>();

        if (Input.GetMouseButtonUp(0) && ourHitObject.tag == "Tile" && tileColourChange.clickable == true && tileColourChange.tileAbove.GetComponent<TileColorChange>().clickable == true)
        {
            if(bm.selectedBuilding.tag == "Factory" && tileColourChange.tileAbove != null )
            {
                tileColourChange.clickable = false;
                tileColourChange.tileAbove.GetComponent<TileColorChange>().clickable = false;

                tileColourChange.GetComponent<MeshRenderer>().material.color = Color.white;
                tileColourChange.tileAbove.GetComponent<MeshRenderer>().material.color = Color.white;


                Instantiate(bm.selectedBuilding, new Vector3(ourHitObject.transform.position.x + bm.selectedBuilding.transform.position.x, ourHitObject.transform.position.y + bm.selectedBuilding.transform.position.y, ourHitObject.transform.position.z + bm.selectedBuilding.transform.position.z), bm.selectedBuilding.transform.rotation);
            }
            if(bm.selectedBuilding.tag == "Tower")
            {
                tileColourChange.clickable = false;
                tileColourChange.GetComponent<MeshRenderer>().material.color = Color.white;

                Instantiate(bm.selectedBuilding, new Vector3(ourHitObject.transform.position.x + bm.selectedBuilding.transform.position.x, ourHitObject.transform.position.y + bm.selectedBuilding.transform.position.y, ourHitObject.transform.position.z + bm.selectedBuilding.transform.position.z), bm.selectedBuilding.transform.rotation);

            }

        }
    }

    void DestroyBuilding(GameObject ourHitObject)
    {

    }

    void findBuildingUIButtons()
    {

    }

   
}
