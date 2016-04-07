using UnityEngine;
using System.Collections;

public class TileColorChange : MonoBehaviour
{
    BuildingManager bm;
    public GameObject tileUp1;
    public GameObject tileUp2;
    public GameObject tileUp3;
    public GameObject tileUp4;

	public GameObject tileLeft;

	public GameObject tileLeftUp1;
    public GameObject tileLeftUp2;
    public GameObject tileLeftUp3;
    public GameObject tileLeftUp4;
   
    MeshRenderer thisMr;
    MeshRenderer mrUp1;
	MeshRenderer mrUp2;
	MeshRenderer mrUp3;
    MeshRenderer mrUp4;

    MeshRenderer mrLeft;
    MeshRenderer mrLeftUp1;
    MeshRenderer mrLeftUp2;
    MeshRenderer mrLeftUp3;
    MeshRenderer mrLeftUp4;

	public BuildingData buildingData;

    public bool clickable = true;

    // Use this for initialization
    void Start()
    {
        bm = GameObject.FindObjectOfType<BuildingManager>();
        tileUp1 = GameObject.Find("Tile: " + (gameObject.transform.position.x + 1) + "_" + gameObject.transform.position.z);
        tileUp2 = GameObject.Find("Tile: " + (gameObject.transform.position.x + 2) + "_" + gameObject.transform.position.z);
        tileUp3 = GameObject.Find("Tile: " + (gameObject.transform.position.x + 3) + "_" + gameObject.transform.position.z);
        tileUp4 = GameObject.Find("Tile: " + (gameObject.transform.position.x + 4) + "_" + gameObject.transform.position.z);
 
		tileLeft = GameObject.Find("Tile: " + (gameObject.transform.position.x) + "_" + (gameObject.transform.position.z + 1));
		tileLeftUp1 = GameObject.Find("Tile: " + (gameObject.transform.position.x + 1) + "_" + (gameObject.transform.position.z + 1));
        tileLeftUp2 = GameObject.Find("Tile: " + (gameObject.transform.position.x + 2) + "_" + (gameObject.transform.position.z + 1));
        tileLeftUp3 = GameObject.Find("Tile: " + (gameObject.transform.position.x + 3) + "_" + (gameObject.transform.position.z + 1));
        tileLeftUp4 = GameObject.Find("Tile: " + (gameObject.transform.position.x + 4) + "_" + (gameObject.transform.position.z + 1));



        thisMr = this.gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    { 
		if (clickable == true)
        {
            thisMr.material.color = Color.red;

       
            if (bm.selectedBuilding.tag == "Factory"  || bm.selectedBuilding.tag == "Science Building" || bm.selectedBuilding.tag == "Solar Panel")
            {
				if (tileUp1 != null)
                {
                    mrUp1 = tileUp1.GetComponent<MeshRenderer>();
                    mrUp1.material.color = Color.red;
                }
            }

			if (bm.selectedBuilding.tag == "Water Tower") 
			{
				if (tileUp1 != null)
				{
					mrUp1 = tileUp1.GetComponent<MeshRenderer>();
					mrUp1.material.color = Color.red;
				}
			}

            if (bm.selectedBuilding.tag == "Clean Factory")
            {
                if (tileUp1 != null && tileUp2 != null && tileUp3 != null && tileUp4 != null && tileLeft != null && tileLeftUp1 != null && tileLeftUp2 != null && tileLeftUp3 != null && tileLeftUp4 != null)
                {
                    //First row of tiles for building
                    mrUp1 = tileUp1.GetComponent<MeshRenderer>();
                    mrUp1.material.color = Color.red;

                    mrUp2 = tileUp2.GetComponent<MeshRenderer>();
                    mrUp2.material.color = Color.red;

                    mrUp3 = tileUp3.GetComponent<MeshRenderer>();
                    mrUp3.material.color = Color.red;

                    mrUp4 = tileUp4.GetComponent<MeshRenderer>();
                    mrUp4.material.color = Color.red;

                    //Left row of tiles for building
                    mrLeft = tileLeft.GetComponent<MeshRenderer>();
                    mrLeft.material.color = Color.red;

                    mrLeftUp1 = tileLeftUp1.GetComponent<MeshRenderer>();
                    mrLeftUp1.material.color = Color.red;

                    mrLeftUp2 = tileLeftUp2.GetComponent<MeshRenderer>();
                    mrLeftUp2.material.color = Color.red;

                    mrLeftUp3 = tileLeftUp3.GetComponent<MeshRenderer>();
                    mrLeftUp3.material.color = Color.red;

                    mrLeftUp4 = tileLeftUp4.GetComponent<MeshRenderer>();
                    mrLeftUp4.material.color = Color.red;
                }
            }
        }
        
    }
    void OnMouseExit()
    {

        if (clickable == true)
        {
            thisMr.material.color = Color.white;

            if (bm.selectedBuilding.tag == "Factory" || bm.selectedBuilding.tag == "Science Building" || bm.selectedBuilding.tag == "Solar Panel")
            {
                if (tileUp1 != null)
                {
                    mrUp1 = tileUp1.GetComponent<MeshRenderer>();
                    mrUp1.material.color = Color.white;
                }
            }

            if (bm.selectedBuilding.tag == "Water Tower")
            {
                if (tileUp1 != null)
                {
                    mrUp1 = tileUp1.GetComponent<MeshRenderer>();
                    mrUp1.material.color = Color.white;
                }
            }

            if (bm.selectedBuilding.tag == "Clean Factory")
            {
                if (tileUp1 != null && tileUp2 != null && tileUp3 != null && tileUp4 != null && tileLeft != null && tileLeftUp1 != null && tileLeftUp2 != null && tileLeftUp3 != null && tileLeftUp4 != null)
                {
                    //First row of tiles for building
                    mrUp1 = tileUp1.GetComponent<MeshRenderer>();
                    mrUp1.material.color = Color.white;

                    mrUp2 = tileUp2.GetComponent<MeshRenderer>();
                    mrUp2.material.color = Color.white;

                    mrUp3 = tileUp3.GetComponent<MeshRenderer>();
                    mrUp3.material.color = Color.white;

                    mrUp4 = tileUp4.GetComponent<MeshRenderer>();
                    mrUp4.material.color = Color.white;

                    //Left row of tiles for building
                    mrLeft = tileLeft.GetComponent<MeshRenderer>();
                    mrLeft.material.color = Color.white;

                    mrLeftUp1 = tileLeftUp1.GetComponent<MeshRenderer>();
                    mrLeftUp1.material.color = Color.white;

                    mrLeftUp2 = tileLeftUp2.GetComponent<MeshRenderer>();
                    mrLeftUp2.material.color = Color.white;

                    mrLeftUp3 = tileLeftUp3.GetComponent<MeshRenderer>();
                    mrLeftUp3.material.color = Color.white;

                    mrLeftUp4 = tileLeftUp4.GetComponent<MeshRenderer>();
                    mrLeftUp4.material.color = Color.white;
                }
            }
        }
        
    }
}
