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

    MeshRenderer left;
    MeshRenderer leftUp1;
    MeshRenderer leftUp2;
    MeshRenderer leftUp3;
    MeshRenderer leftUp4;

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

       
			if (bm.selectedBuilding.tag == "Factory"  || bm.selectedBuilding.tag == "Science Building" /*&& tile1UpClickable.clickable == true*/)
            {
				if (tileUp1 != null)
                {
                    mrUp1 = tileUp1.GetComponent<MeshRenderer>();
                    mrUp1.material.color = Color.red;
                }
            }

			if (bm.selectedBuilding.tag == "Water Tower" /* && tile1UpClickable.clickable == true && tile1UpLeftClickable.clickable == true && tile1LeftClickable.clickable == true*/) 
			{
				if (tileUp1 != null)
				{
					mrUp1 = tileUp1.GetComponent<MeshRenderer>();
					mrUp1.material.color = Color.red;

					/*mrUp2 = tileLeft.GetComponent<MeshRenderer>();
					mrUp2.material.color = Color.red;

					mrUp3 = tileLeftUp1.GetComponent<MeshRenderer>();
					mrUp3.material.color = Color.red;*/
				}
			}

            if (bm.selectedBuilding.tag == "Clean Factory")
            {
                if (tileUp1 != null && tileUp2 != null && tileLeft != null && tileLeftUp1 != null)
                {
                    mrUp1 = tileUp1.GetComponent<MeshRenderer>();
                    mrUp1.material.color = Color.red;

                    mrUp2 = tileLeft.GetComponent<MeshRenderer>();
                    mrUp2.material.color = Color.red;

                    mrUp3 = tileLeftUp1.GetComponent<MeshRenderer>();
                    mrUp3.material.color = Color.red;

                    mrUp4 = tileUp2.GetComponent<MeshRenderer>();
                    mrUp4.material.color = Color.red;
                }
            }
        }
        
    }
    void OnMouseExit()
    {

        if (clickable == true)
        {
            thisMr.material.color = Color.white;

			if (bm.selectedBuilding.tag == "Factory"  || bm.selectedBuilding.tag == "Science Building")
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

					/*mrUp2 = tileLeft.GetComponent<MeshRenderer>();
					mrUp2.material.color = Color.white;

					mrUp3 = tileLeftUp1.GetComponent<MeshRenderer>();
					mrUp3.material.color = Color.white;*/
				}
			}

            if (bm.selectedBuilding.tag == "Clean Factory")
            {
                if (tileUp1 != null && tileUp2 != null && tileLeft != null && tileLeftUp1 != null)
                {
                    mrUp1 = tileUp1.GetComponent<MeshRenderer>();
                    mrUp1.material.color = Color.red;

                    mrUp2 = tileLeft.GetComponent<MeshRenderer>();
                    mrUp2.material.color = Color.red;

                    mrUp3 = tileLeftUp1.GetComponent<MeshRenderer>();
                    mrUp3.material.color = Color.red;

                    mrUp4 = tileUp2.GetComponent<MeshRenderer>();
                    mrUp4.material.color = Color.red;
                }
            }
        }
        
    }
}
